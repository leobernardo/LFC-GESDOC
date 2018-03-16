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
    public partial class CadastrarDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    // PREENCHE OS TIPOS DE DOCUMENTOS //
                    TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();
                    ddlTipoDocumento.DataSource = tdDAL.Listar();
                    ddlTipoDocumento.DataBind();
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
                Documento d = new Documento();

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

                d.DataCadastro = DateTime.Now;

                if (txtDescarte.Text == "")
                { d.Descarte = new DateTime(1900, 1, 1); }
                else
                { d.Descarte = Convert.ToDateTime(txtDescarte.Text); }

                d.SetorAtual = Convert.ToInt32(Session["sesIdProcesso"]);
                d.Arquivado = "0";
                d.AlertaVencimentoVigencia = "Não";

                if (txtDataPagamentoRecebimento.Text == "")
                { d.DataPagamentoRecebimento = new DateTime(1900, 1, 1); }
                else
                { d.DataPagamentoRecebimento = Convert.ToDateTime(txtDataPagamentoRecebimento.Text); }

                d.NumeroParcelas = txtNumeroParcelas.Text;
                d.ValorPrevistoParcela = txtValorPrevistoParcela.Text;
                d.Arquivo = "-";
                d.Ativo = "S";

                DocumentoDAL dDAL = new DocumentoDAL();
                dDAL.Cadastrar(d);

                //Documento dUltimo = dDAL.CarregarDadosUltimoCadastrado();

                Response.Write("<script language='JavaScript'>alert('Documento cadastrado com sucesso');window.parent.location='ListarDocumentos.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}