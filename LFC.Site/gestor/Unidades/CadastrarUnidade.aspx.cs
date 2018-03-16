using System;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Unidades
{
    public partial class CadastrarUnidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                Unidade u = new Unidade();

                u.Descricao = Util.formataTexto(txtDescricao.Text);

                if (radAtivo_N.Checked == true)
                { u.Ativo = false; }
                else
                { u.Ativo = true; }

                UnidadeDAL uDAL = new UnidadeDAL();
                uDAL.Cadastrar(u);

                Response.Write("<script language='JavaScript'>alert('Unidade cadastrada com sucesso');window.parent.location='ListarUnidades.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}