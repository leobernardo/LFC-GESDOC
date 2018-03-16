using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;

namespace LFC.GesDoc.Site.sistema.Documentos
{
    public partial class ListarDocumentosArquivados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["act"] == "dsr")
                {
                    DocumentoDAL dDAL = new DocumentoDAL();
                    dDAL.Desarquivar(Convert.ToInt32(Request.QueryString["idDoc"]));

                    Response.Write("<script language='JavaScript'>alert('O Documento foi desarquivado com sucesso');location='ListarDocumentosArquivados.aspx';</script>");
                }
            }
            catch (Exception)
            { throw; }
        }
    }
}