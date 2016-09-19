﻿using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using apcurium.MK.Booking.Mobile.Extensions;
using apcurium.MK.Common;
using Connectivity.Plugin;

namespace apcurium.MK.Booking.Mobile.Infrastructure
{
    public class ConnectivityService : IConnectivityService
    {
        private readonly IMessageService _messageService;
        private readonly ILocalization _localize;
        private bool _isDisplayed = false;

        object _lock = new object();



        public ConnectivityService(IMessageService messageService, ILocalization localize)
        {
            _messageService = messageService;
            _localize = localize;

            IsConnected = CrossConnectivity.Current.IsConnected;
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
                {
                    IsConnected = args.IsConnected;
                };

        }

        public async void HandleToastInNewView()
        {
            if (IsConnected)
            {
                _messageService.DismissToast();
                _isDisplayed = false;
            }
            else
            {
                _messageService.DismissToast();
                _isDisplayed = await _messageService.ShowToast(_localize["NoConnectionMessage"]).HandleErrors();
            }
        }

        public void ToastDismissed()
        {
            _isDisplayed = false;
        }

        public async void ShowToast()
        {
            if (!_isDisplayed)
            {
                _isDisplayed = await _messageService.ShowToast(_localize["NoConnectionMessage"]).HandleErrors();
            }
        }



        private bool _isConnected = true;
        public bool IsConnected
        {
            get
            { 
                return _isConnected;
            }
            private set
            {
                if (_isConnected == value)
                {
                    return;
                }


                _isConnected = value;

                if (_isConnected)
                {
                    _messageService.DismissToast();

                    lock (_lock)
                    {
                        _isDisplayed = false;
                    }
                }
                else
                {
                    lock (_lock)
                    {
                        if (_isDisplayed)
                        {
                            return;
                        }
                    }

                    _messageService.ShowToast(_localize["NoConnectionMessage"])
                        .ContinueWith(async task =>
                        {
                            var isSuccess = await task;

                            lock (_lock)
                            {
                                _isDisplayed = isSuccess;
                            }
                        }, TaskContinuationOptions.OnlyOnRanToCompletion)
                        .FireAndForget();
                }
            }
        }
    }
}

