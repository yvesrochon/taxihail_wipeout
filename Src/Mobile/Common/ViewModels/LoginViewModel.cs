using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Commands;
using TinyIoC;
using apcurium.MK.Common.Diagnostic;
using apcurium.MK.Common.Extensions;
using apcurium.MK.Booking.Mobile.Infrastructure;
using apcurium.MK.Booking.Mobile.AppServices;
using apcurium.MK.Booking.Api.Contract.Resources;
using System.Threading;
using apcurium.MK.Booking.Api.Contract.Requests;
using ServiceStack.Text;
using SocialNetworks.Services;
using apcurium.Framework;

namespace apcurium.MK.Booking.Mobile.ViewModels
{
	public class LoginViewModel : BaseViewModel
    {
		private IAccountService _accountService;
        private IFacebookService _facebookService;
        private ITwitterService _twitterService;

        public LoginViewModel(IFacebookService facebookService,ITwitterService twitterService, IAccountService accountService)
		{
			_accountService = accountService;		

            CheckVersion();
            _facebookService = facebookService;
            _twitterService = twitterService;
            _facebookService.ConnectionStatusChanged -= HandleFbConnectionStatusChanged;
            _facebookService.ConnectionStatusChanged += HandleFbConnectionStatusChanged;
            
            _twitterService.ConnectionStatusChanged -= HandleTwitterConnectionStatusChanged;
            _twitterService.ConnectionStatusChanged += HandleTwitterConnectionStatusChanged;
		}

        private void CheckVersion()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                //The 2 second delay is required because the view might not be created.
                Thread.Sleep(2000);
                TinyIoCContainer.Current.Resolve<IApplicationInfoService>().CheckVersion();
            });

        }        
	

		private string _email;
		public string Email {
			get { return _email; }
			set { _email = value;
				FirePropertyChanged( () => Email );
			}
		}

		private string _password;
		public string Password {
			get { return _password; }
			set { _password = value;
				FirePropertyChanged( () => Password );
			}
		}

		public MvxRelayCommand SignInCommand
		{
			get
			{
				return new MvxRelayCommand(() => {
					try
					{
                        TinyIoCContainer.Current.Resolve<IAccountService>().ClearCache();
						ThreadPool.QueueUserWorkItem( SignIn );  
					}
					finally
					{
					}
				});
			}
		}

		private void SignIn( object state )
		{
			try
			{
                TinyIoCContainer.Current.Resolve<ILogger>().LogMessage("SignIn with server {0}", TinyIoCContainer.Current.Resolve<IAppSettings>().ServiceUrl);            
                MessageService.ShowProgress(true);				
				var account = _accountService.GetAccount(Email, Password);

                if ( account != null )
                {
                    this.Password = "";
                    RequestNavigate<BookViewModel>(true );
                }              
				
			}
			finally
			{				
				TinyIoCContainer.Current.Resolve<IMessageService>().ShowProgress(false);
			}
		}

        public MvxRelayCommand ResetPassword
        {
            get
            {
                return new MvxRelayCommand(() => 
                { 
                    RequestSubNavigate<ResetPasswordViewModel, string>(null, email => {
                        if(email.HasValue())
                        {
                            Email = email;
                        }
                    });  
                });
            }
        }

        public MvxRelayCommand<RegisterAccount> Signup
        {
            get
            {
                return new MvxRelayCommand<RegisterAccount>(registerDataFromSocial => 
                { 
                    string serialized = null;
                    if (registerDataFromSocial != null) {
                        serialized = JsonSerializer.SerializeToString(registerDataFromSocial);
                    }
                    RequestSubNavigate<CreateAcccountViewModel, RegisterAccount>(new Dictionary<string, string>{ {"data", serialized } }, OnAccountCreated);  
                });
            }
        }

        void OnAccountCreated (RegisterAccount data)
        {
            if (data != null) {
                if (data.FacebookId.HasValue () || data.TwitterId.HasValue ()) {
                    var facebookId = data.FacebookId;
                    var twitterId = data.TwitterId;
                    MessageService.ShowProgress(true);                   
                    try {
                        Thread.Sleep (500);                             
                        var service = TinyIoCContainer.Current.Resolve<IAccountService> ();
                        Account account;
                        if (facebookId.HasValue ()) {
                            account = service.GetFacebookAccount (facebookId);
                        } else {
                            account = service.GetTwitterAccount (twitterId);
                        }
                        if (account != null) {
                            RequestNavigate<BookViewModel>(true );
                        }
                    } catch {
                    } finally {                 
                        MessageService.ShowProgress(false);  
                    }
                } else {
                    Email = data.Email;
                }
            }
        }

        public MvxRelayCommand LoginFacebook
        {
            get{
                return new MvxRelayCommand(() => { 
                    if (_facebookService.IsConnected)
                    {
                        CheckFacebookAccount();
                    }
                    else
                    {
                        _facebookService.Connect("email, publish_stream, publish_actions");
                        
                    }
                });
            }
        }

        public MvxRelayCommand LoginTwitter
        {
            get{
                return new MvxRelayCommand(() => { 
                    if (_twitterService.IsConnected)
                    {
                        CheckTwitterAccount();
                    }
                    else
                    {
                        _twitterService.Connect();
                        
                    }
                });
            }
        }

        void HandleFbConnectionStatusChanged (object sender, SocialNetworks.Services.Entities.FacebookStatus e)
        {
            if (e.IsConnected)
            {
                CheckFacebookAccount ();
            }
        }

        private void CheckFacebookAccount ()
        {
            MessageService.ShowProgress(true);
            _facebookService.GetUserInfos(info => {
                var data = new RegisterAccount();
                data.FacebookId = info.Id;
                data.Email = info.Email;
                data.Name = Params.Get(info.Firstname, info.Lastname).Where(n => n.HasValue()).JoinBy(" ");                

                try
                {                        
                    var account = _accountService.GetFacebookAccount(data.FacebookId);
                    if (account == null)
                    {
                        Signup.Execute(data);
                    }else{
                        RequestNavigate<BookViewModel>(true );
                    }
                }
                finally
                {
                    MessageService.ShowProgress(false);
                }
                
            }, () => {});
        }

        private void CheckTwitterAccount ()
        {
            MessageService.ShowProgress(true);
            
            _twitterService.GetUserInfos(info => {
                var data = new RegisterAccount();
                data.TwitterId = info.Id;
                data.Name = Params.Get(info.Firstname, info.Lastname).Where(n => n.HasValue()).JoinBy(" ");

                try
                {                                      
                    var account = _accountService.GetTwitterAccount(data.TwitterId);
                    if (account == null)
                    {                               
                        Signup.Execute(data);
                    } else{
                        RequestNavigate<BookViewModel>(true );
                    }                   
                }
                finally
                {
                    MessageService.ShowProgress(false);
                }
            }
            );
        }

        void HandleTwitterConnectionStatusChanged (object sender, SocialNetworks.Services.Entities.TwitterStatus e)
        {
            if (e.IsConnected)
            {
                CheckTwitterAccount();
            }
        }
	}
}