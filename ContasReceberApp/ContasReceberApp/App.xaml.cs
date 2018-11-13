using ContasReceberApp.Models;
using ContasReceberApp.Services;
using ContasReceberApp.Settings;
using ContasReceberApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ContasReceberApp
{
	public partial class App : Application
	{
        public static Parametros Parametros { get; set; }
        public App ()
		{
			InitializeComponent();

			MainPage = new MainPage();

            User user = LoginService.GetUserAuthenticated();

            if (user != null)
            {
                RestService.SetOAuthToken(Preferences.getString("token"));
                MainPage = new MainPage();
            }
            else
            {
                MainPage = new LoginPage();
            }
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
