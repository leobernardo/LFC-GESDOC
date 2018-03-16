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
    public partial class ArquivarExterno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Arquivar(object sender, EventArgs e)
        {
            try
            {
                DocumentoDAL dDAL = new DocumentoDAL();

                // CADASTRA O ARQUIVAMENTO EXTERNO //
                bool boolArquivoInvalido = false;

                if (txtArquivoDocumento.HasFile)
                {
                    switch (txtArquivoDocumento.FileName.Substring(txtArquivoDocumento.FileName.Length - 4))
                    {
                        case ".pdf":
                            ArquivamentoExterno ae = new ArquivamentoExterno();

                            ae.Documento = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(Request.QueryString["idDoc"]));
                            ae.Estante = Convert.ToInt32(txtEstante.Text);
                            ae.Prateleira = Convert.ToInt32(txtPrateleira.Text);
                            ae.Caixa = Convert.ToInt32(txtCaixa.Text);
                            ae.ArquivoDocumento = "-";

                            ArquivamentoExternoDAL aeDAL = new ArquivamentoExternoDAL();
                            aeDAL.Cadastrar(ae);

                            ArquivamentoExterno aeUltimo = new ArquivamentoExterno();
                            aeUltimo = aeDAL.CarregarDadosUltimoCadastrado();

                            String strNome;

                            strNome = aeUltimo.IdArquivamentoExterno + txtArquivoDocumento.FileName.Substring(txtArquivoDocumento.FileName.Length - 4);
                            aeUltimo.ArquivoDocumento = strNome;

                            txtArquivoDocumento.SaveAs(Server.MapPath(@"../../../sgd/img/arquivamentosExternos/") + strNome);

                            aeDAL.Alterar(aeUltimo);

                            break;
                        default:
                            boolArquivoInvalido = true;

                            break;
                    }
                }
                // FIM //

                // ALTERA O STATUS DO DOCUMENTO //
                Documento d = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(Request.QueryString["idDoc"]));
                d.Arquivado = "2";
                dDAL.Alterar(d);
                // FIM //

                // EXCLUI TODOS OS ARQUIVAMENTOS INTERNOS DO DOCUMENTO //
                ArquivamentoInternoDAL aiDAL = new ArquivamentoInternoDAL();
                aiDAL.ExcluirPorIdDocumento(d.IdDocumento);
                // FIM //
            }
            catch (Exception)
            { throw; }
        }
    }
}