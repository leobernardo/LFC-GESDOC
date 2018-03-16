using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;

namespace LFC.GesDoc.Site.sistema.Documentos
{
    public partial class HistoricoDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DocumentoDAL dDAL = new DocumentoDAL();
                MovimentacaoDAL mDAL = new MovimentacaoDAL();

                lblDescricao.Text = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(Request.QueryString["idDoc"])).Descricao;

                rptHistoricoDocumento.DataSource = mDAL.ListarPorIdDocumento(Convert.ToInt32(Request.QueryString["idDoc"]));
                rptHistoricoDocumento.DataBind();
            }
            catch (Exception)
            { throw; }
        }

        protected string getProcesso(Int32 _IdProcesso)
        {
            try
            {
                ProcessoDAL pDAL = new ProcessoDAL();

                return pDAL.CarregarDadosPorIdProcesso(_IdProcesso).Nome;
            }
            catch (Exception)
            { throw; }
        }

        protected string getRecebido(String _Recebido)
        {
            try
            {
                switch (_Recebido)
                {
                    case "Não":
                        return "<span class=\"label label-danger\">Não</span>";
                    case "Sim":
                        return "<span class=\"label label-success\">Sim</span>";
                    default:
                        return "";
                }
            }
            catch (Exception)
            { throw; }
        }
    }
}