using ContasReceberApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContasReceberApp.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountView : ContentView
	{
		public AccountView ()
		{
			InitializeComponent ();
		}

        private async void BtnPagarConta_Clicked(object sender, EventArgs e)
        {
            var currentPage = Application.Current.MainPage;

            if (currentPage != null && currentPage.GetType().Equals(typeof(NavigationPage)))
            {
                var currentNavigationPage = (NavigationPage)currentPage;
                await currentNavigationPage.PushAsync(new InsertPaymentPage(((Button)sender).BindingContext as Account), false);
            }

        }
    }
}