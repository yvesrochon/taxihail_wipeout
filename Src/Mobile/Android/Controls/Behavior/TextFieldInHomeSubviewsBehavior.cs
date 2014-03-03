﻿using System;
using Android.Widget;
using Android.Views.InputMethods;
using System.Collections.Generic;
using apcurium.MK.Booking.Mobile.Client.Extensions;

namespace apcurium.MK.Booking.Mobile.Client.Controls.Behavior
{
    public class TextFieldInHomeSubviewsBehavior
    {
        public static void ApplyTo(IEnumerable<EditText> editTexts, Action onFocus, Action onLostFocus)
        {
            foreach (var editText in editTexts)
            {
                ApplyTo(editText, onFocus, onLostFocus);
            }
        }

        public static void ApplyTo(EditText editText, Action onFocus, Action onLostFocus)
        {
            if (editText == null) 
            {
                return;
            }

            editText.FocusChange += (sender, e) => 
            {
                if (e.HasFocus)
                {
                    onFocus();
                    editText.ShowKeyboard();
                }
                else
                {
                    onLostFocus();
                    editText.HideKeyboard();
                }
            };

            editText.EditorAction += (sender, e) => 
            {
                if(e.ActionId == ImeAction.Done){
                    editText.ClearFocus();
                } 
            };
        }
    }
}

