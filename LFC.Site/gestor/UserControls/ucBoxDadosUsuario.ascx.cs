using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.UserControls
{
    public partial class ucBoxDadosUsuario : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioDAL uDAL = new UsuarioDAL();
                Usuario u = uDAL.ObterDadosPorId(Convert.ToInt32(Session["sesIdUsuario"]));

                litNome.Text = u.DSNome;
                litEmail.Text = u.DSEmail;
                litNivelAcesso.Text = u.DSNivelAcesso;
                litProcesso.Text = u.Processo.DSProcesso;
            }
            catch (Exception)
            { throw; }
        }
    }
}