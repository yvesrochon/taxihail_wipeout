﻿using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.EventSourcing;
using apcurium.MK.Booking.Events;
using apcurium.MK.Common;
using apcurium.MK.Common.Entity;
using apcurium.MK.Common.Extensions;

namespace apcurium.MK.Booking.Domain
{
    public class Company : EventSourced
    {
        private Guid? _defaultTariffId;

        public Company(Guid id) : base(id)
        {
            RegisterHandlers();
            this.Update(new CompanyCreated
            {
                SourceId = id,
            });
        }

        public Company(Guid id, IEnumerable<IVersionedEvent> history)
            : base(id)
        {
            RegisterHandlers();
            this.LoadFrom(history);
        }

        private void RegisterHandlers()
        {
            base.Handles<DefaultFavoriteAddressAdded>(OnEventDoNothing);
            base.Handles<DefaultFavoriteAddressRemoved>(OnEventDoNothing);
            base.Handles<DefaultFavoriteAddressUpdated>(OnEventDoNothing);

            base.Handles<PopularAddressAdded>(OnEventDoNothing);
            base.Handles<PopularAddressRemoved>(OnEventDoNothing);
            base.Handles<PopularAddressUpdated>(OnEventDoNothing);

            base.Handles<CompanyCreated>(OnEventDoNothing);
            base.Handles<AppSettingsAddedOrUpdated>(OnEventDoNothing);
            base.Handles<TariffCreated>(OnRateCreated);
            base.Handles<TariffUpdated>(OnEventDoNothing);
            base.Handles<TariffDeleted>(OnEventDoNothing);

            base.Handles<RatingTypeAdded>(OnEventDoNothing);
            base.Handles<RatingTypeHidded>(OnEventDoNothing);
            base.Handles<RatingTypeUpdated>(OnEventDoNothing);
        }

        public void AddDefaultFavoriteAddress(Address address)
        {
            ValidateFavoriteAddress(address.FriendlyName, address.FullAddress, address.Latitude, address.Longitude);

            this.Update(new DefaultFavoriteAddressAdded
            {
                Address = address
            });
        }

        public void UpdateDefaultFavoriteAddress(Address address)
        {
            ValidateFavoriteAddress(address.FriendlyName, address.FullAddress, address.Latitude, address.Longitude);

            this.Update(new DefaultFavoriteAddressUpdated()
            {
                Address = address
            });
        }

        public void RemoveDefaultFavoriteAddress(Guid addressId)
        {
            this.Update(new DefaultFavoriteAddressRemoved
            {
                AddressId = addressId
            });
        }

        public void AddPopularAddress(Guid id, string friendlyName, string apartment, string fullAddress, string ringCode, string buildingName, double latitude, double longitude)
        {
            ValidateFavoriteAddress(friendlyName, fullAddress, latitude, longitude);

            this.Update(new PopularAddressAdded
            {
                AddressId = id,
                FriendlyName = friendlyName,
                Apartment = apartment,
                FullAddress = fullAddress,
                RingCode = ringCode,
                BuildingName = buildingName,
                Latitude = latitude,
                Longitude = longitude,
            });
        }

        public void UpdatePopularAddress(Guid id, string friendlyName, string apartment, string fullAddress, string ringCode, string buildingName, double latitude, double longitude)
        {
            ValidateFavoriteAddress(friendlyName, fullAddress, latitude, longitude);

            this.Update(new PopularAddressUpdated()
            {
                AddressId = id,
                FriendlyName = friendlyName,
                Apartment = apartment,
                FullAddress = fullAddress,
                RingCode = ringCode,
                BuildingName = buildingName,
                Latitude = latitude,
                Longitude = longitude
            });
        }

        public void RemovePopularAddress(Guid addressId)
        {
            this.Update(new PopularAddressRemoved
            {
                AddressId = addressId
            });
        }

        public void AddOrUpdateAppSettings(IDictionary<string, string> appSettings)
        {
            this.Update(new AppSettingsAddedOrUpdated
            {
                AppSettings = appSettings
            });
        }

        public void AddRatingType(string name, Guid ratingTypeId)
        {
            if(name.IsNullOrEmpty())
                throw new ArgumentException("Rating name cannot be null or empty");

            Update(new RatingTypeAdded()
                       {
                           Name = name,
                           RatingTypeId = ratingTypeId
                       });
        }

        public void UpdateRatingType(string name, Guid ratingTypeId)
        {
            if (name.IsNullOrEmpty())
                throw new ArgumentException("Rating name cannot be null or empty");

            Update(new RatingTypeUpdated()
            {
                Name = name,
                RatingTypeId = ratingTypeId
            });
        }

        public void HideRatingType(Guid ratingTypeId)
        {
            Update(new RatingTypeHidded
            {
                RatingTypeId = ratingTypeId
            });
        }

        public void CreateDefaultTariff(Guid tariffId, string name, decimal flatRate, double distanceMultiplicator, double timeAdustmentFactor, decimal pricePerPassenger)
        {
            if(_defaultTariffId.HasValue)
            {
                throw new InvalidOperationException("Only one default tariff can be created");
            }

            this.Update(new TariffCreated
            {
                TariffId = tariffId,
                Type = TariffType.Default,
                Name = name,
                FlatRate = flatRate,
                KilometricRate = distanceMultiplicator,
                MarginOfError = timeAdustmentFactor,
                PassengerRate = pricePerPassenger,
            });

        }

        public void CreateRecurringTariff(Guid tariffId, string name, decimal flatRate, double distanceMultiplicator, double timeAdustmentFactor, decimal pricePerPassenger, DayOfTheWeek daysOfTheWeek, DateTime startTime, DateTime endTime)
        {
            this.Update(new TariffCreated
            {
                TariffId = tariffId,
                Type = TariffType.Recurring,
                Name = name,
                FlatRate = flatRate,
                KilometricRate = distanceMultiplicator,
                MarginOfError = timeAdustmentFactor,
                PassengerRate = pricePerPassenger,
                DaysOfTheWeek = daysOfTheWeek,
                StartTime = startTime,
                EndTime = endTime
            });
        }

        public void CreateDayTariff(Guid tariffId, string name, decimal flatRate, double distanceMultiplicator, double timeAdustmentFactor, decimal pricePerPassenger, DateTime startTime, DateTime endTime)
        {
            this.Update(new TariffCreated
            {
                TariffId = tariffId,
                Type = TariffType.Day,
                Name = name,
                FlatRate = flatRate,
                KilometricRate = distanceMultiplicator,
                MarginOfError = timeAdustmentFactor,
                PassengerRate = pricePerPassenger,
                StartTime = startTime,
                EndTime = endTime
            });
        }
        public void UpdateTariff(Guid tariffId, string name, decimal flatRate, double distanceMultiplicator, double timeAdustmentFactor, decimal pricePerPassenger, DayOfTheWeek daysOfTheWeek, DateTime startTime, DateTime endTime)
        {
            this.Update(new TariffUpdated
            {
                TariffId = tariffId,
                Name = name,
                FlatRate = flatRate,
                KilometricRate = distanceMultiplicator,
                MarginOfError = timeAdustmentFactor,
                PassengerRate = pricePerPassenger,
                DaysOfTheWeek = daysOfTheWeek,
                StartTime = startTime,
                EndTime = endTime
            });
        }

        public void DeleteTariff(Guid tariffId)
        {
            if(tariffId == this._defaultTariffId)
            {
                throw new InvalidOperationException("Cannot delete default tariff");
            }
            this.Update(new TariffDeleted
            {
                TariffId = tariffId
            });

        }

        private static void ValidateFavoriteAddress(string friendlyName, string fullAddress, double latitude, double longitude)
        {
            if (Params.Get(friendlyName, fullAddress).Any(string.IsNullOrEmpty))
            {
                throw new InvalidOperationException("Missing required fields");
            }

            if (latitude < -90 || latitude > 90)
            {
                throw new ArgumentOutOfRangeException("latitude", "Invalid latitude");
            }

            if (longitude < -180 || latitude > 180)
            {
                throw new ArgumentOutOfRangeException("longitude", "Invalid longitude");
            }
        }

        private void OnRateCreated(TariffCreated @event)
        {
            if(@event.Type == TariffType.Default)
            {
                this._defaultTariffId = @event.TariffId;
            }
        }

        private void OnEventDoNothing<T>(T @event) where T: VersionedEvent
        {
            // Do nothing
        }
    }
}
