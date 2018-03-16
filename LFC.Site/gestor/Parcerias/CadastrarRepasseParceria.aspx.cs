using System;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Parcerias
{
    public partial class CadastrarRepasseParceria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            { throw; }
        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                RepasseParceria rp = new RepasseParceria();
                RepasseParceriaDAL rpDAL = new RepasseParceriaDAL();

                ParceriaDAL cDAL = new ParceriaDAL();

                rp.Parceria = cDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idPrc"]));
                rp.DataVencimento = Convert.ToDateTime(txtDataVencimento.Text);

                if (txtDataRepasse.Text == "")
                { rp.DataRepasse = new DateTime(1900, 1, 1); }
                else
                { rp.DataRepasse = Convert.ToDateTime(txtDataRepasse.Text); }
                
                rp.ValorRepasse = Convert.ToDecimal(txtValor.Text);
                rp.Status = ddlStatus.SelectedValue;

                rpDAL.Cadastrar(rp);

                Response.Write("<script language='JavaScript'>alert('Repasse da Parceria cadastrado com sucesso');window.parent.location='RepassesParceria.aspx?idPrc=" + Request.QueryString["idPrc"] + "';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}