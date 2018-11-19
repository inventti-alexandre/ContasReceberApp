using ContasReceberApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContasReceberApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountDetailPage : ContentPage
	{
		public AccountDetailPage (Account account)
		{
			InitializeComponent ();
            BindingContext = account;
		}

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertAccountPage(App.Parametros));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertAccountPage(App.Parametros, ((Button)sender).BindingContext as Account));
        }
    }
}