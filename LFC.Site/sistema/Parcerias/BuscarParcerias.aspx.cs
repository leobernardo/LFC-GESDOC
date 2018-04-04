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
    public partial class BuscarParcerias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // PREENCHE AS UNIDADES //
                UnidadeDAL uDAL = new UnidadeDAL();
                ddlUnidade.DataSource = uDAL.Listar();
                ddlUnidade.DataBind();
                ddlUnidade.Items.Insert(0, (new ListItem("-- TODAS --", "")));
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

                // FILTRO PAGAMENTO DE RH (S/N) //
                if (radPossuiPagamentoRH_N.Checked == true)
                { listaParcerias = listaParcerias.Where(rhEF => rhEF.PossuiPagamentoRH == false).ToList(); }
                if (radPossuiPagamentoRH_S.Checked == true)
                { listaParcerias = listaParcerias.Where(rhEF => rhEF.PossuiPagamentoRH == true).ToList(); }
                // FIM //

                // FILTRO RECURSOS FINANCEIROS (S/N) //
                if (radPossuiRecursosFinanceiros_N.Checked == true)
                { listaParcerias = listaParcerias.Where(rfEF => rfEF.PossuiRecursosFinanceiros == false).ToList(); }
                if (radPossuiRecursosFinanceiros_S.Checked == true)
                { listaParcerias = listaParcerias.Where(rfEF => rfEF.PossuiRecursosFinanceiros == true).ToList(); }
                // FIM //

                // FILTRO VIGÊNCIA DETERMINADA (S/N) //
                if (radPossuiVigencia_N.Checked == true)
                { listaParcerias = listaParcerias.Where(vEF => vEF.PossuiVigencia == false).ToList(); }
                if (radPossuiVigencia_S.Checked == true)
                { listaParcerias = listaParcerias.Where(vEF => vEF.PossuiVigencia == true).ToList(); }
                // FIM //

                Parcerias.DataSource = listaParcerias;
                Parcerias.DataBind();

                divResultadoBusca.Visible = true;
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