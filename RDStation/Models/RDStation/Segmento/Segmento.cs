using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace RDStation.Models
{
    [JsonObject]
    public class Segmento
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Nome { get; set; }
        [JsonProperty("integration_id")]
        public string IntegrationId { get; set; }
        [JsonProperty("created_at")]
        public DateTime DataCriacao { get; set; }
        [JsonProperty("updated_at")]
        public DateTime DataAtualizacao { get; set; }
    }
}