using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using RDStation.Models;

namespace RDStation.Excel
{
    public class ExcelUtil
    {
        public static DataTable ConvertToDataTable(RdStationResponse response)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("CodigoCliente", typeof(string));
            dt.Columns.Add("Empresa", typeof(string));
            dt.Columns.Add("Resumo", typeof(string));
            dt.Columns.Add("URL", typeof(string));
            dt.Columns.Add("Segmento", typeof(string));
            dt.Columns.Add("Contato", typeof(string));
            dt.Columns.Add("Telefone", typeof(string));
            dt.Columns.Add("Email1", typeof(string));
            dt.Columns.Add("Email2", typeof(string));

            foreach(Organizacao organizacao in response.Organizacoes)
            {
                DataRow newRow = dt.NewRow();

                newRow["CodigoCliente"] = organizacao.Id;
                newRow["Empresa"] = organizacao.Nome;
                newRow["Resumo"] = organizacao.Resumo;
                newRow["URL"] = organizacao.Url;

                Segmento segmento = organizacao.Segmentos.FirstOrDefault();

                newRow["Segmento"] =  segmento.Nome;


                Contato contato = organizacao.Contatos.FirstOrDefault();

                newRow["Contato"] = contato.Nome;

                Telefone telefone = contato.Telefontes.FirstOrDefault();

                newRow["Telefone"] = telefone.NroTelefone;

                for (int i = 0; i < contato.Emails.Count; i++)
                {
                    EmailContato email = contato.Emails[i];

                    if (i <= 1)
                        newRow["Email" + (i + 1)] = email.Email;
                    else
                        break;
                }

                dt.Rows.Add(newRow);
                
            }


            return dt;
        }
    }

    public class Formato : StringWriter
    {
        public override Encoding Encoding
        {
            get
            {
                return ASCIIEncoding.ASCII;
            }
        }
    }
}