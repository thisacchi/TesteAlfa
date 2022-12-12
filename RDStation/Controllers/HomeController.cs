using RDStation.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RDStation.Models;
using System.Data;
using RDStation.Excel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDStation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarEmpresas()
        {
            TempData["Empresas"] = new EmpresaDados().GetEmpresas();

            return PartialView(TempData.Peek("Empresas") as RdStationResponse);
        }

        public ActionResult MostrarSegmentos(string id)
        {
            RdStationResponse response = TempData.Peek("Empresas") as RdStationResponse;
            Segmentos segmentos = new Segmentos();

            if (response != null)
            {
                Organizacao organizacao = response.Organizacoes.Find(o => o.Id == id);

                if (organizacao != null)
                    segmentos = organizacao.Segmentos;
            }

            return PartialView(segmentos);
        }

        public ActionResult MostrarContatos(string id)
        {
            RdStationResponse response = TempData.Peek("Empresas") as RdStationResponse;
            Contatos contatos = new Contatos();

            if (response != null)
            {
                Organizacao organizacao = response.Organizacoes.Find(o => o.Id == id);

                if (organizacao != null)
                    contatos = organizacao.Contatos;
            }

            return PartialView(contatos);
        }

        public ActionResult ExportarParaExcel()
        {
            RdStationResponse response = TempData.Peek("Empresas") as RdStationResponse;

            if (response != null)
            {
                #region :: Monta Retorno Dados

                DataTable dt = ExcelUtil.ConvertToDataTable(response);
                dt.TableName = "Empresas do Rd Station";
                #endregion :: Monta Retorno Dados

                #region :: Gera Arquivo Excel
                string fileName = $"Empresas{DateTime.Now.ToString("ddMMyyyy")}_{DateTime.Now.ToString("HHmmss")}.xls";
                string attachment = $"attachment; filename={fileName}";

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                #endregion :: Gera Arquivo Excel

                #region :: Monta Retorno Dados
                Formato sw = new Formato();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView gridExport = new GridView();

                gridExport.AutoGenerateColumns = true;
                gridExport.AllowPaging = false;
                gridExport.AllowSorting = true;

                gridExport.DataSource = dt;
                gridExport.DataBind();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < gridExport.HeaderRow.Cells.Count; i++)
                    {
                        gridExport.HeaderRow.Cells[i].BackColor = System.Drawing.Color.LightBlue;
                        gridExport.HeaderRow.Cells[i].Font.Bold = true;
                        gridExport.HeaderRow.Cells[i].Font.Size = FontUnit.Parse("10pt");
                        gridExport.HeaderRow.Cells[i].ForeColor = System.Drawing.Color.DarkBlue;
                        gridExport.HeaderRow.Cells[i].VerticalAlign = VerticalAlign.Middle;
                        gridExport.HeaderRow.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                    }

                    gridExport.RowStyle.Font.Bold = false;
                    gridExport.RowStyle.VerticalAlign = VerticalAlign.Middle;

                    gridExport.AlternatingRowStyle.Font.Bold = false;
                    gridExport.AlternatingRowStyle.VerticalAlign = VerticalAlign.Middle;

                    gridExport.RenderControl(hw);
                }
                #endregion :: Monta Retorno Dados

                #region :: Salva o Arquivo
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
                #endregion :: Salva o Arquivo
            }



            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}