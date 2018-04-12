using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.sistema.Parcerias
{
    public partial class CadastrarParceria : System.Web.UI.Page
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
                ParceriaDAL pDAL = new ParceriaDAL();
                Parceria p = new Parceria();

                UnidadeDAL uDAL = new UnidadeDAL();
                p.Unidade = uDAL.CarregarDadosPorIdUnidade(Convert.ToInt32(ddlUnidade.SelectedValue));

                p.Nome = Util.formataTexto(txtNome.Text);
                p.Tipo = ddlTipo.SelectedValue;
                p.Objetivo = Util.formataTexto(txtObjetivo.Text);
                p.Observacoes = Util.formataTexto(txtObservacoes.Text);

                if (radPossuiPagamentoRH_N.Checked == true)
                { p.PossuiPagamentoRH = false; }
                else
                { p.PossuiPagamentoRH = true; }

                if (radPossuiRecursosFinanceiros_N.Checked == true)
                {
                    p.PossuiRecursosFinanceiros = false;
                    p.ValorPrevistoAnual = 0;
                }
                else
                {
                    p.PossuiRecursosFinanceiros = true;
                    p.ValorPrevistoAnual = Convert.ToDecimal(txtValorPrevistoAnual.Text);
                }

                if (radPossuiVigencia_N.Checked == true)
                {
                    p.PossuiVigencia = false;
                    p.InicioVigencia = new DateTime(1900, 1, 1);
                    p.FimVigencia = new DateTime(1900, 1, 1);
                }
                else
                {
                    p.PossuiVigencia = true;
                    p.InicioVigencia = Convert.ToDateTime(txtDataInicioVigencia.Text);
                    p.FimVigencia = Convert.ToDateTime(txtDataFimVigencia.Text);
                }

                if (radEmExecucao_N.Checked == true)
                { p.EmExecucao = false; }
                else
                { p.EmExecucao = true; }

                p.ArquivoAnexo = "-";
                p.Status = "Vigente";

                pDAL.Cadastrar(p);

                // CADASTRA O ARQUIVO DA PARCERIA //
                Parceria pUltimaCadastrada = pDAL.ObterUltimaCadastrada();

                bool blFlag = false;

                if (txtArquivoParceria.HasFile)
                {
                    switch (txtArquivoParceria.FileName.Substring(txtArquivoParceria.FileName.Length - 4))
                    {
                        case ".pdf":

                            if (txtArquivoParceria.PostedFile.ContentLength > 20971520)
                            { blFlag = true; }
                            else
                            {
                                string strNome;

                                strNome = pUltimaCadastrada.IdParceria + txtArquivoParceria.FileName.Substring(txtArquivoParceria.FileName.Length - 4);
                                pUltimaCadastrada.ArquivoAnexo = strNome;

                                txtArquivoParceria.SaveAs(Server.MapPath(@"../../arquivos/parcerias/") + strNome);

                                pDAL.Alterar(pUltimaCadastrada);
                            }

                            break;
                        default:
                            break;
                    }
                }
                // FIM //

                if (blFlag)
                { Response.Write("<script language='JavaScript'>alert('Parceria cadastrada com sucesso, porém o ARQUIVO da parceria não foi cadastrado por exceder o limite de 20 MB(megabytes)');window.parent.location='ListarParcerias.aspx?idUnd=" + p.Unidade.IdUnidade + "';</script>"); }
                else
                { Response.Write("<script language='JavaScript'>alert('Parceria cadastrada com sucesso');window.parent.location='ListarParcerias.aspx?idUnd=" + p.Unidade.IdUnidade + "';</script>"); }
            }
            catch (Exception)
            { throw; }
        }
    }
}