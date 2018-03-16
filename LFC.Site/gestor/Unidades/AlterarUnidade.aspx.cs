using System;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Unidades
{
    public partial class AlterarUnidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    UnidadeDAL uDAL = new UnidadeDAL();
                    Unidade u = uDAL.CarregarDadosPorIdUnidade(Convert.ToInt32(Request.QueryString["idUnd"]));

                    txtDescricao.Text = u.Descricao;

                    if (u.Ativo == true)
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
                UnidadeDAL uDAL = new UnidadeDAL();
                Unidade u = uDAL.CarregarDadosPorIdUnidade(Convert.ToInt32(Request.QueryString["idUnd"]));

                u.Descricao = Util.formataTexto(txtDescricao.Text);

                if (radAtivo_N.Checked == true)
                { u.Ativo = false; }
                else
                { u.Ativo = true; }

                uDAL.Alterar(u);

                Response.Write("<script language='JavaScript'>alert('Unidade alterada com sucesso');window.parent.location='ListarUnidades.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}