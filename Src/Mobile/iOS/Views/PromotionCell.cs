﻿using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using apcurium.MK.Booking.Mobile.ViewModels;
using apcurium.MK.Booking.Mobile.Client.Controls.Widgets;
using apcurium.MK.Booking.Mobile.Client.Extensions.Helpers;
using apcurium.MK.Booking.Mobile.Client.Localization;

namespace apcurium.MK.Booking.Mobile.Client.Views
{
    public partial class PromotionCell : MvxTableViewCell
    {
        public PromotionCell(IntPtr handle) : base(handle)
        {
            SelectionStyle = UITableViewCellSelectionStyle.None;
        }       

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            var set = this.CreateBindingSet<PromotionCell, PromotionItemViewModel>();

            set.Bind(lblName).For(v => v.Text).To(vm => vm.Name);
            set.Bind(lblExpires).For(v => v.Text).To(vm => vm.ExpiringSoonWarning);
            set.Bind(lblDescription).For(v => v.Text).To(vm => vm.Description);
            set.Bind(btnApplyPromo).For("TouchUpInside").To(vm => vm.SelectedCommand);
            set.Bind().For(v => v.IsExpanded).To(vm => vm.IsExpanded);

            set.Apply(); 

            ApplyStyle();
        }

        private bool _hideBottomBar;
        public bool HideBottomBar
        {
            get { return _hideBottomBar; }
            set
            { 
                if (BackgroundView is CustomCellBackgroundView)
                {
                    ((CustomCellBackgroundView)BackgroundView).HideBottomBar = value;
                }
                _hideBottomBar = value;
            }
        }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    lblDescription.Hidden = !_isExpanded;
                    btnApplyPromo.Hidden = !_isExpanded;
                }
            }
        }

        private void ApplyStyle()
        {
            lblDescription.Hidden = true;
            btnApplyPromo.Hidden = true;

            BackgroundView = new CustomCellBackgroundView(this.ContentView.Frame, 10, UIColor.White, UIColor.FromRGB(190, 190, 190)) 
            {
                HideBottomBar = HideBottomBar            
            };

            lblName.TextColor = UIColor.FromRGB(44, 44, 44);
            lblName.Font = UIFont.FromName(FontName.HelveticaNeueBold, 28/2);

            lblExpires.TextColor = UIColor.FromRGB(251, 0, 10);
            lblExpires.Font = UIFont.FromName(FontName.HelveticaNeueMedium, 22/2);

            FlatButtonStyle.Green.ApplyTo(btnApplyPromo);
            btnApplyPromo.Font = UIFont.FromName(FontName.HelveticaNeueRegular, 28 / 2);
            btnApplyPromo.SetTitle(Localize.GetValue("PromoBookRide"), UIControlState.Normal);

            ContentView.BackgroundColor = UIColor.Clear;
            BackgroundColor = UIColor.Clear;
        }
    }
}

