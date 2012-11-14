using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.Views;
using TinyIoC;
using TinyMessenger;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Mobile.AppServices;
using apcurium.MK.Booking.Mobile.Messages;
using apcurium.MK.Common.Extensions;

namespace apcurium.MK.Booking.Mobile.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        //TODO : a remplacer quand les strings seront globalisee
        private const string titleFormat = "Order #{0} ({1:ddd, MMM d}, {1:h:mm tt})";
        private ObservableCollection<OrderViewModel> _orders;

        public ObservableCollection<OrderViewModel> Orders
        {
            get { return _orders; }
            set { _orders = value; FirePropertyChanged("Orders"); }
        }
        public HistoryViewModel()
        {
            IEnumerable<Order> orders = new Order[0];

            orders = new ObservableCollection<Order>(TinyIoCContainer.Current.Resolve<IAccountService>().GetHistoryOrders().ToList());
            Orders = new ObservableCollection<OrderViewModel>(orders.Select(x =>
                                       {
                                          
                                           return new OrderViewModel()
                                               {
                                                   IBSOrderId = x.IBSOrderId,
                                                   Id = x.Id,
                                                   CreatedDate = x.CreatedDate,
                                                   PickupAddress = x.PickupAddress,
                                                   PickupDate = x.PickupDate, 
                                                   IsCompleted = x.IsCompleted,
                                                   Title = String.Format(titleFormat, x.IBSOrderId.ToString(), x.CreatedDate),
                                                   IsFirst = x.Equals(orders.First()),
                                                   IsLast = x.Equals(orders.Last()),
                                                   ShowRightArrow = true
                                               };
                                       }
                                       ).ToList());
        }


        public IMvxCommand NavigateToHistoryDetailPage
        {
            get
            {
                return new MvxRelayCommand<OrderViewModel>(vm =>
                                                               {
                                                                   RequestNavigate<HistoryDetailViewModel>(new { orderId = vm.Id});
                });
            }
        }
    }
}