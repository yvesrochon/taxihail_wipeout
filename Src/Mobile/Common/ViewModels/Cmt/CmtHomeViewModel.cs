﻿using System;
using System.Collections.ObjectModel;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using TinyMessenger;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Mobile.AppServices;
using apcurium.MK.Booking.Mobile.Infrastructure;
using apcurium.MK.Common.Diagnostic;
using apcurium.MK.Common.Entity;

namespace apcurium.MK.Booking.Mobile.ViewModels
{
    public class CmtHomeViewModel : BaseViewModel,
        IMvxServiceConsumer<IAccountService>,
        IMvxServiceConsumer<ILocationService>,
        IMvxServiceConsumer<IBookingService>,
        IMvxServiceConsumer<IPreCogService>
    {
        private IBookingService _bookingService;
        private ILocationService _geolocator;
        private IAccountService _accountService;
        private IPreCogService _preCogService;

        private Address PickupAddress { get; set; }
        private Address DestinationAddress { get; set; }

        protected override void Initialize()
        {
            Panel = new PanelViewModel(this);
            _accountService = this.GetService<IAccountService>();
            _geolocator = this.GetService<ILocationService>();
            _bookingService = this.GetService<IBookingService>();
            _preCogService = this.GetService<IPreCogService>();

            //_preCogService.Start();

            PickupAddress = new Address();
            DestinationAddress = new Address();

            Pickup = new BookAddressViewModel(() => PickupAddress, address => { PickupAddress = address; }, _geolocator)
            {

                EmptyAddressPlaceholder = Resources.GetString("BookPickupLocationEmptyPlaceholder")
            };
            Dropoff = new BookAddressViewModel(() => DestinationAddress, address => { DestinationAddress = address; }, _geolocator)
            {
                 EmptyAddressPlaceholder = Resources.GetString("BookDropoffLocationEmptyPlaceholder")
            };
        }

        public PanelViewModel Panel { get; set; }

        public BookAddressViewModel Pickup { get; set; }

        public BookAddressViewModel Dropoff { get; set; }

        public ObservableCollection<CmtMessageViewModel> Messages { get; set; }

        public MvxRelayCommand GuideMe
        {
            get
            {
                return new MvxRelayCommand(() =>
                {
                    Messages.Add(new CmtMessageViewModel { Message = Resources.GetString("GuidancePlease"), IsUser = true });
                    Messages.Add(new CmtMessageViewModel { Message = string.Format(Resources.GetString("GuidanceLocationConfirmation"), Pickup.Model.BookAddress), IsUser = false });
                    Messages.Add(new CmtMessageViewModel { Message = string.Format(Resources.GetString("GuidanceDestinationRequest"), _accountService.CurrentAccount.Name), IsUser = false });

                });
            }
        }

    }

    public class CmtMessageViewModel
    {
        public string Message { get; set; }
        public bool IsUser { get; set; }
    }
}