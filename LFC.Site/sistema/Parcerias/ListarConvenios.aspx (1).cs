using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Convenios
{
    public partial class ListarConvenios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ConvenioDAL cDAL = new ConvenioDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        Convenio c = cDAL.CarregarDadosPorIdConvenio(Convert.ToInt32(Request.QueryString["idCnv"]));
                        cDAL.Excluir(c);
                        Response.Write("<script language='JavaScript'>alert('O Convênio foi excluído com sucesso');location='ListarConvenios.aspx';</script>");
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
                    { ddlUnidade.Items.Insert(0, (new ListItem("", ""))); }
                    else
                    {
                        ddlUnidade.SelectedValue = Request.QueryString["idUnd"];

                        // LISTA OS CONVÊNIOS //
                        Convenios.DataSource = cDAL.ListarPorUnidade(Convert.ToInt32(Request.QueryString["idUnd"]));
                        Convenios.DataBind();
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
                { Response.Redirect("ListarConvenios.aspx?idUnd=" + ddlUnidade.Items[ddlUnidade.SelectedIndex].Value); }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}