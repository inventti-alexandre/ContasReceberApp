using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ContasReceberApp.Components.DatePicker
{
    public class CustomDatePicker : Xamarin.Forms.DatePicker
    {
        public CustomDatePicker()
        {
            if (Device.RuntimePlatform == Device.iOS) Margin = new Thickness(15, 10);
        }
    }
}
