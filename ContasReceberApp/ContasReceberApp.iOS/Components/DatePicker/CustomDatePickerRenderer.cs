using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContasReceberApp.iOS.Components.DatePicker;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContasReceberApp.Components.DatePicker.CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace ContasReceberApp.iOS.Components.DatePicker
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}