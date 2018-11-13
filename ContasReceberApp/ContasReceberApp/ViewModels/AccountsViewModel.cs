using ContasReceberApp.Models;
using ContasReceberApp.Services;
using ContasReceberApp.Views;
using ContasReceberApp.Views.Templates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContasReceberApp.ViewModels
{
    public class AccountsViewModel : BaseViewModel
    {
        public ICommand GetAcountsCommand { get; set; }
        public AccountsViewModel()
        {
            this.Entity = new AccountStatement();
            //Recebe a confirmação do envio do cadastro da conta
            MessagingCenter.Subscribe<InsertAccountPage, AccountInsert>(this, "InserirAccount", async (obj, account) =>
            {
                var _account = account as AccountInsert;
                RestService.Send("financeiro/conta-pr/cadastro", account as AccountInsert,
                //onSuccess
                (result) => {
                    GetAccounts(DateTime.Now.ToString("yyyy-MM-dd"));
                },

                //onFailure
                (e) => _iPopupsService.DisplayAlert("erro", e, "OK")
                );
            });
            //Recebe a confirmação do envio do pagamento da conta
            MessagingCenter.Subscribe<InsertPaymentPage, AccountInsert>(this, "PayAccount", async (obj, account) =>
            {
                var _account = account as AccountInsert;
                RestService.Send("financeiro/conta-pr/cadastro", account as AccountInsert,
                //onSuccess
                (result) =>
                {
                    GetAccounts(DateTime.Now.ToString("yyyy-MM-dd"));
                },

                //onFailure
                (e) => _iPopupsService.DisplayAlert("erro", e, "OK")
                );
            });
            //Buscar combos
            RestService.GetAsync("financeiro/conta-pr/1036/R",
                    //onSuccess
                    (response, result) =>
                    {
                        String json = JObject.Parse(result)["parametros"].ToString();
                        App.Parametros = JsonConvert.DeserializeObject<Parametros>(json);
                    },

                    //onFailure
                    (e) => _iPopupsService.DisplayAlert("erro", e, "OK")
                    );
        }

        private async void GetAccounts(string date)
        {
            try
            {
                RestService.GetAsync("financeiro/extrato/dia/1036/" + date,
                    //onSuccess
                    (response, result) =>
                    {
                        String json = JObject.Parse(result)["accountStatement"].ToString();
                        this.Entity = JsonConvert.DeserializeObject<AccountStatement>(json);
                        MessagingCenter.Send(this, "Listar", this.Entity);
                    },

                    //onFailure
                    (e) => _iPopupsService.DisplayAlert("erro", e, "OK")
                    );
            }
            catch (Exception  ex)
            { await _iPopupsService.DisplayAlert("erro", ex.Message.Trim(), "OK"); }
        }
    }
}
