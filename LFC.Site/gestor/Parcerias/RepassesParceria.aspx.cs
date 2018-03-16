using System;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Parcerias
{
    public partial class RepassesParceria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RepasseParceriaDAL rpDAL = new RepasseParceriaDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        RepasseParceria rp = rpDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idRpp"]));
                        rpDAL.Excluir(rp);
                        Response.Write("<script language='JavaScript'>alert('O Repasse da Parceria foi excluído com sucesso');location='RepassesParceria.aspx?idPrc=" + Request.QueryString["idPrc"] + "';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA OS REPASSES DA PARCERIA //
                rptRepassesParceria.DataSource = rpDAL.ListarPorParceria(Convert.ToInt32(Request.QueryString["idPrc"]));
                rptRepassesParceria.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarRepasseParceria(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarRepasseParceria.aspx?idPrc=" + Request.QueryString["idPrc"]); }
            catch (Exception)
            { throw; }
        }

        protected string getDataRepasse(DateTime _DataRepasse)
        {
            try
            {
                if (_DataRepasse == Convert.ToDateTime("01/01/1900"))
                { return "<span class='text-red'>N/D</span>"; }
                else
                { return _DataRepasse.ToShortDateString(); }
            }
            catch (Exception)
            { throw; }
        }

        protected string getStatus(string _Status)
        {
            try
            {
                switch (_Status)
                {
                    case "pago":
                        return "<span class=\"label label-success\">Pago</span>";
                    case "pendente":
                        return "<span class=\"label label-danger\">Pendente</span>";
                    default:
                        return "";
                }
            }
            catch (Exception)
            { throw; }
        }
    }
}