using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Processos
{
    public partial class AlterarProcesso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ProcessoDAL pDAL = new ProcessoDAL();
                Processo p = pDAL.CarregarDadosPorIdProcesso(Convert.ToInt32(Request.QueryString["idPrc"]));

                txtNome.Text = p.Nome;
                txtEmail.Text = p.Email;
                txtPrazoMaximo.Text = p.PrazoMaximo.ToString();

                if (p.Ativo == "0")
                {
                    radAtivo_N.Checked = true;
                    radAtivo_S.Checked = false;
                }
                else
                {
                    radAtivo_N.Checked = false;
                    radAtivo_S.Checked = true;
                }
            }
        }

        protected void Alterar(object sender, EventArgs e)
        {
            try
            {
                ProcessoDAL pDAL = new ProcessoDAL();
                Processo p = pDAL.CarregarDadosPorIdProcesso(Convert.ToInt32(Request.QueryString["idPrc"]));

                p.Nome = txtNome.Text;
                p.Email = txtEmail.Text;
                p.PrazoMaximo = Convert.ToInt32(txtPrazoMaximo.Text);

                if (radAtivo_N.Checked == true)
                { p.Ativo = "0"; }
                else
                { p.Ativo = "1"; }

                pDAL.Alterar(p);

                Response.Write("<script language='JavaScript'>alert('Processo alterado com sucesso');window.parent.location='ListarProcessos.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}