using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Usuarios
{
    public partial class AlterarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    UsuarioDAL uDAL = new UsuarioDAL();
                    Usuario u = uDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idUsr"]));

                    // PREENCHE OS PROCESSOS //
                    ProcessoDAL pDAL = new ProcessoDAL();
                    ddlProcesso.DataSource = pDAL.Listar();
                    ddlProcesso.DataBind();
                    ddlProcesso.SelectedValue = u.Processo.IDProcesso.ToString();
                    // FIM //

                    txtNome.Text = u.DSNome;
                    txtEmail.Text = u.DSEmail;
                    txtSenha.Text = u.DSSenha;

                    if (u.BTAtivo)
                    {
                        radAtivo_N.Checked = false;
                        radAtivo_S.Checked = true;
                    }
                    else
                    {
                        radAtivo_N.Checked = true;
                        radAtivo_S.Checked = false;
                    }
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void Alterar(object sender, EventArgs e)
        {
            try
            {
                UsuarioDAL uDAL = new UsuarioDAL();
                Usuario u = uDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idUsr"]));

                ProcessoDAL pDAL = new ProcessoDAL();
                u.Processo = pDAL.ObterDadosPorId(Convert.ToInt32(ddlProcesso.SelectedValue));

                u.DSNome = Util.formataTexto(txtNome.Text);
                u.DSEmail = Util.formataTexto(txtEmail.Text);
                u.DSSenha = txtSenha.Text;

                if (radAtivo_N.Checked == true)
                { u.BTAtivo = false; }
                else
                { u.BTAtivo = true; }

                uDAL.Alterar(u);

                Response.Write("<script language='JavaScript'>alert('Usuário alterado com sucesso');window.parent.location='ListarUsuarios.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}