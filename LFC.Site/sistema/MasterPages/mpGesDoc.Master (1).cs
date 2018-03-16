using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            }
            catch (Exception)
            { throw; }
        }
    }
}