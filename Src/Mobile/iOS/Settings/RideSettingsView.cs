using System;
using System.Linq;
using MonoTouch.Dialog;
using MonoTouch.UIKit;

//using apcurium.Framework.Extensions;
using apcurium.Framework;
using TinyIoC;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Common.Entity;
using apcurium.MK.Booking.Mobile.Extensions;
using apcurium.MK.Booking.Mobile.AppServices;
using Cirrious.MvvmCross.Interfaces.Views;
using apcurium.MK.Booking.Mobile.ViewModels;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.Views;
using apcurium.MK.Common.Extensions;
using System.Collections.Generic;
using Cirrious.MvvmCross.Dialog.Touch;

namespace apcurium.MK.Booking.Mobile.Client
{
    public class RideSettingsView : MvxTouchDialogViewController<RideSettingsViewModel>
    {
        public event EventHandler Closed;

        private BookingSettings _settings;
        private RightAlignedEntryElement _nameEntry;
        private RightAlignedEntryElement _phoneEntry;
        private RightAlignedEntryElement _passengerEntry;
        private CustomRootElement _vehiculeTypeEntry;
        private RightAlignedEntryElement _numberOfTaxiEntry;
        private int _selected = 0;
        private bool _autoSave;
        private bool _companyOnly;

        public RideSettingsView(MvxShowViewModelRequest request)
            : base(request, UITableViewStyle.Grouped, null, false)
        {
            
        }
        
        public RideSettingsView(MvxShowViewModelRequest request, UITableViewStyle style, Cirrious.MvvmCross.Dialog.Touch.Dialog.Elements.RootElement root, bool pushing)
            : base(request, style, root, pushing)
        {
            
        }

        public RideSettingsView(Account account, bool autoSave, bool companyOnly) : base(null)
        {
            _companyOnly = companyOnly;
            _autoSave = autoSave;
            _settings = account.Settings.Copy();
        }

        public RideSettingsView(BookingSettings settings, bool autoSave, bool companyOnly) : base(null)
        {
            _companyOnly = companyOnly;
            _autoSave = autoSave;
            _settings = settings.Copy();
        }

        public BookingSettings Result
        {
            get { return _settings; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var button = new MonoTouch.UIKit.UIBarButtonItem(Resources.DoneButton, UIBarButtonItemStyle.Plain, delegate
            {
                ViewModel.DoneCommand.Execute();
            });
            NavigationItem.HidesBackButton = true;
            NavigationItem.RightBarButtonItem = button;
            NavigationItem.Title = Resources.GetValue("View_RideSettings");
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.NavigationBar.Hidden = false;

            ((UINavigationController)ParentViewController).View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Assets/background.png"));
            
            View.BackgroundColor = UIColor.Clear; 
            TableView.BackgroundColor = UIColor.Clear;
            TableView.BackgroundView = new UIView { BackgroundColor = UIColor.Clear };
        }

        public override void ViewDidAppear(bool animated)
        {

            base.ViewDidAppear(animated);
            LoadSettingsElements();
        }

        private void CloseView()
        {
            _nameEntry.Maybe(() => _nameEntry.FetchValue());            
            _phoneEntry.Maybe(() => _phoneEntry.FetchValue());          
            _numberOfTaxiEntry.Maybe(() => _numberOfTaxiEntry.FetchValue());
            _passengerEntry.Maybe(() => _passengerEntry.FetchValue());
            
            
            if (Closed != null)
            {
                Closed(this, EventArgs.Empty);
            }
            
            
            if (!_companyOnly)
            {
                this.NavigationController.PopViewControllerAnimated(true);
            }
        }

        private void ApplyChanges()
        {
            if (_autoSave)
            {
                ThreadHelper.ExecuteInThread(() =>
                {
                    TinyIoCContainer.Current.Resolve<IAccountService>().UpdateSettings(_settings);
                });
            }
            
        }

        private void LoadSettingsElementsForComaganies()
        {
            ThreadHelper.ExecuteInThread(() =>
            {
                try
                {
                    int index = 0;
                    int selected = 0;
                    
                    var companies = new Section(Resources.RideSettingsCompany);
                    var companiesList = TinyIoCContainer.Current.Resolve<IAccountService>().GetCompaniesList();
                    index = 0;
                    selected = 0;
                    foreach (ListItem company in companiesList)
                    {
                        if (!company.Display.ToSafeString().ToLower().Contains("test"))
                        {
                            var item = new RadioElementWithId(company.Display);
                            item.Id = company.Id;
                            item.Tapped += delegate
                            {
                                SetCompany(item); 
                            };
                            
                            companies.Add(item);
                            if (_settings.ProviderId == company.Id)
                            {
                                selected = index;
                            }
                            index++;
                        }
                    }
                    
                    var companyEntry = new RootElement(Resources.RideSettingsCompany, new RadioGroup(selected));
                    companyEntry.Add(companies);
                    
                    
                    
                    
                    this.InvokeOnMainThread(() => {
                        /*this.Root = companyEntry;*/ });
                    
                }
                finally
                {
                    
                }
                
            });
            
        }

        private void LoadSettingsElements()
        {
            
            
            ThreadHelper.ExecuteInThread(() =>
            {
                
                try
                {
                    
                    var vehicules = TinyIoCContainer.Current.Resolve<IAccountService>().GetVehiclesList();
                    var payements = TinyIoCContainer.Current.Resolve<IAccountService>().GetPaymentsList();

                    this.InvokeOnMainThread(() => {

                        var menu = new RootElement(this.Title);
                        var settings = new Section(Resources.DefaultRideSettingsViewTitle);
                    
                        _nameEntry = new RightAlignedEntryElement(Resources.RideSettingsName, "", _settings.Name);
                        _nameEntry.KeyboardType = MonoTouch.UIKit.UIKeyboardType.Default;
                        _nameEntry.Changed += delegate
                        {
                            _nameEntry.FetchValue();
                            _settings.Name = _nameEntry.Value;
                            ApplyChanges();
                        };
                    
                        _phoneEntry = new RightAlignedEntryElement(Resources.RideSettingsPhone, "", _settings.Phone);
                        _phoneEntry.Changed += delegate
                        {
                            _phoneEntry.FetchValue();
                            _settings.Phone = _phoneEntry.Value;
                            ApplyChanges();
                        };
                    
                        _phoneEntry.KeyboardType = MonoTouch.UIKit.UIKeyboardType.PhonePad;
        
                        _passengerEntry = new RightAlignedEntryElement(Resources.RideSettingsPassengers, "", _settings.Passengers.ToString());
                        _passengerEntry.KeyboardType = MonoTouch.UIKit.UIKeyboardType.NumberPad;
                    
                        _passengerEntry.Changed += delegate
                        {
                            _passengerEntry.FetchValue();
                            int r;
                            if (int.TryParse(_passengerEntry.Value, out r))
                            {
                                _settings.Passengers = r;                           
                            }
                            else
                            {
                                _passengerEntry.Value = "1";
                            }
                            ApplyChanges();
                        
                        };
                    
                        var vehiculeTypes = new SectionWithBackground(Resources.RideSettingsVehiculeType);
                    
                    
                    
                        int index = 0;
                    
                    
                        foreach (ListItem vType in vehicules)
                        {
                            var item = new RadioElementWithId(vType.Display);
                            item.Id = vType.Id;
                            item.Tapped += delegate
                            {                                                       
                                SetVehiculeType(item);
                        
                                ((UINavigationController)this.ParentViewController).PopViewControllerAnimated(true);
                            };
                            vehiculeTypes.Add(item);
                            if (_settings.VehicleTypeId == vType.Id)
                            {
                                _selected = index;
                            }
                            index++;
                        }
                        _vehiculeTypeEntry = new CustomRootElement(Resources.RideSettingsVehiculeType, new RadioGroup(_selected));
                        _vehiculeTypeEntry.Add(vehiculeTypes);
                
                        var chargeTypes = new SectionWithBackground(Resources.RideSettingsChargeType);
                    
                    
                    
                        index = 0;
                        int selected = 0;
                    
                    
                        foreach (ListItem pay in payements)
                        {
                            var item = new RadioElementWithId(pay.Display);
                            item.Id = pay.Id;
                            item.Tapped += delegate
                            {
                                SetChargeType(item); 
                                ((UINavigationController)this.ParentViewController).PopViewControllerAnimated(true);
                            };
                            chargeTypes.Add(item);
                            if (_settings.ChargeTypeId == pay.Id)
                            {
                                selected = index;

                            }
                            index++;
                        }
                        var chargeTypeEntry = new CustomRootElement(Resources.RideSettingsChargeType, new RadioGroup(selected));
                        chargeTypeEntry.Add(chargeTypes);


                        menu.Add(settings);

//                  ******************************************************
//                  Update password menu item, remove comments to activate
//                  ******************************************************
//                  if( !_accountId.IsNullOrEmpty() )
//                  {
//                      _updatePasswordElement = new NavigationElement( Resources.View_UpdatePassword, () => {
//                          var args = new Dictionary<string, string>(){ {"accountId", _accountId.Value.ToString()} };
//                          var dispatch = TinyIoC.TinyIoCContainer.Current.Resolve<IMvxViewDispatcherProvider>().Dispatcher;
//                          dispatch.RequestNavigate(new MvxShowViewModelRequest(typeof(UpdatePasswordViewModel), args, false, MvxRequestedBy.UserAction));
//                      });
//                  
//                      settings.Add ( _updatePasswordElement );
//                  }

                        settings.Add(_nameEntry);
                        settings.Add(_phoneEntry);
                    
                        settings.Add(_passengerEntry);
                        settings.Add(_vehiculeTypeEntry);
                        settings.Add(chargeTypeEntry);
                
                    
                        /*this.Root = menu; */});
                    
                }
                finally
                {
                    
                }
                
            });
            
        }

        private void SetVehiculeType(RadioElementWithId item)
        {
            SetVehiculeType(item.Id, item.Caption);
        }

        private void SetVehiculeType(int id, string vehiculeName)
        {
            _settings.VehicleTypeId = id;           
            ApplyChanges();
            
        }

        private void SetChargeType(RadioElementWithId item)
        {
            _settings.ChargeTypeId = item.Id;   
            ApplyChanges();
            
        }

        private void SetCompany(RadioElementWithId item)
        {
            _settings.ProviderId = item.Id;
            ApplyChanges();
        }

        private void SetException(CheckboxElement item)
        {
            //_settings.Exceptions.Single( e => e.Id == item.ItemId ).Value = !_settings.Exceptions.Single( e => e.Id == item.ItemId ).Value;
            ApplyChanges();
        }
    
    }
}

