using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using ASPEMAILLib;

namespace LFC.GesDoc.Site.sistema
{
    public partial class EsqueciSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Enviar(object sender, EventArgs e)
        {
            try
            {
                //ASPEMAILLib.IMailSender objMail;
                //objMail = new ASPEMAILLib.MailSender();
                //objMail.Host = "localhost";
                //objMail.From = "administrador@lfcnet.org.br";
                //objMail.MailFrom = "administrador@lfcnet.org.br";
                //objMail.FromName = "LFC - Administrador do Sistema";
                ////objMail.AddAddress objUsuario("email"), objUsuario("email");
                //objMail.AddAddress("leobernardo@outlook.com", true);
                //objMail.Subject = "Lembrete de senha";
                //objMail.IsHTML = 0;

                //String strBody = "Sua senha de acesso ao sistema é <b>123456</b>";

                //objMail.Body = strBody;
                //objMail.Send(true);
            }
            catch (Exception)
            { throw; }
        }
    }
}