using ContasReceberApp.Components.Entry;
using ContasReceberApp.Models;
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
	public partial class InsertAccountPage : ContentPage
	{
        public AccountInsert Account { get; set; }
        private Parametros Parametros;
        private List<string> FormaCobranca { get; set; }
        private List<string> CategoriaConta { get; set; }
        private List<string> CentroResponsabilidade { get; set; }
        private List<string> ContaBanco { get; set; }
        public InsertAccountPage (Parametros Parametros, Account account = null)
		{
			InitializeComponent ();
            Account = new AccountInsert();
            if (Parametros != null)
            {
                CategoriaContaListPicker.ItemsSource = Parametros.CategoriaConta;
                FormaPagamentoListPicker.ItemsSource = Parametros.FormaCobranca;
                CentroResponsabilidadeListPicker.ItemsSource = Parametros.CentroResponsabilidade;
                ContaBancoListPicker.ItemsSource = Parametros.ContaBanco;
                Account.DataVencimento = InputDataVencimento.Date.ToString("yyyy-MM-dd");
                this.Parametros = Parametros;
            }
            //Verifica se conta esta em alteração
            if (account != null)
            {
                lbTitle.Text = "Editar transação";
                this.Account.Id = account.Id;
                this.Account.EmpresaId = account.EmpresaId;
                this.Account.TipoConta = account.TipoConta;
                this.Account.CategoriaContaId = account.CategoriaContaId;
                this.Account.FormaCobrancaId = account.FormaCobrancaId;
                this.Account.CentroResponsabilidadeId = account.CentroResponsabilidadeId;
                this.Account.FormaPagamentoId = account.FormaPagamentoId;
                this.Account.ContaBancoId = account.ContaBancoId;
                this.Account.DataPagamento = account.DataPagamento;
                this.Account.DataVencimento = account.DataVencimento;
                this.Account.Historico = account.Historico;
                this.Account.Valor = account.ValorBruto.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                this.Account.ValorMulta = account.ValorMulta.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                this.Account.ValorDesconto = account.ValorDesconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                this.Account.Status = account.Status;
                if (this.Account.FormaPagamentoId != 0)
                    FormaPagamentoListPicker.SelectedItem = this.Parametros.FormaCobranca.ToList().Find(p => p.Id.Equals(this.Account.FormaPagamentoId));
                if (this.Account.CategoriaContaId != 0)
                    CategoriaContaListPicker.SelectedItem = this.Parametros.CategoriaConta.ToList().Find(p => p.Id.Equals(this.Account.CategoriaContaId));
                if (this.Account.CentroResponsabilidadeId != 0)
                    CentroResponsabilidadeListPicker.SelectedItem = this.Parametros.CentroResponsabilidade.ToList().Find(p => p.Id.Equals(this.Account.CentroResponsabilidadeId));
                if (this.Account.ContaBancoId != 0)
                    ContaBancoListPicker.SelectedItem = this.Parametros.ContaBanco.ToList().Find(p => p.Id.Equals(this.Account.ContaBancoId));
            }
            BindingContext = this;
        }

        private void FormaPagamentoListPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account.FormaPagamentoId = FormaPagamentoListPicker.SelectedItem != null ? (FormaPagamentoListPicker.SelectedItem as FormaCobranca).Id : 0;
            FormaCobrancaPicker.IsVisible = Account.FormaPagamentoId > 0;
        }

        private void CategoriaContaListPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account.CategoriaContaId = CategoriaContaListPicker.SelectedItem != null ? (CategoriaContaListPicker.SelectedItem as CategoriaConta).Id : 0;
            CategoriaContaPicker.IsVisible = Account.CategoriaContaId > 0;
        }

        private void CentroresponsabilidadeListPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account.CentroResponsabilidadeId = CentroResponsabilidadeListPicker.SelectedItem != null ? (CentroResponsabilidadeListPicker.SelectedItem as CentroResponsabilidade).Id : 0;
            CentroResponsabilidadePicker.IsVisible = Account.CentroResponsabilidadeId > 0;
        }

        private void ContaBancoListPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account.ContaBancoId = ContaBancoListPicker.SelectedItem != null ? (ContaBancoListPicker.SelectedItem as ContaBanco).Id : 0;
            ContaBancariaPicker.IsVisible = Account.ContaBancoId > 0;
        }

        private void InputDataVencimento_DateSelected(object sender, DateChangedEventArgs e)
        {
            Account.DataVencimento = InputDataVencimento.Date.ToString("yyyy-MM-dd");
            DataVencimentoDatePicker.IsVisible = !string.IsNullOrEmpty(Account.DataVencimento);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "InserirAccount", Account);
            await Navigation.PopAsync();
        }

        private void CustomEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            NomeTransacaoCustomEntry.IsVisible = ((CustomEntry)sender).Text.Length > 0;
        }

        private void valorPagoBool_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}