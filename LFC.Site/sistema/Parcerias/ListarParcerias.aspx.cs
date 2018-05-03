using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.sistema.Parcerias
{
    public partial class ListarParcerias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ParceriaDAL pDAL = new ParceriaDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        Parceria p = pDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idPrc"]));

                        string strCaminho = Server.MapPath(@"../../arquivos/parcerias/");

                        if (File.Exists(strCaminho + p.ArquivoAnexo))
                        { File.Delete(strCaminho + p.ArquivoAnexo); }

                        pDAL.Excluir(p);
                        Response.Write("<script language='JavaScript'>alert('A Parceria foi excluída com sucesso');location='ListarParcerias.aspx?idUnd=" + p.Unidade.IdUnidade + "';</script>");
                        break;
                    default:
                        break;
                }

                if (!Page.IsPostBack)
                {
                    // PREENCHE AS UNIDADES //
                    UnidadeDAL uDAL = new UnidadeDAL();
                    ddlUnidade.DataSource = uDAL.Listar();
                    ddlUnidade.DataBind();
                    if (Request.QueryString["idUnd"] == null)
                    { ddlUnidade.Items.Insert(0, (new ListItem("Selecione a unidade", ""))); }
                    else
                    {
                        ddlUnidade.SelectedValue = Request.QueryString["idUnd"];

                        // LISTA AS PARCERIAS //
                        Parcerias.DataSource = pDAL.ListarPorUnidade(Convert.ToInt32(Request.QueryString["idUnd"]));
                        Parcerias.DataBind();
                        // FIM //
                    }
                    // FIM //
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void selecionaUnidade(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnidade.Items[ddlUnidade.SelectedIndex].Value != "")
                { Response.Redirect("ListarParcerias.aspx?idUnd=" + ddlUnidade.Items[ddlUnidade.SelectedIndex].Value); }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void CadastrarParceria(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarParceria.aspx"); }
            catch (Exception)
            { throw; }
        }

        protected string getEmExecucao(bool _EmExecucao)
        {
            try
            {
                if (_EmExecucao)
                { return "<span class=\"label label-success\">Sim</span>"; }
                else
                { return "<span class=\"label label-danger\">Não</span>"; }
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