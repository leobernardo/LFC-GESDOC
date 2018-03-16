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
                Usuario u = uDAL.CarregarDadosPorIdUsuario(Convert.ToInt32(Session["sesIdUsuario"]));

                litNome.Text = u.Nome;
                litEmail.Text = u.Email;
                litNivelAcesso.Text = u.NivelAcesso;
                litProcesso.Text = u.Processo.Nome;
            }
            catch (Exception)
            { throw; }
        }
    }
}