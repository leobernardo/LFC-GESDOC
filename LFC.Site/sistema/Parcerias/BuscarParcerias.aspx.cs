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

                //// FILTRO PELO AR (S/N) //
                //if (radAR_N.Checked == true)
                //{ listaOficios = listaOficios.Where(arEF => arEF.BTAR == false); }
                //if (radAR_S.Checked == true)
                //{ listaOficios = listaOficios.Where(arEF => arEF.BTAR == true); }
                //// FIM //

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