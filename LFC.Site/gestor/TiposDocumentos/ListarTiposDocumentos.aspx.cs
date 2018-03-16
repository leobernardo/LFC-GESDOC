using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.TiposDocumentos
{
    public partial class ListarTiposDocumentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        TipoDocumento td = tdDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idTpd"]));
                        tdDAL.Excluir(td);
                        Response.Write("<script language='JavaScript'>alert('O Tipo de Documento foi excluído com sucesso');location='ListarTiposDocumentos.aspx';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA OS TIPOS DE DOCUMENTOS //
                TiposDocumentos.DataSource = tdDAL.Listar();
                TiposDocumentos.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarTipoDocumento(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarTipoDocumento.aspx"); }
            catch (Exception)
            { throw; }
        }
    }
}