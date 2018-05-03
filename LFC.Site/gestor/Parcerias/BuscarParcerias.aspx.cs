using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Parcerias
{
    public partial class BuscarParcerias : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnExportarPDF.ServerClick += new EventHandler(ExportarPDF);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // PREENCHE AS UNIDADES //
                UnidadeDAL uDAL = new UnidadeDAL();
                ddlUnidade.DataSource = uDAL.Listar();
                ddlUnidade.DataBind();
                ddlUnidade.Items.Insert(0, (new System.Web.UI.WebControls.ListItem("-- TODAS --", "")));
                // FIM //

                divResultadoBusca.Visible = false;
            }
        }

        protected void Buscar(object sender, EventArgs e)
        {
            try
            {
                ParceriaDAL pDAL = new ParceriaDAL();

                string strNome, strTipo;

                //DateTime dtData;

                int intUnidade;

                var listaParcerias = (List<Parceria>)pDAL.Listar();
                listaParcerias = listaParcerias.ToList();

                // FILTRO PELA UNIDADE //
                if (ddlUnidade.SelectedValue != "")
                {
                    intUnidade = Convert.ToInt32(ddlUnidade.SelectedValue);
                    listaParcerias = listaParcerias.Where(uEF => uEF.Unidade.IdUnidade == intUnidade).ToList();
                }
                // FIM //

                // FILTRO PELO NOME //
                strNome = txtNome.Text;
                if (strNome != "")
                { listaParcerias = listaParcerias.Where(nEF => nEF.Nome.Contains(strNome.ToUpper())).ToList(); }
                // FIM //

                // FILTRO PELA TIPO //
                if (ddlTipo.SelectedValue != "")
                {
                    strTipo = ddlTipo.SelectedValue;

                    switch (strTipo)
                    {
                        case "Pública":
                            listaParcerias = listaParcerias.Where(tEF => tEF.Tipo == "Pública").ToList();
                            break;
                        case "Privada":
                            listaParcerias = listaParcerias.Where(tEF => tEF.Tipo == "Privada").ToList();
                            break;
                        default:
                            break;
                    }
                }
                // FIM //

                // FILTRO PELO PAGAMENTO DE RH (S/N) //
                if (radPossuiPagamentoRH_N.Checked == true)
                { listaParcerias = listaParcerias.Where(rh => rh.PossuiPagamentoRH == false).ToList(); }
                if (radPossuiPagamentoRH_S.Checked == true)
                { listaParcerias = listaParcerias.Where(rh => rh.PossuiPagamentoRH == true).ToList(); }
                // FIM //

                // FILTRO PELOS RECURSOS FINANCEIROS (S/N) //
                if (radPossuiRecursosFinanceiros_N.Checked == true)
                { listaParcerias = listaParcerias.Where(rf => rf.PossuiRecursosFinanceiros == false).ToList(); }
                if (radPossuiRecursosFinanceiros_S.Checked == true)
                { listaParcerias = listaParcerias.Where(rf => rf.PossuiRecursosFinanceiros == true).ToList(); }
                // FIM //

                // FILTRO PELA VIGÊNCIA DETERMINADA (S/N) //
                if (radPossuiVigencia_N.Checked == true)
                { listaParcerias = listaParcerias.Where(vd => vd.PossuiVigencia == false).ToList(); }
                if (radPossuiVigencia_S.Checked == true)
                { listaParcerias = listaParcerias.Where(vd => vd.PossuiVigencia == true).ToList(); }
                // FIM //

                // FILTRO PELA EXECUÇÃO (S/N) //
                if (radEmExecucao_N.Checked == true)
                { listaParcerias = listaParcerias.Where(ex => ex.EmExecucao == false).ToList(); }
                if (radEmExecucao_S.Checked == true)
                { listaParcerias = listaParcerias.Where(ex => ex.EmExecucao == true).ToList(); }
                // FIM //

                //// FILTRO PELO NÚMERO DO AR //
                //strNumeroAR = txtNumeroAR.Text;
                //if (strNumeroAR != "")
                //{ listaOficios = listaOficios.Where(arEF => arEF.BTAR == true).Where(nEF => nEF.NRAR == strNumeroAR); }
                //// FIM //

                //// FILTRO PELO SIGILOSO (S/N) //
                //if (radSigiloso_N.Checked == true)
                //{ listaDocumentos = listaDocumentos.Where(sEF => sEF.BTSigiloso == false); }
                //if (radSigiloso_S.Checked == true)
                //{ listaDocumentos = listaDocumentos.Where(sEF => sEF.BTSigiloso == true); }
                //// FIM //

                //// FILTRO PELO USUÁRIO //
                //if (ddlUsuario.SelectedValue != "")
                //{
                //    intUsuario = Convert.ToInt32(ddlUsuario.SelectedValue);
                //    listaDocumentos = listaDocumentos.Where(uEF => uEF.IDUsuario == intUsuario);
                //}
                //// FIM //

                //var joined = (from Item1 in listaDocumentos
                //              join Item2 in listaOficios
                //              on Item1.IDDocumento equals Item2.IDDocumento
                //              where Item1.IDEstado == SCAApplicationContext.Usuario.CodigoEstado
                //              select new { Item1.IDDocumento }).Distinct();

                Parcerias.DataSource = listaParcerias;
                Parcerias.DataBind();

                divResultadoBusca.Visible = true;
            }
            catch (Exception)
            { throw; }
        }

        protected void ExportarPDF(object sender, EventArgs e)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // DEFINE A FONTE //
                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                    Font fntCabecalho = new Font(bfTimes, 16, Font.NORMAL, BaseColor.BLACK);
                    Font fntPadrao = new Font(bfTimes, 10, Font.NORMAL, BaseColor.BLACK);
                    Font fntPadraoNegrito = new Font(bfTimes, 10, Font.BOLD, BaseColor.BLACK);
                    Font fntAssinatura = new Font(bfTimes, 12, Font.NORMAL, BaseColor.BLACK);
                    // FIM //

                    Document document = new Document(PageSize.A4.Rotate(), 15, 15, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(document, ms);

                    document.Open();

                    Response.Write("Foi [1]");
                    Response.End();

                    // LOGO DO DNPM //
                    //iTextSharp.text.Image imgTopo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("../img/") + "logoDocumentos.gif");
                    //imgTopo.ScalePercent(80);
                    //document.Add(imgTopo);
                    // FIM //

                    // CABEÇALHO //
                    Paragraph parCabecalho = new Paragraph("Relatório de Parcerias");
                    parCabecalho.Alignment = Element.ALIGN_CENTER;
                    document.Add(parCabecalho);
                    // FIM //

                    document.Add(new Paragraph("\n"));

                    // TABELA //
                    PdfPTable table = new PdfPTable(5);
                    table.TotalWidth = 700f;
                    table.LockedWidth = true;
                    float[] widths = new float[] { 300f, 130f, 100f, 100f, 70f };
                    table.SetWidths(widths);

                    table.AddCell(new Phrase("NOME", fntPadraoNegrito));
                    table.AddCell(new Phrase("A", fntPadraoNegrito));
                    table.AddCell(new Phrase("B", fntPadraoNegrito));
                    table.AddCell(new Phrase("C", fntPadraoNegrito));
                    table.AddCell(new Phrase("D", fntPadraoNegrito));

                    ParceriaDAL pDAL = new ParceriaDAL();

                    var parcerias = (List<Parceria>)pDAL.Listar();
                    parcerias = parcerias.ToList();

                    Int32 intCount = 1;

                    foreach (Parceria p in parcerias)
                    {
                        table.AddCell(new Phrase(p.Nome, fntPadrao));
                        table.AddCell(new Phrase("-", fntPadrao));
                        table.AddCell(new Phrase("-", fntPadrao));
                        table.AddCell(new Phrase("-", fntPadrao));
                        table.AddCell(new Phrase("-", fntPadrao));

                        //table.AddCell(new Phrase(String.Format("{0:C}", p.VLTotal), fntPadrao));

                        intCount = intCount + 1;
                    }

                    PdfPCell cell = new PdfPCell(new Phrase("TOTAL DE PARCERIAS: " + parcerias.Count(), fntPadrao));
                    cell.Colspan = 5;
                    cell.HorizontalAlignment = 0; //0=Left, 1=Center, 2=Right
                    table.AddCell(cell);

                    document.Add(table);
                    // FIM //

                    document.Close();
                    writer.Close();

                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ContentType = "pdf/application";
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=RelatorioParcerias.pdf");
                    HttpContext.Current.Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                }
            }
            catch (Exception)
            { throw; }
        }

        protected string getRecursosFinanceiros(bool _PossuiRecursosFinanceiros)
        {
            try
            {
                if (_PossuiRecursosFinanceiros)
                { return "<span class=\"label label-success\">Sim</span>"; }
                else
                { return "<span class=\"label label-danger\">Não</span>"; }
            }
            catch (Exception)
            { throw; }
        }

        protected string getVigente(bool _PossuiVigencia, DateTime _FimVigencia)
        {
            try
            {
                if (_PossuiVigencia)
                {
                    if (DateTime.Now <= _FimVigencia)
                    { return "<span class=\"label label-success\">Sim</span>"; }
                    else
                    { return "<span class=\"label label-danger\">Não</span>"; }
                }
                else
                { return "<span class=\"label label-primary\">N/D</span>"; }
            }
            catch (Exception)
            { throw; }
        }

        protected string getArquivo(string _Arquivo)
        {
            try
            {
                if (_Arquivo == "-")
                { return "<span class=\"label label-danger\">Não</span>"; }
                else
                { return "<span class=\"label label-success\">Sim</span>"; }
            }
            catch (Exception)
            { throw; }
        }

        protected string getOpcoes(int _IdParceria)
        {
            try
            {
                string strOpcoes = "";

                ParceriaDAL pDAL = new ParceriaDAL();
                Parceria p = pDAL.ObterDadosPorId(_IdParceria);

                strOpcoes += "<a href=\"../../arquivos/parcerias/" + _IdParceria + ".pdf\" target=\"_blank\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Visualizar Arquivo do Parceria\"><i class=\"fa fa-search\" style=\"margin-right:10px\"></i></a>";

                if (p.PossuiRecursosFinanceiros)
                { strOpcoes += "<a href=\"RepassesParceria.aspx?idPrc=" + _IdParceria + "\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Repasses da Parceria\"><i class=\"fa fa-dollar\" style=\"margin-right:10px\"></i></a>"; }

                strOpcoes += "<a href=\"AlterarParceria.aspx?idPrc=" + _IdParceria + "\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Alterar Parceria\"><i class=\"fa fa-edit\" style=\"margin-right:10px\"></i></a>";
                strOpcoes += "<a href=\"#\" onclick=\"return confirmaExclusao(this, " + _IdParceria + ");\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Excluir Parceria\"><i class=\"fa fa-trash\"></i></a>";

                return strOpcoes;
            }
            catch (Exception)
            { throw; }
        }
    }
}