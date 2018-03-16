using System;
using System.Reflection;

namespace LFC.GesDoc.Site.sistema.MasterPages
{
    public partial class mpGesDoc : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // VALIDA O ACESSO //
                if (Session["sesIdUsuario"] == null)
                { Response.Redirect("../Login.aspx"); }
                else
                { litEmail.Text = Session["sesEmail"].ToString().Replace("@lfc.org.br", ""); }
                // FIM //

                Assembly assembly = Assembly.GetExecutingAssembly();
                litVersao.Text = assembly.GetName().Version.ToString();
            }
            catch (Exception)
            { throw; }
        }
    }
}