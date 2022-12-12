using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace RDStation.Models
{
    [JsonObject]
    public class Organizacao
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Nome { get; set; }
        [JsonProperty("resume")]
        public string Resumo { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("won_count")]
        public int QuantiaGanhos { get; set; }
        [JsonProperty("lost_count")]
        public int QuantiaPerdas { get; set; }
        [JsonProperty("opened_count")]
        public int QuantiaAbertos { get; set; }
        [JsonProperty("paused_count")]
        public int QuantiaPausada { get; set; }
        [JsonProperty("created_at")]
        public DateTime DataCriacao { get; set; }
        [JsonProperty("updated_at")]
        public DateTime DataAtualizacao { get; set; }
        [JsonProperty("organization_segments")]
        public Segmentos Segmentos { get; set; }
        [JsonProperty("user")]
        public Usuario Usuario { get; set; }
        [JsonProperty("contacts")]
        public Contatos Contatos { get; set; }

        public Organizacao()
        {
            Segmentos = new Segmentos();
            Usuario = new Usuario();
            Contatos = new Contatos();
        }
    }
}