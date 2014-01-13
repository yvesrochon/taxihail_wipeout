using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Mobile.Data;
using apcurium.MK.Booking.Mobile.Extensions;
using apcurium.MK.Common.Entity;

namespace apcurium.MK.Booking.Mobile.ViewModels.Payment
{
    public class PaymentDetailsViewModel: BaseSubViewModel<PaymentInformation>
    {
		public void Init(string messageId, PaymentInformation paymentDetails)
        {
			Init(messageId);

			CreditCards.CollectionChanged += (sender, e) =>  RaisePropertyChanged(()=>HasCreditCards);
		
            LoadCreditCards();
        
            SelectedCreditCardId = paymentDetails.CreditCardId.GetValueOrDefault();
        
            Tip = paymentDetails.TipPercent.HasValue 
                ? paymentDetails.TipPercent.Value 
                : 0;
        }
    
        private readonly ObservableCollection<CreditCardDetails> _creditCards = new ObservableCollection<CreditCardDetails>();
        public ObservableCollection<CreditCardDetails> CreditCards {
            get {
                return _creditCards;
            }
        }
    
        private Guid _selectedCreditCardId;
        public Guid SelectedCreditCardId {
            get{ return _selectedCreditCardId; }
            set{
                if(value != _selectedCreditCardId)
                {
                    _selectedCreditCardId = value;
					RaisePropertyChanged(()=>SelectedCreditCardId);
					RaisePropertyChanged(()=>SelectedCreditCard);
                }
            
            }
        }
    
        public string CurrencySymbol {
            get {
                var culture = new CultureInfo(this.Services().Config.GetSetting("PriceFormat"));
                return culture.NumberFormat.CurrencySymbol;
            }
        }
    
        public CreditCardDetails SelectedCreditCard {
            get{ 
                return CreditCards.FirstOrDefault(x=>x.CreditCardId == SelectedCreditCardId);
            }
        }
    
        public bool HasCreditCards {
            get {
                return CreditCards.Any();
            }
        }
    
        public int Tip 
        { 
            get
            {
                return _tip;
            }
            set
			{
                _tip = value;
				RaisePropertyChanged();
            }
        }

        private int _tip;
    
        public ListItem<Guid>[] GetCreditCardListItems ()
        {
            return CreditCards.Select(x=> new ListItem<Guid> { Id = x.CreditCardId, Display = x.FriendlyName }).ToArray();
        }

        public AsyncCommand NavigateToCreditCardsList
        {
            get {
                return GetCommand (()=>{
                
                                           if(CreditCards.Count == 0)
                                           {
												ShowSubViewModel<CreditCardAddViewModel,CreditCardInfos>(null, newCreditCard => InvokeOnMainThread(()=>
                                               {
                                                   CreditCards.Add (new CreditCardDetails
                                                   {
                                                       CreditCardCompany = newCreditCard.CreditCardCompany,
                                                       CreditCardId = newCreditCard.CreditCardId,
                                                       FriendlyName = newCreditCard.FriendlyName,
                                                       Last4Digits = newCreditCard.Last4Digits
                                                   });
                                                   SelectedCreditCardId = newCreditCard.CreditCardId;
                                               }));
                    
                                           }else{
                    
                    
												ShowSubViewModel<CreditCardsListViewModel, Guid>(null, result => {
                                                                                                                      if(result != default(Guid))
                                                                                                                      {
                                                                                                                          SelectedCreditCardId = result;
                            
                                                                                                                          //Reload credit cards in case the credit card list has changed (add/remove)
                                                                                                                          LoadCreditCards();
                                                                                                                      }
                                               });
                                           }
                });
            }
        }
    
        public Task LoadCreditCards ()
        {
            var task = Task.Factory.StartNew(() => {

                            var cards = this.Services().Account.GetCreditCards();
                            InvokeOnMainThread(delegate {
                                                            CreditCards.Clear();
                                                            foreach (var card in cards) {
                                                                CreditCards.Add(card);
                                                            }
                                                            // refresh selected credit card
															RaisePropertyChanged(()=>SelectedCreditCard);
                            });
            }).HandleErrors();
        
            return task;
        }
    }
}