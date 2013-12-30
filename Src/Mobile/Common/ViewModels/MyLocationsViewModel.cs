using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using apcurium.MK.Booking.Mobile.Extensions;
using apcurium.MK.Common.Entity;
using apcurium.MK.Common.Extensions;
using Cirrious.MvvmCross.Interfaces.Commands;
using ServiceStack.Text;

namespace apcurium.MK.Booking.Mobile.ViewModels
{
    public class MyLocationsViewModel: BaseViewModel
    {

        public override void Start(bool firstStart = false)
        {
            base.Start (firstStart);
            LoadAllAddresses();
        }

        private ObservableCollection<AddressViewModel> _allAddresses = new ObservableCollection<AddressViewModel>();
        public ObservableCollection<AddressViewModel> AllAddresses { 
            get {
                return _allAddresses;
            }
            set {
                if(value != _allAddresses) {
                    _allAddresses = value;
                    FirePropertyChanged("AllAddresses");
                }
            }
        }

        public IMvxCommand NavigateToLocationDetailPage{
            get{
                return GetCommand<AddressViewModel>(a =>
                {

                    if(a.Address.Id == Guid.Empty)
                    {
                        // New address
                        RequestNavigate<LocationDetailViewModel>();
                    } else {
                        RequestNavigate<LocationDetailViewModel>(new Dictionary<string,string>{
                            { "address", a.Address.ToJson() }
                        });
                    }
                });
            }
        }
        public Task LoadAllAddresses ()
        {
            var tasks = new [] {
                LoadFavoriteAddresses(),
                LoadHistoryAddresses()
            };
            return Task.Factory.ContinueWhenAll(tasks, t => {

                AllAddresses.Clear ();
                AllAddresses.Add (new AddressViewModel{ Address =  new Address
                    {
                        FriendlyName = this.Services().Resources.GetString("LocationAddFavoriteTitle"),
                        FullAddress = this.Services().Resources.GetString("LocationAddFavoriteSubtitle"),
                    }, IsAddNew = true, ShowPlusSign=true});


                if(t[0].Status == TaskStatus.RanToCompletion)
                {
                    AllAddresses.AddRange(t[0].Result);
                }

                if(t[1].Status == TaskStatus.RanToCompletion)
                {
                    AllAddresses.AddRange(t[1].Result);
                }

           

                AllAddresses.ForEach ( a=> 
                                           {
                    a.IsFirst = a.Equals(AllAddresses.First());
                    a.IsLast = a.Equals(AllAddresses.Last());                    
                });

                FirePropertyChanged( () =>AllAddresses );

            }, new CancellationTokenSource().Token, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        

        private Task<AddressViewModel[]> LoadFavoriteAddresses()
        {
            return Task<AddressViewModel[]>.Factory.StartNew(()=>{
                var adrs = this.Services().Account.GetFavoriteAddresses().ToList();
             
                return adrs.Select(a => new AddressViewModel
                { 
                    Address = a,
                    IsAddNew =  a.Id.IsNullOrEmpty(),
                    ShowPlusSign = a.Id.IsNullOrEmpty(),
                    ShowRightArrow = !a.Id.IsNullOrEmpty(),
                    Icon = "favorites"
                }).ToArray();
            }).HandleErrors();
        }

        private Task<AddressViewModel[]> LoadHistoryAddresses()
        {
            return Task<AddressViewModel[]>.Factory.StartNew(()=>{
                var adrs = this.Services().Account.GetHistoryAddresses();
                return adrs.Select(a => new AddressViewModel
                { 
                    Address = a,
                    ShowPlusSign = a.Id.IsNullOrEmpty(),
                    ShowRightArrow = !a.Id.IsNullOrEmpty(),
                    Icon = "history"
                }).ToArray();
            }).HandleErrors();
        }
    }
}

