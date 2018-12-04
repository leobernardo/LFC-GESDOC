using System;
using System.Net.Mail;
using System.Text;

namespace LFC.GesDoc.Site.sistema
{
    public static class EmailUtil
    {
        public static void RegistraAcesso(string _Email)
        {
            //string nomeRemetente = "GESDOC";
            //string emailRemetente = "gesdoc@lfc.org.br";
            //string emailDestinatario = "leonardo.bernardo@dnpm.gov.br";
            //string assuntoMensagem = "Acesso ao Sistema GESDOC";
            //string conteudoMensagem = "O usuário <b>" + _Email + "</b> acesso o GESDOC em " + DateTime.Now;

            //MailMessage objEmail = new MailMessage();

            //objEmail.From = new MailAddress(nomeRemetente + "<" + emailRemetente + ">");
            //objEmail.To.Add(emailDestinatario);
            //objEmail.Priority = MailPriority.Normal;
            //objEmail.IsBodyHtml = true;
            //objEmail.Subject = assuntoMensagem;
            //objEmail.Body = conteudoMensagem;
            //objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            //objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

            //SmtpClient objSmtp = new SmtpClient();

            //objSmtp.Host = "localhost";
            //objSmtp.Port = 25;

            //try
            //{
            //    objSmtp.Send(objEmail);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    objEmail.Dispose();
            //}
        }
    }
}