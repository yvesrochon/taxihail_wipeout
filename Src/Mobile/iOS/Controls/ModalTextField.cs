using System;
using MonoTouch.Foundation;
using System.Drawing;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Dialog.Touch.Dialog.Elements;
using Cirrious.MvvmCross.Dialog.Touch.Dialog;
using apcurium.MK.Common.Entity;
using System.Collections.Generic;

namespace apcurium.MK.Booking.Mobile.Client
{
    [Register("ModalTextField")]
    public class ModalTextField : GradientButton
    {
        RootElement _rootElement;

        public ModalTextField(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        public ModalTextField(RectangleF rect, float cornerRadius, Style.ButtonStyle buttonStyle, string title, UIFont titleFont, string image = null) : base ( rect , cornerRadius, buttonStyle, title, titleFont, image)
        {
        }

        private void Initialize() {
            TouchUpInside += HandleTouchUpInside;
        }

        void HandleTouchUpInside (object sender, EventArgs e)
        {
            var controller = this.FindViewController();
            if(controller == null) return;
            controller.View.EndEditing(true);
            if (_rootElement != null) {
                var newDvc = new DialogViewController (_rootElement, true) {
                    Autorotate = true

                };
                newDvc.View.BackgroundColor  = UIColor.FromRGB (230,230,230);
                newDvc.TableView.BackgroundColor = UIColor.FromRGB (230,230,230);
                newDvc.TableView.BackgroundView = new UIView{ BackgroundColor =  UIColor.FromPatternImage (UIImage.FromFile ("Assets/background.png")) }; 
                controller.NavigationController.PushViewController(newDvc, true);
            }
        }

        public void Configure<T>(string title, ListItem<T>[] values, T selectedId, Action<ListItem<T>> onItemSelected) where T: struct
        {
            int selected = 0;
            var section = new SectionWithBackground(title);
            foreach (var v in values)
            {
                // Keep a reference to value in order for callbacks to work correctly
                var value = v;
                var item = new RadioElementWithId<T>(value.Id, value.Display, value.Image);
                item.Tapped += ()=> {
                    onItemSelected(value);
                    var controller = this.FindViewController();
                    if(controller != null) controller.NavigationController.PopViewControllerAnimated(true);
                };
                section.Add(item);
                if (selectedId.Equals(value.Id))
                {
                    selected = Array.IndexOf(values, value);
                }
            }
            
            _rootElement = new CustomRootElement(title, new RadioGroup(selected));
            _rootElement.Add(section);
        }
    }
}

