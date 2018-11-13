using ContasReceberApp.Models;
using ContasReceberApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContasReceberApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            this.Entity = new User();
        }

        private async void Login()
        {
            RestService.Authenticate(this.Entity as User,
                //onSuccess
                (token) => {
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                },

                //onFailure
                (e) => _iPopupsService.DisplayAlert("erro", e, "OK")
                );
        }
    }
}
