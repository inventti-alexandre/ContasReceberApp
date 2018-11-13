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
            CategoriaContaListPicker.ItemsSource = Parametros.ListarNomeCategoriaConta(Parametros.CategoriaConta);
            FormaPagamentoListPicker.ItemsSource = Parametros.ListarNomeFormaCobranca(Parametros.FormaCobranca);
            CentroResponsabilidadeListPicker.ItemsSource = Parametros.ListarNomeCentroResponsabilidade(Parametros.CentroResponsabilidade);
            ContaBancoListPicker.ItemsSource = Parametros.ListarNomeContaBanco(Parametros.ContaBanco);
            Account.DataVencimento = InputDataVencimento.Date.ToString("yyyy-MM-dd");
            this.Parametros = Parametros;
            //Verifica se conta esta em alteração
            if (account != null)
            {
                this.Title = "Editar Conta";
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
                this.Account.Valor = account.ValorBruto;
                this.Account.ValorMulta = account.ValorMulta;
                this.Account.ValorDesconto = account.ValorDesconto;
                this.Account.Status = account.Status;
                if (this.Account.FormaPagamentoId != 0)
                    FormaPagamentoListPicker.SelectedItem = this.Parametros.FormaCobranca.ToList().Find(p => p.Id.Equals(this.Account.FormaPagamentoId)).Nome;
                if (this.Account.CategoriaContaId != 0)
                    CategoriaContaListPicker.SelectedItem = this.Parametros.CategoriaConta.ToList().Find(p => p.Id.Equals(this.Account.CategoriaContaId)).Nome;
                if (this.Account.CentroResponsabilidadeId != 0)
                    CentroResponsabilidadeListPicker.SelectedItem = this.Parametros.CentroResponsabilidade.ToList().Find(p => p.Id.Equals(this.Account.CentroResponsabilidadeId)).Nome;
                if (this.Account.ContaBancoId != 0)
                    ContaBancoListPicker.SelectedItem = this.Parametros.ContaBanco.ToList().Find(p => p.Id.Equals(this.Account.ContaBancoId)).Nome;
            }
            else
                this.Title = "Inserir Conta";
            BindingContext = this;
        }

        private void FormaPagamentoListPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
           Account.FormaPagamentoId = this.Parametros.FormaCobranca.ToList().Find(p=> p.Nome.Equals(FormaPagamentoListPicker.SelectedItem.ToString())).Id;
        }

        private void CategoriaContaListPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account.CategoriaContaId = this.Parametros.CategoriaConta.ToList().Find(p => p.Nome.Equals(CategoriaContaListPicker.SelectedItem.ToString())).Id;
        }

        private void CentroresponsabilidadeListPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account.CentroResponsabilidadeId = this.Parametros.CentroResponsabilidade.ToList().Find(p => p.Nome.Equals(CentroResponsabilidadeListPicker.SelectedItem.ToString())).Id;
        }

        private void ContaBancoListPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account.ContaBancoId = this.Parametros.ContaBanco.ToList().Find(p => p.Nome.Equals(ContaBancoListPicker.SelectedItem.ToString())).Id;
        }

        private void InputDataVencimento_DateSelected(object sender, DateChangedEventArgs e)
        {
            Account.DataVencimento = InputDataVencimento.Date.ToString("yyyy-MM-dd");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "InserirAccount", Account);
            await Navigation.PopAsync();
        }
    }
}