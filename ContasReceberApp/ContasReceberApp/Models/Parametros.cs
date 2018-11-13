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

        public static List<string> ListarNomeFormaCobranca(ObservableCollection<FormaCobranca> lista)
        {
            List<string> list = new List<string>();
            foreach (var item in lista)
                list.Add(item.Nome);
            return list;
        }

        public static List<string> ListarNomeCategoriaConta(ObservableCollection<CategoriaConta> lista)
        {
            List<string> list = new List<string>();
            foreach (var item in lista)
                list.Add(item.Nome);
            return list;
        }

        public static List<string> ListarNomeCentroResponsabilidade(ObservableCollection<CentroResponsabilidade> lista)
        {
            List<string> list = new List<string>();
            foreach (var item in lista)
                list.Add(item.Nome);
            return list;
        }

        public static List<string> ListarNomeContaBanco(ObservableCollection<ContaBanco> lista)
        {
            List<string> list = new List<string>();
            foreach (var item in lista)
                list.Add(item.Nome);
            return list;
        }
    }
}
