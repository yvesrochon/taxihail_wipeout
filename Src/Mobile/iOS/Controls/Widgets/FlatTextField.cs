using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.CoreGraphics;
using apcurium.MK.Booking.Mobile.Client.Extensions.Helpers;
using apcurium.MK.Booking.Mobile.Client.Extensions;
using apcurium.MK.Common.Extensions;

namespace apcurium.MK.Booking.Mobile.Client.Controls.Widgets
{
	[Register("FlatTextField")]
	public class FlatTextField : UITextField
	{
	    private const float RadiusCorner = 2;
        protected const float Padding = 6.5f;
        private UIImageView _leftImageView;

	    public FlatTextField (IntPtr handle) : base (handle)
		{
			Initialize();
		}

		public FlatTextField ()
		{
			Initialize();
		}

		public FlatTextField (RectangleF frame) : base (frame)
		{
			Initialize();
		}

        private void Initialize ()
		{
            BackgroundColor = UIColor.White;

            if(UIHelper.IsOS7orHigher)
			{
                TintColor = UIColor.FromRGB(44, 44, 44); // cursor color
			}

            TextColor = UIColor.FromRGB(44, 44, 44);
			Font = UIFont.FromName(FontName.HelveticaNeueLight, 38/2);

            //padding
            LeftView = new UIView(new RectangleF(0f, 0f, Padding, 1f)); 
			LeftViewMode = UITextFieldViewMode.Always;
            RightView = new UIView(new RectangleF(Frame.Right - Padding, 0f, Padding, 1f));
            RightViewMode = UITextFieldViewMode.Always;
		}

		public override void Draw (RectangleF rect)
		{   
            var fillColor = State.HasFlag (UIControlState.Normal)
                            ? BackgroundColor
			                : UIColor.Clear;

			var roundedRectanglePath = UIBezierPath.FromRoundedRect (rect, RadiusCorner);

			DrawBackground(UIGraphics.GetCurrentContext(), rect, roundedRectanglePath, fillColor.CGColor);
			DrawStroke(fillColor.CGColor);
			SetNeedsDisplay();
		}

		public override bool Enabled {
			get {
				return base.Enabled;
			}
			set {
				base.Enabled = value;
				SetNeedsDisplay();
			}
		}

        public override UIColor BackgroundColor
        {
            get
            {
                return base.BackgroundColor;
            }
            set
            {
                if (value != base.BackgroundColor)
                {
                    base.BackgroundColor = value;
                    SetNeedsDisplay();
                }
            }
        }

        private string _imageLeftSource;
        public string ImageLeftSource
        {
            get { return _imageLeftSource; }
            set
            {
                if (value.HasValue() && value != _imageLeftSource)
                {
                    _imageLeftSource = value;

                    var image = UIImage.FromFile(value);

                    if (_leftImageView != null)
                    {
                        _leftImageView.RemoveFromSuperview();
                    }

                    _leftImageView = new UIImageView(new RectangleF(0, (Frame.Height - image.Size.Height)/2, image.Size.Width, image.Size.Height));
                    _leftImageView.Image = image;
                    AddSubview(_leftImageView);

                    // Adjust the left padding of the text for image width
                    LeftView.Frame = LeftView.Frame.SetWidth(image.Size.Width + Padding);

                    // And the right padding
                    RightView = new UIView(new RectangleF(Frame.Right - Padding, 0f, Padding, 1f));

                    SetNeedsDisplay();
                }
            }
        }

        private bool _hasRightArrow { get; set; }
        public bool HasRightArrow {
            get { return _hasRightArrow; }
            set 
            {
                _hasRightArrow = value;

                if(value)
                {
                    var image = UIImage.FromFile("right_arrow.png");
                    var rightArrow = new UIImageView(new RectangleF(Frame.Width - image.Size.Width - Padding, (Frame.Height - image.Size.Height)/2, image.Size.Width, image.Size.Height));
                    rightArrow.Image = image;

                    RightView.Frame = RightView.Frame.IncrementWidth(image.Size.Width + Padding); // this is to keep the same padding between the end of the text and the right arrow
                    AddSubview(rightArrow);

                    SetNeedsDisplay();
                }
            }
        }

		private void DrawBackground(CGContext context, RectangleF rect, UIBezierPath roundedRectanglePath, CGColor fillColor)
		{
			context.SaveState ();
			context.BeginTransparencyLayer (null);
			roundedRectanglePath.AddClip ();
			context.SetFillColorWithColor(fillColor);
			context.FillRect(rect);
			context.EndTransparencyLayer ();
			context.RestoreState ();
		}

		private void DrawStroke(CGColor fillColor)
		{
			BorderStyle = UITextBorderStyle.None;
			Layer.BorderWidth = 1.0f;
			Layer.BorderColor = fillColor;
			Layer.CornerRadius = RadiusCorner;
		}
	}
}

