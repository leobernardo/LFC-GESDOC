using System;
using System.Web.UI;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.sistema.Parcerias
{
    public partial class AlterarRepasseParceria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    RepasseParceriaDAL rpDAL = new RepasseParceriaDAL();
                    RepasseParceria rp = rpDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idRpp"]));

                    txtDataVencimento.Text = rp.DataVencimento.ToShortDateString();

                    if (Convert.ToDateTime(rp.DataRepasse) != new DateTime(1900, 1, 1))
                    { txtDataRepasse.Text = Convert.ToDateTime(rp.DataRepasse).ToShortDateString(); }

                    txtValor.Text = String.Format("{0:0.00}", rp.ValorRepasse);
                    ddlStatus.SelectedValue = rp.Status;
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void Alterar(object sender, EventArgs e)
        {
            try
            {
                RepasseParceriaDAL rpDAL = new RepasseParceriaDAL();
                RepasseParceria rp = rpDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idRpp"]));

                rp.DataVencimento = Convert.ToDateTime(txtDataVencimento.Text);

                if (txtDataRepasse.Text == "")
                { rp.DataRepasse = new DateTime(1900, 1, 1); }
                else
                { rp.DataRepasse = Convert.ToDateTime(txtDataRepasse.Text); }

                rp.ValorRepasse = Convert.ToDecimal(txtValor.Text);
                rp.Status = ddlStatus.SelectedValue;

                rpDAL.Alterar(rp);

                Response.Write("<script language='JavaScript'>alert('Repasse da Parceria alterado com sucesso');window.parent.location='RepassesParceria.aspx?idPrc=" + Request.QueryString["idPrc"] + "';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}