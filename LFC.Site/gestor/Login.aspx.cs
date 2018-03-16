using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;

namespace LFC.GesDoc.Site.gestor
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["log"] == "0")
                {
                    Session["sesIdUsuario"] = null;
                    Session["sesIdProcesso"] = null;
                    Session["sesEmail"] = null;
                    Session["sesNivelAcesso"] = null;
                    Session.Abandon();

                    Response.Write("<script language='JavaScript'>alert('Usuário desconectado com sucesso');</script>");
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void Entrar(object sender, EventArgs e)
        {
            try
            {
                String strEmail, strSenha;

                strEmail = txtEmail.Text.Replace("'", "");
                strSenha = txtSenha.Text.Replace("'", "");

                UsuarioDAL uDAL = new UsuarioDAL();
                uDAL.Autenticar(strEmail, strSenha);
            }
            catch (Exception)
            { throw; }
        }
    }
}