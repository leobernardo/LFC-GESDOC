using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.sistema.Documentos
{
    public partial class AlterarDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    DocumentoDAL dDAL = new DocumentoDAL();
                    Documento d = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(Request.QueryString["idDoc"]));

                    // PREENCHE OS TIPOS DE DOCUMENTOS //
                    TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();
                    ddlTipoDocumento.DataSource = tdDAL.Listar();
                    ddlTipoDocumento.DataBind();
                    ddlTipoDocumento.SelectedValue = d.TipoDocumento.IDTipoDocumento.ToString();
                    // FIM //

                    txtDescricao.Text = d.Descricao;
                    txtNomePortador.Text = d.NomePortador;
                    txtRg.Text = d.RG;
                    txtNumeroInss.Text = d.NumeroINSS;
                    txtCpfCnpj.Text = d.CPFCNPJ;
                    txtVigencia.Text = d.Vigencia.ToString();

                    DateTime dtNula = new DateTime(0001, 1, 1);

                    if (d.VencimentoVigencia != dtNula)
                    { txtVencimentoVigencia.Text = d.VencimentoVigencia.ToShortDateString(); }

                    if (d.DataEmissao != dtNula)
                    { txtDataEmissao.Text = d.DataEmissao.ToShortDateString(); }

                    if (d.DataAssinatura != dtNula)
                    { txtDataAssinatura.Text = d.DataAssinatura.ToShortDateString(); }

                    if (d.DataPagamentoRecebimento != dtNula)
                    { txtDataPagamentoRecebimento.Text = d.DataPagamentoRecebimento.ToShortDateString(); }

                    txtNumeroParcelas.Text = d.NumeroParcelas;
                    txtValorPrevistoParcela.Text = d.ValorPrevistoParcela;

                    if (d.Descarte != dtNula)
                    { txtDescarte.Text = d.Descarte.ToShortDateString(); }
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void Alterar(object sender, EventArgs e)
        {
            try
            {
                DocumentoDAL dDAL = new DocumentoDAL();
                Documento d = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(Request.QueryString["idDoc"]));

                TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();
                d.TipoDocumento = tdDAL.ObterDadosPorId(Convert.ToInt32(ddlTipoDocumento.SelectedValue));

                d.Descricao = txtDescricao.Text;
                d.NomePortador = txtNomePortador.Text;
                d.RG = txtRg.Text;
                d.NumeroINSS = txtNumeroInss.Text;
                d.CPFCNPJ = txtCpfCnpj.Text;

                if (txtVigencia.Text == "")
                { d.Vigencia = 0; }
                else
                { d.Vigencia = Convert.ToInt32(txtVigencia.Text); }

                if (txtVencimentoVigencia.Text == "")
                { d.VencimentoVigencia = new DateTime(1900, 1, 1); }
                else
                { d.VencimentoVigencia = Convert.ToDateTime(txtVencimentoVigencia.Text); }

                if (txtDataEmissao.Text == "")
                { d.DataEmissao = new DateTime(1900, 1, 1); }
                else
                { d.DataEmissao = Convert.ToDateTime(txtDataEmissao.Text); }

                if (txtDataAssinatura.Text == "")
                { d.DataAssinatura = new DateTime(1900, 1, 1); }
                else
                { d.DataAssinatura = Convert.ToDateTime(txtDataAssinatura.Text); }

                if (txtDataPagamentoRecebimento.Text == "")
                { d.DataPagamentoRecebimento = new DateTime(1900, 1, 1); }
                else
                { d.DataPagamentoRecebimento = Convert.ToDateTime(txtDataPagamentoRecebimento.Text); }

                d.NumeroParcelas = txtNumeroParcelas.Text;
                d.ValorPrevistoParcela = txtValorPrevistoParcela.Text;

                if (txtDescarte.Text == "")
                { d.Descarte = new DateTime(1900, 1, 1); }
                else
                { d.Descarte = Convert.ToDateTime(txtDescarte.Text); }

                dDAL.Alterar(d);

                Response.Write("<script language='JavaScript'>alert('Documento alterado com sucesso');window.parent.location='ListarDocumentos.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}