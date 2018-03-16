using System;
using System.Reflection;

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
                Usuario u = uDAL.ObterDadosPorId(Convert.ToInt32(Session["sesIdUsuario"]));

                // VALIDA O ACESSO //
                if (u.DSNivelAcesso != "administrador")
                { Response.Redirect("../Login.aspx"); }
                else
                { litEmail.Text = Session["sesEmail"].ToString(); }
                // FIM //

                Assembly assembly = Assembly.GetExecutingAssembly();
                litVersao.Text = assembly.GetName().Version.ToString();
            }
            catch (Exception)
            { throw; }
        }
    }
}