using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContasReceberApp.Models
{
    public class AccountInsert : ModelPrimary
    {
        [JsonProperty("empresaId")]
        public int EmpresaId { get; set; } = 1036;

        [JsonProperty("tipoConta")]
        public string TipoConta { get; set; } = "R";

        [JsonProperty("categoriaContaId")]
        public int CategoriaContaId { get; set; }

        [JsonProperty("formaCobrancaId")]
        public int? FormaCobrancaId { get; set; } = null;

        [JsonProperty("centroResponsabilidadeId")]
        public int CentroResponsabilidadeId { get; set; }

        [JsonProperty("formaPagamentoId")]
        public int FormaPagamentoId { get; set; }

        [JsonProperty("contaBancoId")]
        public int ContaBancoId { get; set; }

        [JsonProperty("dataPagamento")]
        public string DataPagamento { get; set; }

        [JsonProperty("dataVencimento")]
        public string DataVencimento { get; set; }

        [JsonProperty("historico")]
        public string Historico { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("valorPago")]
        public decimal ValorPago { get; set; }

        [JsonProperty("valorMulta")]
        public decimal ValorMulta { get; set; }

        [JsonProperty("valorDesconto")]
        public decimal ValorDesconto { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}
