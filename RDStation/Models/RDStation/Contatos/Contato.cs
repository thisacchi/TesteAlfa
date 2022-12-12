using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace RDStation.Models
{
    [JsonObject]
    public class Contato
    {
        [JsonProperty("name")]
        public string Nome { get; set; }
        [JsonProperty("title")]
        public string Titulo { get; set; }
        [JsonProperty("emails")]
        public Emails Emails { get; set; }
        [JsonProperty("phones")]
        public Telefones Telefontes { get; set; }
    }
}