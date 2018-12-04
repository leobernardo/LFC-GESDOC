using LFC.GesDoc.DAL;
using System;
using System.Net.Mail;
using System.Text;
//using System.Web.Mail;

namespace LFC.GesDoc.Site.sistema
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

                EmailUtil.RegistraAcesso(strEmail);

                UsuarioDAL uDAL = new UsuarioDAL();
                uDAL.Autenticar(strEmail, strSenha);
            }
            catch (Exception)
            { throw; }
        }
    }
}