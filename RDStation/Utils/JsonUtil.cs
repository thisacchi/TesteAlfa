using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace RDStation.Utils
{
    public class JsonUtil
    {
        public static T ConverterJsonParaObjeto<T>(string json)
        {
            T retorno;

            try
            {
                retorno = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ConverterJsonException)
            {
                throw ConverterJsonException;
            }

            return retorno;
        }
    }
}