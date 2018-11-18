using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ContasReceberApp.Droid.Components;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ContasReceberApp.Components.Entry.CustomEntry), typeof(CustomEntryRenderer))]
namespace ContasReceberApp.Droid.Components
{
    internal class CustomEntryRenderer : EntryRenderer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
                Control.SetPadding(34, 22, 34, 22);
            }
        }
    }
}