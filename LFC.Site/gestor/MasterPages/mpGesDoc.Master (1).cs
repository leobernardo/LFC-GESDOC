using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.MasterPages
{
    public partial class mpGesDoc : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioDAL uDAL = new UsuarioDAL();
                Usuario u = uDAL.CarregarDadosPorIdUsuario(Convert.ToInt32(Session["sesIdUsuario"]));

                //// VALIDA O ACESSO //
                if (u.NivelAcesso != "administrador")
                { Response.Redirect("../Login.aspx"); }
                else
                { litEmail.Text = Session["sesEmail"].ToString(); }
                //// FIM //
            }
            catch (Exception)
            { throw; }
        }
    }
}