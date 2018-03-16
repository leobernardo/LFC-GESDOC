using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;

namespace LFC.GesDoc.Site.sistema.Documentos
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
                    case "rcv":
                        dDAL.Receber(Convert.ToInt32(Request.QueryString["idDoc"]));
                        Response.Write("<script language='JavaScript'>alert('O Documento foi recebido com sucesso');location='ListarDocumentos.aspx';</script>");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            { throw; }
        }
    }
}