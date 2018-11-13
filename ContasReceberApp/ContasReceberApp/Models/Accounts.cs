using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContasReceberApp.Models
{
    public class Account : ModelPrimary
    {
        [JsonProperty("companyId")]
        public int EmpresaId { get; set; } = 1036;

        [JsonProperty("accountType")]
        public string TipoConta { get; set; } = "R";

        [JsonProperty("accountCategoryId")]
        public int CategoriaContaId { get; set; }

        [JsonProperty("accountCategory")]
        public string CategoriaConta { get; set; }

        [JsonProperty("centerResponsabilityId")]
        public int CentroResponsabilidadeId { get; set; }

        [JsonProperty("centerResponsability")]
        public string CentroResponsabilidade { get; set; }

        [JsonProperty("paymentMethodId")]
        public int FormaPagamentoId { get; set; }

        [JsonProperty("paymentMethod")]
        public string FormaPagamento { get; set; }

        [JsonProperty("bankAccountId")]
        public int ContaBancoId { get; set; }

        [JsonProperty("bankAccount")]
        public string ContaBanco { get; set; }

        [JsonProperty("billingMethodId")]
        public int FormaCobrancaId { get; set; }

        [JsonProperty("billingMethod")]
        public string FormaCobranca { get; set; }

        [JsonProperty("dateCredit")]
        public string DataPagamento { get; set; }

        [JsonProperty("expirationDate")]
        public string DataVencimento { get; set; }

        [JsonProperty("title")]
        public string Historico { get; set; }

        [JsonProperty("grossValue")]
        public decimal ValorBruto { get; set; }

        [JsonProperty("netValue")]
        public decimal ValorLiquido { get; set; }

        [JsonProperty("penaltyValue")]
        public decimal ValorMulta { get; set; }

        [JsonProperty("discountValue")]
        public decimal ValorDesconto { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}
