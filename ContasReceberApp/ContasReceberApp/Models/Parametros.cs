using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ContasReceberApp.Models
{
    public class Parametros
    {
        [JsonProperty("formaCobranca")]
        public ObservableCollection<FormaCobranca> FormaCobranca
        { get; set; }

        [JsonProperty("categoriaConta")]
        public ObservableCollection<CategoriaConta> CategoriaConta
        { get; set; }

        [JsonProperty("centroResponsabilidade")]
        public ObservableCollection<CentroResponsabilidade> CentroResponsabilidade
        { get; set; }

        [JsonProperty("contaBanco")]
        public ObservableCollection<ContaBanco> ContaBanco
        { get; set; }
    }
}
