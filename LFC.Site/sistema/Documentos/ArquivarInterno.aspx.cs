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
    public partial class ArquivarInterno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Arquivar(object sender, EventArgs e)
        {
            try
            {
                DocumentoDAL dDAL = new DocumentoDAL();

                ArquivamentoInterno ai = new ArquivamentoInterno();

                // CADASTRA O ARQUIVAMENTO INTERNO //
                bool boolArquivoInvalido = false;

                if (txtArquivoDocumento.HasFile)
                {
                    switch (txtArquivoDocumento.FileName.Substring(txtArquivoDocumento.FileName.Length - 4))
                    {
                        case ".pdf":
                            ai.Documento = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(Request.QueryString["idDoc"]));
                            ai.Arquivo = Convert.ToInt32(txtArquivo.Text);
                            ai.Gaveta = Convert.ToInt32(txtGaveta.Text);
                            ai.Pasta = Convert.ToInt32(txtPasta.Text);
                            ai.ArquivoDocumento = "-";

                            ArquivamentoInternoDAL aiDAL = new ArquivamentoInternoDAL();
                            aiDAL.Cadastrar(ai);

                            ArquivamentoInterno aiUltimo = new ArquivamentoInterno();
                            aiUltimo = aiDAL.CarregarDadosUltimoCadastrado();

                            String strNome;

                            strNome = aiUltimo.IdArquivamentoInterno + txtArquivoDocumento.FileName.Substring(txtArquivoDocumento.FileName.Length - 4);
                            aiUltimo.ArquivoDocumento = strNome;

                            txtArquivoDocumento.SaveAs(Server.MapPath(@"../../../sgd/img/arquivamentosInternos/") + strNome);

                            aiDAL.Alterar(aiUltimo);

                            break;
                        default:
                            boolArquivoInvalido = true;

                            break;
                    }
                }
                else
                {
                    ai.Documento = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(Request.QueryString["idDoc"]));
                    ai.Arquivo = Convert.ToInt32(txtArquivo.Text);
                    ai.Gaveta = Convert.ToInt32(txtGaveta.Text);
                    ai.Pasta = Convert.ToInt32(txtPasta.Text);
                    ai.ArquivoDocumento = "-";

                    ArquivamentoInternoDAL aiDAL = new ArquivamentoInternoDAL();
                    aiDAL.Cadastrar(ai);
                }
                // FIM //

                // ALTERA O STATUS DO DOCUMENTO //
                Documento d = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(Request.QueryString["idDoc"]));
                d.Arquivado = "1";

                //Response.Write(d.VencimentoVigencia == new DateTime(0001, 1, 1));
                //Response.End();

                dDAL.Alterar(d);
                // FIM //

                // EXCLUI TODOS OS ARQUIVAMENTOS EXTERNOS DO DOCUMENTO //
                ArquivamentoExternoDAL aeDAL = new ArquivamentoExternoDAL();
                aeDAL.ExcluirPorIdDocumento(d.IdDocumento);
                // FIM //

                Response.Write("<script language='JavaScript'>alert('Arquivamento Interno do Documento realizado com sucesso');window.parent.location='ListarDocumentos.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}