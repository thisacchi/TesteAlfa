using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using RDStation.Models;
using RDStation.Utils;
using RestSharp;

namespace RDStation.Dados
{
    public class EmpresaDados
    {
        private string Token = "63967ff5955d440026462435";

        public RdStationResponse GetEmpresas()
        {
            RdStationResponse retorno = new RdStationResponse();

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string url = $"https://crm.rdstation.com/api/v1/organizations?token={Token}";
                RestClient restClient = new RestClient(url);
                RestRequest restRequest = new RestRequest(Method.GET);

                var restResponse = restClient.Execute(restRequest);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    retorno = JsonUtil.ConverterJsonParaObjeto<RdStationResponse>(restResponse.Content);
                    retorno.Sucesso = true;
                }
                else
                {
                    retorno.Sucesso = false;
                    retorno.MensagemErro = "Não foi possível realizar encontrar os dados da empresa!!";
                }                
                
            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;
                retorno.MensagemErro = ex.Message;
            }

            return retorno;
        }
    }
}