using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RDStation.Models
{
    [JsonArray]
    public class Emails : List<EmailContato>
    {
    }
}