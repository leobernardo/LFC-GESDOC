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
    public partial class VisualizarParceria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ParceriaDAL pDAL = new ParceriaDAL();
                    Parceria p = pDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idPrc"]));

                    litUnidade.Text = p.Unidade.Descricao;
                    litNome.Text = p.Nome;
                    litTipo.Text = p.Tipo;
                    litObjetivo.Text = p.Objetivo;
                    litObservacoes.Text = p.Observacoes;

                    if (p.EmExecucao)
                    { litEmExecucao.Text = "<span class=\"label label-success\">Sim</span>"; }
                    else
                    { litEmExecucao.Text = "<span class=\"label label-danger\">Não</span>"; }

                    if (p.PossuiPagamentoRH)
                    { litPossuiPagamentoRH.Text =  "<span class=\"label label-success\">Sim</span>"; }
                    else
                    { litPossuiPagamentoRH.Text = "<span class=\"label label-danger\">Não</span>"; }

                    if (p.PossuiRecursosFinanceiros)
                    {
                        litPossuiRecursosFinanceiros.Text = "<span class=\"label label-success\">Sim</span>";
                        litValorPrevistoAnual.Text = String.Format("{0:C}", p.ValorPrevistoAnual);
                        divValorPrevistoAnual.Visible = true;
                    }
                    else
                    { litPossuiRecursosFinanceiros.Text = "<span class=\"label label-danger\">Não</span>"; }

                    if (p.PossuiVigencia)
                    {
                        litPossuiVigencia.Text = "<span class=\"label label-success\">Sim</span>";
                        litVigencia.Text = "De " + p.InicioVigencia.ToShortDateString() + " até " + p.FimVigencia.ToShortDateString();
                        divVigencia.Visible = true;
                    }
                    else
                    { litPossuiVigencia.Text = "<span class=\"label label-danger\">Não</span>"; }

                    // LISTA OS REPASSES DA PARCERIA //
                    RepasseParceriaDAL rpDAL = new RepasseParceriaDAL();
                    rptRepassesParceria.DataSource = rpDAL.ListarPorParceria(Convert.ToInt32(Request.QueryString["idPrc"]));
                    rptRepassesParceria.DataBind();
                    // FIM //
                }
            }
            catch (Exception)
            { throw; }
        }

        protected string getDataRepasse(DateTime _DataRepasse)
        {
            try
            {
                if (_DataRepasse == Convert.ToDateTime("01/01/1900"))
                { return "<span class='text-red'>N/D</span>"; }
                else
                { return _DataRepasse.ToShortDateString(); }
            }
            catch (Exception)
            { throw; }
        }

        protected string getStatus(string _Status)
        {
            try
            {
                switch (_Status)
                {
                    case "pago":
                        return "<span class=\"label label-success\">Pago</span>";
                    case "pendente":
                        return "<span class=\"label label-danger\">Pendente</span>";
                    default:
                        return "";
                }
            }
            catch (Exception)
            { throw; }
        }
    }
}