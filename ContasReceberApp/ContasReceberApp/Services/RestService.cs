using ContasReceberApp.Models;
using ContasReceberApp.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ContasReceberApp.Services
{
    public class RestService
    {
        public static string Url = "http://api.tecnofit.com.br/";
        public static readonly HttpClient _client = new HttpClient();

        public static void Authenticate(User user, Action<string> onSuccess, Action<string> onFailure = null)
        {
            string completeUri = Url + "auth";
            PostAsync(completeUri, user,
                //onSuccess
                (response, json) =>
                {
                    String token = JObject.Parse(json)["token"].ToString();
                    SetOAuthToken(token);
                    onSuccess.Invoke(token);
                },

                //onFailure
                (exception) =>
                {
                    if (onFailure != null) onFailure.Invoke(exception);
                });
        }

        /// <summary>
        ///  SetOAuthToken
        /// </summary>
        /// <param name="token"></param>
        public static void SetOAuthToken(string token)
        {
            Preferences.putString("token", token);
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public static void Get<T>(string uri, Action<T> onSuccess, Action<string> onFailure = null)
        {
            GetAsync(Url + uri,
                //onSuccess
                (response, json) => {
                    onSuccess.Invoke(JsonConvert.DeserializeObject<T>(json));
                },

                //onFailure
                (exception) => {
                    if (onFailure != null) onFailure.Invoke(exception);
                });
        }

        public static void Send<T>(string uri, T entity, Action<T> onSuccess, Action<string> onFailure) where T : new()
        {
            PostAsync(Url+ uri, entity,
                //onSuccess
                (response, json) => {
                    onSuccess.Invoke(JsonConvert.DeserializeObject<T>(json));
                },

                //onFailure
                (exception) => {
                    if (onFailure != null) onFailure.Invoke(exception);
                });
        }


        private static async void PostAsync(string uri, object entity, Action<HttpResponseMessage, string> onSuccess, Action<string> onFailure = null)
        {
            try
            {
                string content = entity != null ? JsonConvert.SerializeObject(entity, Formatting.Indented) : "";
                StringContent restContent = new StringContent(content, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(uri, restContent);
                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    onSuccess.Invoke(response, json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public static async void GetAsync(string uri, Action<HttpResponseMessage, string> onSuccess, Action<string> onFailure = null)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(Url + uri);
                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    onSuccess.Invoke(response, json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.GetBaseException().Message);
            }
        }
    }
}
