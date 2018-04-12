using System;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.sistema.Parcerias
{
    public partial class AlterarParceria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ParceriaDAL pDAL = new ParceriaDAL();
                    Parceria p = pDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idPrc"]));

                    // PREENCHE AS UNIDADES //
                    UnidadeDAL uDAL = new UnidadeDAL();
                    ddlUnidade.DataSource = uDAL.Listar();
                    ddlUnidade.DataBind();
                    ddlUnidade.SelectedValue = p.Unidade.IdUnidade.ToString();
                    // FIM //

                    txtNome.Text = p.Nome;
                    ddlTipo.SelectedValue = p.Tipo;
                    txtObjetivo.Text = p.Objetivo;
                    txtObservacoes.Text = p.Observacoes;

                    if (p.PossuiPagamentoRH == true)
                    {
                        radPossuiPagamentoRH_N.Checked = false;
                        radPossuiPagamentoRH_S.Checked = true;
                    }
                    else
                    {
                        radPossuiPagamentoRH_N.Checked = true;
                        radPossuiPagamentoRH_S.Checked = false;
                    }

                    if (p.PossuiRecursosFinanceiros == true)
                    {
                        radPossuiRecursosFinanceiros_N.Checked = false;
                        radPossuiRecursosFinanceiros_S.Checked = true;

                        txtValorPrevistoAnual.Text = String.Format("{0:0.00}", p.ValorPrevistoAnual);
                    }
                    else
                    {
                        radPossuiRecursosFinanceiros_N.Checked = true;
                        radPossuiRecursosFinanceiros_S.Checked = false;
                    }

                    if (p.PossuiVigencia == true)
                    {
                        radPossuiVigencia_N.Checked = false;
                        radPossuiVigencia_S.Checked = true;

                        txtDataInicioVigencia.Text = p.InicioVigencia.ToShortDateString();
                        txtDataFimVigencia.Text = p.FimVigencia.ToShortDateString();
                    }
                    else
                    {
                        radPossuiVigencia_N.Checked = true;
                        radPossuiVigencia_S.Checked = false;
                    }

                    if (p.EmExecucao == true)
                    {
                        radEmExecucao_N.Checked = false;
                        radEmExecucao_S.Checked = true;
                    }
                    else
                    {
                        radEmExecucao_N.Checked = true;
                        radEmExecucao_S.Checked = false;
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
                ParceriaDAL pDAL = new ParceriaDAL();
                Parceria p = pDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idPrc"]));

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
                { p.PossuiVigencia = false; }
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

                // CADASTRA O ARQUIVO DA PARCERIA //
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
                                strNome = p.IdParceria + txtArquivoParceria.FileName.Substring(txtArquivoParceria.FileName.Length - 4);
                                p.ArquivoAnexo = strNome;
                                txtArquivoParceria.SaveAs(Server.MapPath(@"../../arquivos/parcerias/") + strNome);
                            }

                            break;
                        default:
                            break;
                    }
                }
                // FIM //

                pDAL.Alterar(p);

                if (blFlag)
                { Response.Write("<script language='JavaScript'>alert('Parceria alterada com sucesso, porém o ARQUIVO da parceria não foi cadastrado por exceder o limite de 20 MB(megabytes)');window.parent.location='ListarParcerias.aspx?idUnd=" + p.Unidade.IdUnidade + "';</script>"); }
                else
                { Response.Write("<script language='JavaScript'>alert('Parceria alterada com sucesso');window.parent.location='ListarParcerias.aspx?idUnd=" + p.Unidade.IdUnidade + "';</script>"); }
            }
            catch (Exception)
            { throw; }
        }
    }
}