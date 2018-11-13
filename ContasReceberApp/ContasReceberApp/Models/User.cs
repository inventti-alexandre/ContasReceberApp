using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContasReceberApp.Models
{
    public class User
    {
        [JsonProperty("email")]
        public string Email
        { get; set; } = "xamarin@tecnofit.com.br";

        [JsonProperty("password")]
        public string Password
        { get; set; } = "xamarin";
    }
}
