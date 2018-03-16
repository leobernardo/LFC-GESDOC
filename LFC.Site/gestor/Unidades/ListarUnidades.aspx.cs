using System;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Unidades
{
    public partial class ListarUnidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UnidadeDAL uDAL = new UnidadeDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        Unidade u = uDAL.CarregarDadosPorIdUnidade(Convert.ToInt32(Request.QueryString["idUnd"]));
                        uDAL.Excluir(u);
                        Response.Write("<script language='JavaScript'>alert('A Unidade foi excluída com sucesso');location='ListarUnidades.aspx';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA AS UNIDADES //
                Unidades.DataSource = uDAL.Listar();
                Unidades.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarUnidade(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarUnidade.aspx"); }
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