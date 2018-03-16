using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;

namespace LFC.GesDoc.Site.sistema.Documentos
{
    public partial class ListarDocumentosReceber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // LISTA OS DOCUMENTOS A RECEBER //
                MovimentacaoDAL mDAL = new MovimentacaoDAL();
                DocumentosReceber.DataSource = mDAL.ListarPorProcessoDestinoRecebido(Convert.ToInt32(Session["sesIdProcesso"]), "Não");
                DocumentosReceber.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void ReceberSelecionados(object sender, EventArgs e)
        {
            try
            {
                string f = Request.Form["chkDocumentos"];
                string[] documentos = f.Split(',');

                foreach (string documento in documentos)
                {
                    DocumentoDAL dDAL = new DocumentoDAL();
                    dDAL.Receber(Convert.ToInt32(documento));
                }

                Response.Write("<script language='JavaScript'>alert('Documento(s) recebido(s) com sucesso');window.parent.location='../Home/Default.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}