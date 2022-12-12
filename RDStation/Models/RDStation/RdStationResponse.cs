using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace RDStation.Models
{
    [JsonObject]
    public class RdStationResponse
    {
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("has_more")]
        public bool ContemMais { get; set; }
        [JsonProperty("organizations")]
        public Organizacoes Organizacoes { get; set; }
        [JsonIgnore]
        public bool Sucesso { get; set; }
        [JsonIgnore]
        public string MensagemErro { get; set; }


        public RdStationResponse()
        {
            Organizacoes = new Organizacoes();
        }
    }
}