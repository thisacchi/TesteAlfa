using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace RDStation.Models
{
    [JsonObject]
    public class EmailContato
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}