using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc;
using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Usuarios
{
    public partial class CadastrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    // PREENCHE OS PROCESSOS //
                    ProcessoDAL pDAL = new ProcessoDAL();
                    ddlProcesso.DataSource = pDAL.Listar();
                    ddlProcesso.DataBind();
                    // FIM //
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                Usuario u = new Usuario();

                ProcessoDAL pDAL = new ProcessoDAL();
                u.Processo = pDAL.ObterDadosPorId(Convert.ToInt32(ddlProcesso.SelectedValue));

                u.DSNome = Util.formataTexto(txtNome.Text);
                u.DSEmail = Util.formataTexto(txtEmail.Text);
                u.DSTelefone1 = "-";
                u.DSTelefone2 = "-";
                u.DSTelefone3 = "-";
                u.DTNascimento = new DateTime(1900, 1, 1);
                u.DSSenha = txtSenha.Text;
                u.DSNivelAcesso = "usuario";

                if (radAtivo_N.Checked == true)
                { u.BTAtivo = false; }
                else
                { u.BTAtivo = true; }

                UsuarioDAL uDAL = new UsuarioDAL();
                uDAL.Cadastrar(u);

                Response.Write("<script language='JavaScript'>alert('Usuário cadastrado com sucesso');window.parent.location='ListarUsuarios.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}