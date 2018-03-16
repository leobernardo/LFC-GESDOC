using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.sistema.Documentos
{
    public partial class MovimentarDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    DocumentoDAL dDAL = new DocumentoDAL();
                    Documento d = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(Request.QueryString["idDoc"]));

                    litDescricao.Text = d.Descricao;
                    litTipo.Text = d.TipoDocumento.Nome;
                    litPortador.Text = d.NomePortador;

                    // PREENCHE OS PROCESSOS //
                    ProcessoDAL pDAL = new ProcessoDAL();
                    ddlProcessoDestino.DataSource = pDAL.Listar();
                    ddlProcessoDestino.DataBind();
                    ddlProcessoDestino.Items.Insert(0, (new ListItem("", "")));
                    // FIM //
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void Movimentar(object sender, EventArgs e)
        {
            try
            {
                DocumentoDAL dDAL = new DocumentoDAL();
                Documento d = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(Request.QueryString["idDoc"]));

                UsuarioDAL uDAL = new UsuarioDAL();
                Usuario u = uDAL.CarregarDadosPorIdUsuario(Convert.ToInt32(Session["sesIdUsuario"]));

                ProcessoDAL pDAL = new ProcessoDAL();
                Processo p = pDAL.CarregarDadosPorIdProcesso(Convert.ToInt32(ddlProcessoDestino.SelectedValue));

                DateTime dtPrazo = DateTime.Now.AddDays(p.PrazoMaximo);

                Movimentacao m = new Movimentacao();

                m.Documento = d;
                m.ProcessoOrigem = Convert.ToInt32(Session["sesIdProcesso"]);
                m.ProcessoDestino = Convert.ToInt32(ddlProcessoDestino.SelectedValue);
                m.DataHoraMovimentacao = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                m.MovimentadoPor = u.Nome;
                m.Recebido = "Não";
                m.DataHoraRecebimento = "";
                m.Prazo = dtPrazo;
                m.Despacho = txtDespacho.Text.Replace("\n", "<br />");
                m.EntreguePara = txtEntreguePara.Text.Replace("'", "");
                m.AlertaPrazo = "Não";

                dDAL.Movimentar(m, d.IdDocumento);

                // ENVIA O E-MAIL //
                string strNomeRemetente = "LFC - GesDoc";
                string strEmailRemetente = "gesdoc@lfc.org.br";
                string strSenha = "01!GesDoc!";
                string strSMTP = "smtp.lfc.org.br";
                string strEmailDestinatario = "leobernardo@outlook.com";
                string strAssunto = "Documento movimentado para este processo";
                string strConteudo = "Teste de envio de emails usando System.Net.Mail em C#";

                //Cria objeto com dados do e-mail.
                MailMessage objEmail = new MailMessage();
                objEmail.From = new System.Net.Mail.MailAddress(strNomeRemetente + "<" + strEmailRemetente + ">");
                objEmail.To.Add(strEmailDestinatario);
                objEmail.Priority = System.Net.Mail.MailPriority.Normal;
                objEmail.IsBodyHtml = true;
                objEmail.Subject = strAssunto;
                objEmail.Body = strConteudo;

                //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
                objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                //Cria objeto com os dados do SMTP
                System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

                //Alocamos o endereço do host para enviar os e-mails  
                objSmtp.Credentials = new System.Net.NetworkCredential(strEmailRemetente, strSenha);
                objSmtp.Host = strSMTP;
                objSmtp.Port = 587;

                //Enviamos o e-mail através do método .send()
                try
                { objSmtp.Send(objEmail); }
                catch (Exception ex)
                { Response.Write("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message); }
                finally
                { objEmail.Dispose(); }
                // FIM //

                Response.Write("<script language='JavaScript'>alert('O Documento foi movimentado com sucesso');parent.location='ListarDocumentos.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}