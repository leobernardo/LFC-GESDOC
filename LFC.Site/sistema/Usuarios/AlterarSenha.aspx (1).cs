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
    public partial class AlterarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Alterar(object sender, EventArgs e)
        {
            try
            {
                UsuarioDAL uDAL = new UsuarioDAL();
                Usuario u = uDAL.CarregarDadosPorIdUsuario(Convert.ToInt32(Session["sesIdUsuario"]));

                u.Senha = txtSenhaNova.Text;

                uDAL.Alterar(u);

                Response.Write("<script language='JavaScript'>alert('Senha alterada com sucesso');window.parent.location='VisualizarPerfil.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}