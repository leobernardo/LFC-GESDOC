using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Usuarios
{
    public partial class ListarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioDAL uDAL = new UsuarioDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        Usuario u = uDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idUsr"]));
                        uDAL.Excluir(u);
                        Response.Write("<script language='JavaScript'>alert('O Usuário foi excluído com sucesso');location='ListarUsuarios.aspx';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA OS USUÁRIOS //
                Usuarios.DataSource = uDAL.Listar();
                Usuarios.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarUsuario(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarUsuario.aspx"); }
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