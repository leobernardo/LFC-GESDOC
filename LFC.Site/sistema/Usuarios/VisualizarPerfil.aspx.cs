using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.sistema.Usuarios
{
    public partial class VisualizarPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessoDAL pDAL = new ProcessoDAL();

                UsuarioDAL uDAL = new UsuarioDAL();
                Usuario u = uDAL.ObterDadosPorId(Convert.ToInt32(Session["sesIdUsuario"]));

                litNome.Text = u.DSNome;
                litEmail.Text = u.DSEmail;
                litProcesso.Text = pDAL.ObterDadosPorId(u.Processo.IDProcesso).DSProcesso;
                litNivelAcesso.Text = u.DSNivelAcesso;
            }
            catch (Exception)
            { throw; }
        }

        protected void AlterarSenha(object sender, EventArgs e)
        {
            Response.Redirect("AlterarSenha.aspx");
        }
    }
}