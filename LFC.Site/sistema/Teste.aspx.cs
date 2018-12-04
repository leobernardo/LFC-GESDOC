using System;
using System.Net.Mail;
using System.Text;

namespace LFC.GesDoc.Site.sistema
{
    public partial class Teste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nomeRemetente = "GESDOC";
            string emailRemetente = "gesdoc@lfc.org.br";
            string emailDestinatario = "leonardo.bernardo@dnpm.gov.br";
            string assuntoMensagem = "Acesso ao Sistema GESDOC";
            string conteudoMensagem = "Teste de envio de emails usando System.Net.Mail em C#";

            MailMessage objEmail = new MailMessage();

            objEmail.From = new MailAddress(nomeRemetente + "<" + emailRemetente + ">");
            objEmail.To.Add(emailDestinatario);
            objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            objEmail.Subject = assuntoMensagem;
            objEmail.Body = conteudoMensagem;
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

            SmtpClient objSmtp = new SmtpClient();

            objSmtp.Host = "localhost";
            objSmtp.Port = 25;

            try
            {
                objSmtp.Send(objEmail);
                Response.Write("Mensagem enviada com sucesso!");
            }
            catch (Exception ex)
            {
                Response.Write("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
            }
            finally
            {
                objEmail.Dispose();
            }
        }
    }
}