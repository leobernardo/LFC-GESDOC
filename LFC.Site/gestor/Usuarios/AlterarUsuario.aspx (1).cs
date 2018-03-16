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
                    Usuario u = uDAL.CarregarDadosPorIdUsuario(Convert.ToInt32(Request.QueryString["idUsr"]));

                    // PREENCHE OS PROCESSOS //
                    ProcessoDAL pDAL = new ProcessoDAL();
                    ddlProcesso.DataSource = pDAL.Listar();
                    ddlProcesso.DataBind();
                    ddlProcesso.SelectedValue = u.Processo.IdProcesso.ToString();
                    // FIM //

                    txtNome.Text = u.Nome;
                    txtEmail.Text = u.Email;
                    txtSenha.Text = u.Senha;
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
                Usuario u = uDAL.CarregarDadosPorIdUsuario(Convert.ToInt32(Request.QueryString["idUsr"]));

                ProcessoDAL pDAL = new ProcessoDAL();
                u.Processo = pDAL.CarregarDadosPorIdProcesso(Convert.ToInt32(ddlProcesso.SelectedValue));

                u.Nome = txtNome.Text;
                u.Email = txtEmail.Text;
                u.Senha = txtSenha.Text;

                uDAL.Alterar(u);

                Response.Write("<script language='JavaScript'>alert('Usuário alterado com sucesso');window.parent.location='ListarUsuarios.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}