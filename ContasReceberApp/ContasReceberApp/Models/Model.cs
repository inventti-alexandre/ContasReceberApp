using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContasReceberApp.Models
{
    public class Model : ModelPrimary
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}
