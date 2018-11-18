using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ContasReceberApp.Components.Entry
{
    public class CustomEntry : Xamarin.Forms.Entry
    {
        public CustomEntry()
        {
            if (Device.RuntimePlatform == Device.iOS) Margin = new Thickness(15, 10);
        }
    }
}
