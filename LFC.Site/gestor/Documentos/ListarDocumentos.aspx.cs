using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Documentos
{
    public partial class ListarDocumentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DocumentoDAL dDAL = new DocumentoDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        Documento d = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(Request.QueryString["idDoc"]));
                        dDAL.Excluir(d);
                        Response.Write("<script language='JavaScript'>alert('O Documento foi excluído com sucesso');location='ListarDocumentos.aspx';</script>");
                        break;
                    case "rcv":
                        dDAL.Receber(Convert.ToInt32(Request.QueryString["idDoc"]));
                        Response.Write("<script language='JavaScript'>alert('O Documento foi recebido com sucesso');location='ListarDocumentos.aspx';</script>");
                        break;
                    default:
                        break;
                }

                if (!Page.IsPostBack)
                {
                    // PREENCHE OS TIPOS DE DOCUMENTOS //
                    TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();
                    ddlTipoDocumento.DataSource = tdDAL.Listar();
                    ddlTipoDocumento.DataBind();
                    if (Request.QueryString["idTpd"] == null)
                    { ddlTipoDocumento.Items.Insert(0, (new ListItem("Selecione o tipo de documento", ""))); }
                    else
                    { ddlTipoDocumento.SelectedValue = Request.QueryString["idTpd"]; }
                    // FIM //
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void selecionaTipoDocumento(object sender, EventArgs e)
        {
            try
            {
                if (ddlTipoDocumento.Items[ddlTipoDocumento.SelectedIndex].Value != "")
                { Response.Redirect("ListarDocumentos.aspx?idTpd=" + ddlTipoDocumento.Items[ddlTipoDocumento.SelectedIndex].Value); }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}