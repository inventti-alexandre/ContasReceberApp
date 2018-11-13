using ContasReceberApp.Models;
using ContasReceberApp.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContasReceberApp.Services
{
    public class LoginService
    {
        private static readonly string AUTHENTICATED_USER = "authenticatedUser";
        private static readonly string TOKEN = "token";

        public static void Logout()
        {
            Preferences.putString(AUTHENTICATED_USER, "");
            Preferences.putString(TOKEN, "");
        }

        public static void SetAuthenticatedUser(User user)
        {
            Preferences.putEntity(AUTHENTICATED_USER, user);
        }

        public static User GetUserAuthenticated()
        {
            return Preferences.getEntity<User>(AUTHENTICATED_USER);
        }

        public static void GetUserLogged(Action<User> onSuccess, Action<string> onFailure = null)
        {
            User user = GetUserAuthenticated();
            if (user == null)
            {
                RestService.Get<User>("auth",
                    (result) => {
                        SetAuthenticatedUser(result);
                        onSuccess.Invoke(result);
                    },

                    //onFailure
                    (exception) =>
                    {
                        if (onFailure != null) onFailure.Invoke(exception);
                    }
                );
            }
            else
            {
                onSuccess.Invoke(user);
            }
        }
    }
}
