using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Convenios
{
    public partial class CadastrarConvenio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    // PREENCHE AS UNIDADES //
                    UnidadeDAL uDAL = new UnidadeDAL();
                    ddlUnidade.DataSource = uDAL.Listar();
                    ddlUnidade.DataBind();
                    ddlUnidade.Items.Insert(0, (new ListItem("", "")));
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
                Convenio c = new Convenio();

                UnidadeDAL uDAL = new UnidadeDAL();
                c.Unidade = uDAL.CarregarDadosPorIdUnidade(Convert.ToInt32(ddlUnidade.SelectedValue));

                c.Nome = Util.formataTexto(txtNome.Text);
                c.Objetivo = Util.formataTexto(txtObjetivo.Text);
                c.Observacoes = Util.formataTexto(txtObservacoes.Text);

                if (radPossuiPagamentoRH_N.Checked == true)
                { c.PossuiPagamentoRH = false; }
                else
                { c.PossuiPagamentoRH = true; }

                c.InicioVigencia = Convert.ToDateTime(txtDataInicioVigencia.Text);
                c.FimVigencia = Convert.ToDateTime(txtDataFimVigencia.Text);
                c.ArquivoAnexo = "-";
                c.Status = "Vigente";

                ConvenioDAL cDAL = new ConvenioDAL();
                cDAL.Cadastrar(c);

                Response.Write("<script language='JavaScript'>alert('Convênio cadastrado com sucesso');window.parent.location='ListarConvenios.aspx?idUnd=" + c.Unidade.IdUnidade +"';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}