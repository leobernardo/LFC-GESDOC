using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Processos
{
    public partial class ListarProcessos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessoDAL pDAL = new ProcessoDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        Processo p = pDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idPrc"]));
                        pDAL.Excluir(p);
                        Response.Write("<script language='JavaScript'>alert('O Processo foi excluído com sucesso');location='ListarProcessos.aspx';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA OS PROCESSOS //
                Processos.DataSource = pDAL.Listar();
                Processos.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarProcesso(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarProcesso.aspx"); }
            catch (Exception)
            { throw; }
        }

        protected string getAtivo(bool _Ativo)
        {
            try
            {
                if (_Ativo)
                { return "<span class=\"label label-success\">Sim</span>"; }
                else
                { return "<span class=\"label label-danger\">Não</span>"; }
            }
            catch (Exception)
            { throw; }
        }
    }
}