using System;
using MonoTouch.UIKit;
using apcurium.MK.Common.Extensions;
using apcurium.MK.Booking.Mobile.Style;

namespace apcurium.MK.Booking.Mobile.Client
{
	public class TitleView : UIView
	{
		private  UILabel _titleText;
		private UIImageView _img;

		public TitleView (UIView rightView, string title)
		{
			Initialize();
			Load( rightView, title, false);
		}

		public TitleView (UIView rightView, string title, bool hideLogo)
		{
			Initialize();
			Load( rightView, title, hideLogo);
		}

		private void Initialize()
		{
	        AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleLeftMargin;
	        AutosizesSubviews = false;

			Frame = new System.Drawing.RectangleF(5, -3, 310, 50);

			_titleText = new UILabel(new System.Drawing.RectangleF(0, 4, 320, 40));
			_titleText.TextAlignment = UITextAlignment.Center;
            _titleText.Font = AppStyle.GetBoldFont ( 20 ); 
			_titleText.TextColor = AppStyle.NavigationTitleColor;
            _titleText.BackgroundColor = UIColor.Clear;
			AddSubview(_titleText);

			var image = UIImage.FromFile("Assets/Logo.png");
			_img = new UIImageView(image);

            if(  ( StyleManager.Current.CenterLogo.HasValue )  && ( StyleManager.Current.CenterLogo.Value ) )
            {
                _img.Frame = new System.Drawing.RectangleF((320 -image.Size.Width)/2, 5, image.Size.Width, image.Size.Height );                     
            }
            else
            {
			    _img.Frame = new System.Drawing.RectangleF(0, 5, image.Size.Width, image.Size.Height );            
            }
			_img.BackgroundColor = UIColor.Clear;
			_img.ContentMode = UIViewContentMode.ScaleAspectFit;
			_img.Hidden = true;
			AddSubview(_img);
		}

		private void Load( UIView rightView, string title, bool hideLogo )
		{
            if (rightView != null)
            {
                AddSubview(rightView);
            }
			else
			{
				SetTitle( title );
			}
			_img.Hidden = hideLogo;
		}


		public override System.Drawing.RectangleF Frame {
            get { return base.Frame; }
            set
            { 
                if (_titleText != null & value.X > 0)
                {
                    _titleText.Frame = new System.Drawing.RectangleF(-value.X, _titleText.Frame.Y, _titleText.Frame.Width, _titleText.Frame.Height);
                    if(  ( StyleManager.Current.CenterLogo.HasValue )  && ( StyleManager.Current.CenterLogo.Value ) )
                    {
                        var image = _img.Image;
                        _img.Frame = new System.Drawing.RectangleF(((320 -image.Size.Width)/2)-value.X, 5, image.Size.Width, image.Size.Height );                     
                    }
                }
                base.Frame = value;
            }
		}

        public void SetTitle(string title)
        {
            if (title.HasValue())
            {
                _titleText.Text = title;
            }
        }

	}
}

