using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ContasReceberApp.Components.Picker
{
    public class CustomPicker : Xamarin.Forms.Picker
    {
        public CustomPicker()
        {
            if (Device.RuntimePlatform == Device.iOS) Margin = new Thickness(15, 10);
        }
    }
}
