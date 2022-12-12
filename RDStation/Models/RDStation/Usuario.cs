using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace RDStation.Models
{
    [JsonObject]
    public class Usuario
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Nome { get; set; }
        [JsonProperty("nickname")]
        public string Apelido { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}