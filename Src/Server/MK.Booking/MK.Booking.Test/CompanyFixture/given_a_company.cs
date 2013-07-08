﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using apcurium.MK.Booking.CommandHandlers;
using apcurium.MK.Booking.Commands;
using apcurium.MK.Booking.Common.Tests;
using apcurium.MK.Booking.Domain;
using apcurium.MK.Booking.Events;
using apcurium.MK.Common;
using apcurium.MK.Common.Configuration.Impl;
using apcurium.MK.Common.Entity;

namespace apcurium.MK.Booking.Test.CompanyFixture
{
    [TestFixture]
    public class given_a_company
    {
        private EventSourcingTestHelper<Company> sut;
        readonly Guid _companyId = AppConstants.CompanyId;

        [SetUp]
        public void given_a_company_setup()
        {
            sut = new EventSourcingTestHelper<Company>();
            sut.Setup(new CompanyCommandHandler(this.sut.Repository));
            sut.Given(new CompanyCreated {SourceId = _companyId});
        }

        [Test]
        public void when_creating_a_new_rate()
        {
            var tariffId = Guid.NewGuid();

            sut.When(new CreateTariff
                              {
                                  CompanyId = _companyId,
                                  TariffId = tariffId,
                                  Name = "Week-End", 
                                  FlatRate = 3.50m,
                                  KilometricRate = 1.1,
                                  MarginOfError = 1.2,
                                  PassengerRate = 1.3m,
                                  DaysOfTheWeek = DayOfTheWeek.Saturday | DayOfTheWeek.Sunday,
                                  StartTime = DateTime.Today.AddHours(12).AddMinutes(30),
                                  EndTime = DateTime.Today.AddHours(20),
                                  Type = TariffType.Recurring
                              });

            var evt = sut.ThenHasSingle<TariffCreated>();
            Assert.AreEqual(_companyId, evt.SourceId);
            Assert.AreEqual(tariffId, evt.TariffId);
            Assert.AreEqual("Week-End", evt.Name);
            Assert.AreEqual(3.50, evt.FlatRate);
            Assert.AreEqual(1.1, evt.KilometricRate);
            Assert.AreEqual(1.2, evt.MarginOfError);
            Assert.AreEqual(1.3m, evt.PassengerRate);
            Assert.AreEqual(DayOfTheWeek.Saturday, evt.DaysOfTheWeek & DayOfTheWeek.Saturday);
            Assert.AreEqual(DayOfTheWeek.Sunday, evt.DaysOfTheWeek & DayOfTheWeek.Sunday);
            Assert.AreEqual(12, evt.StartTime.Hour);
            Assert.AreEqual(30, evt.StartTime.Minute);
            Assert.AreEqual(20, evt.EndTime.Hour);
            Assert.AreEqual(00, evt.EndTime.Minute);
            Assert.AreEqual(TariffType.Recurring, evt.Type);
        }

        [Test]
        public void when_creating_a_new_rule()
        {
            var ruleId = Guid.NewGuid();

            this.sut.When(new CreateRule
            {
                CompanyId = _companyId,
                RuleId = ruleId,                
                Category = RuleCategory.DisableRule,
                Type = RuleType.Default,
                Message = "Due to..."
            });

            var evt = sut.ThenHasSingle<RuleCreated>();
            Assert.AreEqual(_companyId, evt.SourceId);
            Assert.AreEqual(ruleId, evt.RuleId);
            Assert.AreEqual(RuleCategory.DisableRule, evt.Category);
            Assert.AreEqual(RuleType.Default, evt.Type);
            Assert.AreEqual("Due to...", evt.Message);
        }

        [Test]
        public void when_creating_default_warning_and_disable_rule()
        {
            var ruleId = Guid.NewGuid();

            this.sut.When(new CreateRule
            {
                CompanyId = _companyId,
                RuleId = ruleId,
                Category = RuleCategory.DisableRule,
                Type = RuleType.Default,
                Message = "Due to..."
            });

            var evt = sut.ThenHasSingle<RuleCreated>();
            Assert.AreEqual(_companyId, evt.SourceId);
            Assert.AreEqual(ruleId, evt.RuleId);
            Assert.AreEqual(RuleCategory.DisableRule, evt.Category);
            Assert.AreEqual(RuleType.Default, evt.Type);
            Assert.AreEqual("Due to...", evt.Message);

            ruleId = Guid.NewGuid();

            this.sut.When(new CreateRule
            {
                CompanyId = _companyId,
                RuleId = ruleId,
                Category = RuleCategory.WarningRule,
                Type = RuleType.Default,
                Message = "Due to..."
            });

            Assert.AreEqual(2, sut.Events.Count);
            evt = (RuleCreated)sut.Events.Single(e => ((RuleCreated)e).Category == RuleCategory.WarningRule );
            Assert.AreEqual(_companyId, evt.SourceId);
            Assert.AreEqual(ruleId, evt.RuleId);
            Assert.AreEqual(RuleCategory.WarningRule, evt.Category);
            Assert.AreEqual(RuleType.Default, evt.Type);
            Assert.AreEqual("Due to...", evt.Message);
        }

       [Test]
        public void when_appsettings_added_successfully()
        {
            //this.sut.When(new AddAppSettings() { CompanyId = _companyId,  Key = "Key.hi", Value = "Value.hi" });
            this.sut.When(new AddOrUpdateAppSettings() { CompanyId = _companyId, AppSettings = new Dictionary<string, string> { { "Key.hi", "Value.hi" } } });

            var evt = sut.ThenHasSingle<AppSettingsAddedOrUpdated>();
            Assert.AreEqual(_companyId, evt.SourceId);
            Assert.AreEqual("Key.hi", evt.AppSettings.First().Key);
            Assert.AreEqual("Value.hi", evt.AppSettings.First().Value);
        }

        [Test]
        public void when_appsettings_updated_successfully()
        {
            //this.sut.When(new UpdateAppSettings() { CompanyId = _companyId, Key = "Key.Default", Value = "Value.newValue" });
            this.sut.When(new AddOrUpdateAppSettings()
                {
                    CompanyId = _companyId,
                    AppSettings = new Dictionary<string, string> {{"Key.Default", "Value.newValue"}}
                });

            var evt = sut.ThenHasSingle<AppSettingsAddedOrUpdated>();
            Assert.AreEqual(_companyId, evt.SourceId);
            Assert.AreEqual("Key.Default", evt.AppSettings.First().Key);
            Assert.AreEqual("Value.newValue", evt.AppSettings.First().Value);
        }

        [Test]
        public void when_paymentsettings_updated_successfully()
        {
            var newSettings = new ServerPaymentSettings(Guid.NewGuid())
                {
                    CompanyId = _companyId,
                };

            var key = Guid.NewGuid().ToString();

            newSettings.BraintreeClientSettings.ClientKey = key;


            sut.Given(new PaymentSettingUpdated()
                {
                    SourceId = _companyId,
                    ServerPaymentSettings = newSettings
                });

            sut.When(new UpdatePaymentSettings()
                {
                    ServerPaymentSettings = newSettings
                });

            
            var evt = sut.ThenHasSingle<PaymentSettingUpdated>();
            sut.ThenHasNo<PaymentModeChanged>();//dont delete cc if payment mode doesnt change

            Assert.AreEqual(_companyId, evt.SourceId);
            Assert.AreEqual(key,evt.ServerPaymentSettings.BraintreeClientSettings.ClientKey);
            
            Assert.AreSame(newSettings,evt.ServerPaymentSettings);
        }

        [Test]
        public void when_paymentmode_changed()
        {
            var newSettings = new ServerPaymentSettings(Guid.NewGuid())
            {
                CompanyId = _companyId,
            };

            sut.When(new UpdatePaymentSettings()
            {
                ServerPaymentSettings = newSettings
            });


            Assert.AreEqual(2, sut.Events.Count);
            var evt = sut.ThenHas<PaymentSettingUpdated>();
            var evt2 = sut.ThenHas<PaymentModeChanged>().First();

            Assert.AreEqual(_companyId, evt2.SourceId);
        }

        [Test]
        public void when_adding_an_company_default_address_successfully()
        {
            var addressId = Guid.NewGuid();
            sut.When(new AddDefaultFavoriteAddress
            {
                Address = new Address
                {
                    Id = addressId,
                    FriendlyName = "Chez François",
                    Apartment = "3939",
                    FullAddress = "1234 rue Saint-Hubert",
                    RingCode = "3131",
                    BuildingName = "Hôtel de Ville",
                    Latitude = 45.515065,
                    Longitude = -73.558064
                }
            });

            var evt = sut.ThenHasSingle<DefaultFavoriteAddressAdded>();
            Assert.AreEqual(addressId, evt.Address.Id);
            Assert.AreEqual("Chez François", evt.Address.FriendlyName);
            Assert.AreEqual("3939", evt.Address.Apartment);
            Assert.AreEqual("1234 rue Saint-Hubert", evt.Address.FullAddress);
            Assert.AreEqual("3131", evt.Address.RingCode);
            Assert.AreEqual("Hôtel de Ville", evt.Address.BuildingName);
            Assert.AreEqual(45.515065, evt.Address.Latitude);
            Assert.AreEqual(-73.558064, evt.Address.Longitude);

        }

        [Test]
        public void when_adding_an_company_popular_address_successfully()
        {
            var addressId = Guid.NewGuid();
            sut.When(new AddPopularAddress
            {
                Address = new Address
                {

                    Id = addressId,
                    FriendlyName = "Chez François popular",
                    Apartment = "3939",
                    FullAddress = "1234 rue Saint-Hubert",
                    RingCode = "3131",
                    BuildingName = "Hôtel de Ville",
                    Latitude = 45.515065,
                    Longitude = -73.558064
                }
            });

            var evt = sut.ThenHasSingle<PopularAddressAdded>();
            Assert.AreEqual(addressId, evt.Address.Id);
            Assert.AreEqual("Chez François popular", evt.Address.FriendlyName);
            Assert.AreEqual("3939", evt.Address.Apartment);
            Assert.AreEqual("1234 rue Saint-Hubert", evt.Address.FullAddress);
            Assert.AreEqual("3131", evt.Address.RingCode);
            Assert.AreEqual("Hôtel de Ville", evt.Address.BuildingName);
            Assert.AreEqual(45.515065, evt.Address.Latitude);
            Assert.AreEqual(-73.558064, evt.Address.Longitude);
        }

        [Test]
        public void when_adding_an_company_default_address_with_missing_required_fields()
        {
            Assert.Throws<InvalidOperationException>(() => sut.When(new AddDefaultFavoriteAddress { Address = new Address { FriendlyName = null, Apartment = "3939", FullAddress = null, RingCode = "3131", Latitude = 45.515065, Longitude = -73.558064 } }));
        }

        [Test]
        public void when_adding_an_company_popular_address_with_missing_required_fields()
        {
            Assert.Throws<InvalidOperationException>(() => sut.When(new AddPopularAddress { Address = new Address { FriendlyName = null, Apartment = "3939", FullAddress = null, RingCode = "3131", Latitude = 45.515065, Longitude = -73.558064 } }));
        }
    }
}
