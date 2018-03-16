using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;

namespace LFC.GesDoc.Site.sistema.Home
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DocumentoDAL dDAL = new DocumentoDAL();
                MovimentacaoDAL mDAL = new MovimentacaoDAL();

                litDocumentosProcesso.Text = dDAL.ListarPorIdProcesso(Convert.ToInt32(Session["sesIdProcesso"])).Count.ToString();
                litDocumentosReceber.Text = mDAL.ListarPorProcessoDestinoRecebido(Convert.ToInt32(Session["sesIdProcesso"]), "Não").Count.ToString();
                litDocumentosArquivados.Text = dDAL.ListarPorIdProcessoArquivado(Convert.ToInt32(Session["sesIdProcesso"]), "1").Count.ToString();
            }
            catch (Exception)
            { throw; }
        }
    }
}