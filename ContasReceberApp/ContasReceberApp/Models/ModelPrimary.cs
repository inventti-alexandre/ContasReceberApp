using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContasReceberApp.Models
{
    public class ModelPrimary
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
