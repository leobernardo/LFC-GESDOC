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
                Usuario u = uDAL.CarregarDadosPorIdUsuario(Convert.ToInt32(Session["sesIdUsuario"]));

                litNome.Text = u.Nome;
                litEmail.Text = u.Email;
                litProcesso.Text = pDAL.CarregarDadosPorIdProcesso(u.Processo.IdProcesso).Nome;
                litNivelAcesso.Text = u.NivelAcesso;
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