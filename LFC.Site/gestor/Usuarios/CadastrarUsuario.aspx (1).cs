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
                u.Processo = pDAL.CarregarDadosPorIdProcesso(Convert.ToInt32(ddlProcesso.SelectedValue));

                u.Nome = Util.formataTexto(txtNome.Text);
                u.Email = Util.formataTexto(txtEmail.Text);
                u.Telefone1 = "-";
                u.Telefone2 = "-";
                u.Telefone3 = "-";
                u.DataNascimento = new DateTime(1900, 1, 1);
                u.Senha = txtSenha.Text;
                u.NivelAcesso = "usuario";

                UsuarioDAL uDAL = new UsuarioDAL();
                uDAL.Cadastrar(u);

                Response.Write("<script language='JavaScript'>alert('Usuário cadastrado com sucesso');window.parent.location='ListarUsuarios.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}