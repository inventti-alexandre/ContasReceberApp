using ContasReceberApp.Models;
using ContasReceberApp.ViewModels;
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
	public partial class InsertPaymentPage : ContentPage
	{

        public AccountInsert AccountInsert { get; set; }
        private Account Account;
        public InsertPaymentPage (Account account)
		{
			InitializeComponent ();
            AccountInsert = new AccountInsert();
            CentroResponsabilidadeListPicker.ItemsSource = Parametros.ListarNomeCentroResponsabilidade(App.Parametros.CentroResponsabilidade);
            FormaCobrancaListPicker.ItemsSource = Parametros.ListarNomeFormaCobranca(App.Parametros.FormaCobranca);
            Account = account;
            BindingContext = this;
        }

        private void InputDataPagamento_DateSelected(object sender, DateChangedEventArgs e)
        {
            Account.DataPagamento = InputDataPagamento.Date.ToString("yyyy-MM-dd");

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            AccountInsert.Id = Account.Id;
            AccountInsert.EmpresaId = Account.EmpresaId;
            AccountInsert.TipoConta = Account.TipoConta;
            AccountInsert.CategoriaContaId = Account.CategoriaContaId;
            AccountInsert.FormaCobrancaId = Account.FormaCobrancaId;
            AccountInsert.CentroResponsabilidadeId = Account.CentroResponsabilidadeId;
            AccountInsert.FormaPagamentoId = Account.FormaPagamentoId;
            AccountInsert.ContaBancoId = Account.ContaBancoId;
            AccountInsert.DataPagamento = DateTime.Now.ToString("yyyy-MM-dd");
            AccountInsert.DataVencimento = Account.DataVencimento;
            AccountInsert.Historico = Account.Historico;
            AccountInsert.Valor = Account.ValorBruto;
            AccountInsert.ValorMulta = Account.ValorMulta;
            AccountInsert.ValorDesconto = Account.ValorDesconto;
            AccountInsert.Status = Status.PAGA;
            MessagingCenter.Send(this, "PayAccount", AccountInsert);
            await Navigation.PopAsync();
        }

        private void CentroResponsabilidadeListPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account.CentroResponsabilidadeId = App.Parametros.CentroResponsabilidade.ToList().Find(p => p.Nome.Equals(CentroResponsabilidadeListPicker.SelectedItem.ToString())).Id;
        }

        private void FormaCobrancaListPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account.FormaCobrancaId = App.Parametros.FormaCobranca.ToList().Find(p => p.Nome.Equals(FormaCobrancaListPicker.SelectedItem.ToString())).Id;
        }
    }
}