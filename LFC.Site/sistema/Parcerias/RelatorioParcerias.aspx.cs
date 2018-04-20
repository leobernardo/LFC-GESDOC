using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.sistema.Parcerias
{
    public partial class RelatorioParcerias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    // PREENCHE O ANO //
                    //ddlAno.DataSource = Util.preencheAno(2008, DateTime.Now.Year);
                    //ddlAno.SelectedValue = Convert.ToString(Util.ObterAno());
                    //ddlAno.DataBind();
                    // FIM //

                    //if (!string.IsNullOrEmpty(Request.QueryString["ano"]))
                    //{
                    //    ParceriaDAL pDAL = new ParceriaDAL();
                    //    RepasseParceriaDAL rpDAL = new RepasseParceriaDAL();
                    //    UnidadeDAL uDAL = new UnidadeDAL();
                    //    var unidades = uDAL.Listar();

                    //    litRelatorio.Text += "<table class=\"table table-bordered table-striped\">";

                    //    foreach (Unidade unidade in unidades)
                    //    {
                    //        var parcerias = pDAL.ListarPorUnidade(unidade.IdUnidade);

                    //        if (parcerias.Count > 0)
                    //        {
                    //            litRelatorio.Text += "<tr>";
                    //            litRelatorio.Text += "<td colspan=\"4\"><b>" + unidade.Descricao + "</b></td>";
                    //            litRelatorio.Text += "</tr>";

                    //            litRelatorio.Text += "<tr>";
                    //            litRelatorio.Text += "<td><b>Nome</b></td>";
                    //            litRelatorio.Text += "<td><b>Total de repasses</b></td>";
                    //            litRelatorio.Text += "<td><b>Repasses pagos</b></td>";
                    //            litRelatorio.Text += "<td><b>Repasses pendentes</b></td>";
                    //            litRelatorio.Text += "</tr>";

                    //            foreach (Parceria parceria in parcerias)
                    //            {
                    //                litRelatorio.Text += "<tr>";
                    //                litRelatorio.Text += "<td style=\"padding-left:20px;\">" + parceria.Nome + "</td>";

                    //                var repasses = (List<RepasseParceria>)rpDAL.ListarPorParceria(parceria.IdParceria);

                    //                decimal decTotalRepasses, decTotalRepassesPagos, decTotalRepassesPendentes;
                    //                decTotalRepasses = repasses.Where(dEF => Convert.ToDateTime(dEF.DataRepasse).Year == Convert.ToInt32(Request.QueryString["ano"])).Sum(vEF => vEF.ValorRepasse);
                    //                decTotalRepassesPagos = repasses.Where(dEF => Convert.ToDateTime(dEF.DataRepasse).Year == Convert.ToInt32(Request.QueryString["ano"])).Where(sEF => sEF.Status == "pago").Sum(vEF => vEF.ValorRepasse);
                    //                decTotalRepassesPendentes = repasses.Where(dEF => Convert.ToDateTime(dEF.DataRepasse).Year == Convert.ToInt32(Request.QueryString["ano"])).Where(sEF => sEF.Status == "pendente").Sum(vEF => vEF.ValorRepasse);

                    //                litRelatorio.Text += "<td>" + String.Format("{0:C}", decTotalRepasses) + "</td>";
                    //                litRelatorio.Text += "<td>" + String.Format("{0:C}", decTotalRepassesPagos) + "</td>";
                    //                litRelatorio.Text += "<td>" + String.Format("{0:C}", decTotalRepassesPendentes) + "</td>";
                    //                litRelatorio.Text += "</tr>";
                    //            }
                    //        }
                    //    }

                    //    litRelatorio.Text += "</table>";
                    //}
                }
            }
            catch (Exception)
            { throw; }
        }

        //protected void selecionaAno(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ddlAno.Items[ddlAno.SelectedIndex].Value != "")
        //        { Response.Redirect("RelatorioParcerias.aspx?ano=" + ddlAno.Items[ddlAno.SelectedIndex].Value, false); }
        //    }
        //    catch (Exception)
        //    { throw; }
        //}

        protected void GerarRelatorio(object sender, EventArgs e)
        {
            try
            {
                ParceriaDAL pDAL = new ParceriaDAL();
                RepasseParceriaDAL rpDAL = new RepasseParceriaDAL();
                UnidadeDAL uDAL = new UnidadeDAL();
                var unidades = uDAL.Listar();

                litRelatorio.Text = string.Empty;
                litRelatorio.Text += "<table class=\"table table-bordered table-striped\">";

                foreach (Unidade unidade in unidades)
                {
                    var parcerias = (List<Parceria>)pDAL.ListarPorUnidade(unidade.IdUnidade);
                    parcerias = parcerias.ToList();

                    // FILTRO PELO PAGAMENTO DE RH (S/N) //
                    if (radPossuiPagamentoRH_N.Checked == true)
                    { parcerias = parcerias.Where(rh => rh.PossuiPagamentoRH == false).ToList(); }
                    if (radPossuiPagamentoRH_S.Checked == true)
                    { parcerias = parcerias.Where(rh => rh.PossuiPagamentoRH == true).ToList(); }
                    // FIM //

                    if (parcerias.Count > 0)
                    {
                        litRelatorio.Text += "<tr>";
                        litRelatorio.Text += "<td colspan=\"4\"><b>" + unidade.Descricao + " - " + parcerias.Count + " parceria(s)</b></td>";
                        litRelatorio.Text += "</tr>";

                        litRelatorio.Text += "<tr>";
                        litRelatorio.Text += "<td><b>Nome</b></td>";
                        litRelatorio.Text += "<td><b>Total de repasses</b></td>";
                        litRelatorio.Text += "<td><b>Repasses pagos</b></td>";
                        litRelatorio.Text += "<td><b>Repasses pendentes</b></td>";
                        litRelatorio.Text += "</tr>";

                        foreach (Parceria parceria in parcerias)
                        {
                            var repasses = (List<RepasseParceria>)rpDAL.ListarPorParceria(parceria.IdParceria);

                            decimal decTotalRepasses, decTotalRepassesPagos, decTotalRepassesPendentes;

                            decTotalRepasses = repasses
                                //.Where(d => Convert.ToDateTime(d.DataRepasse).Year == Convert.ToInt32(Request.QueryString["ano"]))
                                .Sum(v => v.ValorRepasse);

                            decTotalRepassesPagos = repasses
                                //.Where(dEF => Convert.ToDateTime(dEF.DataRepasse).Year == Convert.ToInt32(Request.QueryString["ano"]))
                                .Where(sEF => sEF.Status == "pago")
                                .Sum(vEF => vEF.ValorRepasse);

                            decTotalRepassesPendentes = repasses
                                //.Where(dEF => Convert.ToDateTime(dEF.DataRepasse).Year == Convert.ToInt32(Request.QueryString["ano"]))
                                .Where(sEF => sEF.Status == "pendente")
                                .Sum(vEF => vEF.ValorRepasse);

                            litRelatorio.Text += "<tr>";
                            litRelatorio.Text += "<td style=\"padding-left:20px;\">" + parceria.Nome + "</td>";
                            litRelatorio.Text += "<td>" + String.Format("{0:C}", decTotalRepasses) + "</td>";
                            litRelatorio.Text += "<td>" + String.Format("{0:C}", decTotalRepassesPagos) + "</td>";
                            litRelatorio.Text += "<td>" + String.Format("{0:C}", decTotalRepassesPendentes) + "</td>";
                            litRelatorio.Text += "</tr>";
                        }
                    }
                }

                litRelatorio.Text += "</table>";
            }
            catch (Exception)
            { throw; }
        }
    }
}