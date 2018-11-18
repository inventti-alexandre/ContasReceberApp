using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContasReceberApp.iOS.Components.Entry;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContasReceberApp.Components.Picker.CustomPicker), typeof(CustomPickerRenderer))]
namespace ContasReceberApp.iOS.Components.Entry
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}