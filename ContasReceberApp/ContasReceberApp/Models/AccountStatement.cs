using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ContasReceberApp.Models
{
    public class AccountStatement
    {
        [JsonProperty("accounts")]
        public ObservableCollection<Account> Accounts
        { get; set; }

        [JsonProperty("previousBalance")]
        public decimal PreviousBalance { get; set; }

        [JsonProperty("currentBalance")]
        public decimal CurrentBalance { get; set; }

        [JsonProperty("accountsReceivable")]
        public decimal AccountsReceivable { get; set; }

        [JsonProperty("accountsPayable")]
        public decimal AccountsPayable { get; set; }
    }
}
