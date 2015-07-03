﻿using System;
using UIKit;
using CoreGraphics;
using CrossUI.Touch.Dialog.Elements;
using apcurium.MK.Common;
using apcurium.MK.Booking.Mobile.Client.Localization;
using apcurium.MK.Common.Entity;
using Foundation;
using apcurium.MK.Booking.Mobile.ViewModels;

namespace apcurium.MK.Booking.Mobile.Client.Controls.Widgets
{
	[Register("DialCodeSelector")]
	public class DialCodeSelector:UILabel
	{
		UINavigationController navigationController;
		Action<CountryCode> OnDialCodeChanged;

		public event PhoneNumberInfo.PhoneNumberDatasourceChangedEventHandler NotifyChanges;
		Action PhoneNumberInfoDatasourceChanged;


		public DialCodeSelector(IntPtr handle):base(handle)
		{
			Initialize();
		}

		public DialCodeSelector():base()
		{
			Initialize();
		}

		public DialCodeSelector(CGRect frame):base(frame)
		{
			Initialize();
		}

		public void Initialize()
		{
			this.UserInteractionEnabled = true;
			UITapGestureRecognizer gr = new UITapGestureRecognizer(OnDialCodeSelectorClick);
			AddGestureRecognizer(gr);
		}
			
		public void Configure(UINavigationController navigationController)
		{
			this.navigationController = navigationController;
		}

		public void Configure(UINavigationController navigationController, CountryCode selectedCountryCode, Action<CountryCode> OnDialCodeChanged)
		{
			this.navigationController = navigationController;
			this.OnDialCodeChanged = OnDialCodeChanged;
			this.selectedCountryCode = selectedCountryCode;
            PhoneNumberInfoDatasourceChanged();
		}

		public void Configure(UINavigationController navigationController, PhoneNumberInfo phoneNumberInfo)
		{
			this.navigationController = navigationController;
			PhoneNumberInfoDatasourceChanged = phoneNumberInfo.PhoneNumberDatasourceChangedCallEvent;
			phoneNumberInfo.PhoneNumberDatasourceChanged += PhoneNumberDatasourceChanged;
			this.NotifyChanges += phoneNumberInfo.NotifyChanges;
			PhoneNumberInfoDatasourceChanged();
		}

		CountryCode selectedCountryCode;

		public CountryCode SelectedCountryCode
		{
			get
			{
				return selectedCountryCode;
			}

			set
			{
				selectedCountryCode = value;
				this.Text = value.CountryDialCode > 0 ? "+" + value.CountryDialCode.ToString() : null;
			}
		}
			
		void PhoneNumberDatasourceChanged(object sender, PhoneNumberChangedEventArgs e)
		{
            SelectedCountryCode = CountryCode.GetCountryCodeByIndex(CountryCode.GetCountryCodeIndexByCountryDialCode(e.CountryDialCode));
		}

		public void OnDialCodeSelectorClick()
		{
			var section = new Section();

			for (int i = 0; i < CountryCode.CountryCodes.Length; i++)
			{
				string text = "";

				text += CountryCode.CountryCodes[i].CountryDialCode != 0 ?
					new string(' ', (Math.Max(3 - CountryCode.CountryCodes[i].CountryDialCode.ToString().Length, 0)) * 2)
					+ "+" + CountryCode.CountryCodes[i].CountryDialCode
					: "        ";

				text += " " + CountryCode.CountryCodes[i].CountryName;

				var item = new RadioElementWithId<CountryCode>(CountryCode.CountryCodes[i], text, null, false, 10);

				CountryCode countryCode = CountryCode.CountryCodes[i];
				item.Tapped += () =>
				{
					SelectedCountryCode = countryCode;

					if (OnDialCodeChanged != null)
					{
						OnDialCodeChanged(selectedCountryCode);
					}

					if (NotifyChanges != null)
					{
						NotifyChanges(null, new PhoneNumberChangedEventArgs() { CountryDialCode = selectedCountryCode.CountryDialCode });
					}
				};

				section.Add(item);
			}
				
            RootElement rootElement = new RootElement(Localize.GetValue("DialCodeSelectorTitle"), new RadioGroup(CountryCode.GetCountryCodeIndexByCountryDialCode(SelectedCountryCode.CountryDialCode)));
			rootElement.Add(section);

			var dialCodeSelectorViewController = new TaxiHailDialogViewController(rootElement, true, false, 20);
			navigationController.NavigationBar.Hidden = false;
			navigationController.NavigationItem.BackBarButtonItem = new UIBarButtonItem(Localize.GetValue("BackButton"), UIBarButtonItemStyle.Bordered, null, null);
			navigationController.PushViewController(dialCodeSelectorViewController, true);
		}
	}
}