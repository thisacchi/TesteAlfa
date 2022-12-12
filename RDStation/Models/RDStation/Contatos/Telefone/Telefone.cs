using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace RDStation.Models
{
    [JsonObject]
    public class Telefone
    {
        [JsonProperty("phone")]
        public string NroTelefone { get; set; }
        [JsonProperty("type")]
        public string Tipo { get; set; }
    }

    public static class TelefoneTipos
    {
        public static string Work = "work";
    }
}