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
                Processo p = pDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idPrc"]));

                txtDescricao.Text = p.DSProcesso;
                txtEmail.Text = p.DSEmail;
                txtPrazoMaximo.Text = p.NRPrazoMaximo.ToString();

                if (p.BTAtivo)
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

        protected void Alterar(object sender, EventArgs e)
        {
            try
            {
                ProcessoDAL pDAL = new ProcessoDAL();
                Processo p = pDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idPrc"]));

                p.DSProcesso = Util.formataTexto(txtDescricao.Text);
                p.DSEmail = Util.formataTexto(txtEmail.Text);
                p.NRPrazoMaximo = Convert.ToInt32(txtPrazoMaximo.Text);

                if (radAtivo_N.Checked == true)
                { p.BTAtivo = false; }
                else
                { p.BTAtivo = true; }

                pDAL.Alterar(p);

                Response.Write("<script language='JavaScript'>alert('Processo alterado com sucesso');window.parent.location='ListarProcessos.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}