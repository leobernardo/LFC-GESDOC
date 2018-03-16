using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

using LFC.GesDoc.Interfaces;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.DAL
{
    public class ArquivamentoExternoDAL : IDal
    {
        public ArquivamentoExterno CarregarDadosUltimoCadastrado()
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    DocumentoDAL dDAL = new DocumentoDAL();

                    ArquivamentoExterno ae = new ArquivamentoExterno();

                    SqlCommand cmd1 = new SqlCommand("SELECT MAX(idArquivamentoExterno) AS idArquivamentoExterno FROM tbArquivamentosExternos", objConn);
                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    if (dr1.Read())
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT idArquivamentoExterno,idDocumento,estante,prateleira,caixa,arquivoDocumento FROM tbArquivamentosInternos WHERE idArquivamentoExterno = " + dr1["idArquivamentoExterno"].ToString(), objConn);
                        SqlDataReader dr2 = cmd2.ExecuteReader();

                        if (dr2.Read())
                        {
                            ae.IdArquivamentoExterno = Convert.ToInt32(dr2["idArquivamentoInterno"]);
                            ae.Documento = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(dr2["idDocumento"]));
                            ae.Estante = Convert.ToInt32(dr2["estante"]);
                            ae.Prateleira = Convert.ToInt32(dr2["prateleira"]);
                            ae.Caixa = Convert.ToInt32(dr2["caixa"]);
                            ae.ArquivoDocumento = dr2["arquivoDocumento"].ToString();
                        }
                    }

                    return ae;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    objConn.Close();
                }
            }
        }

        public IList Listar()
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(object obj)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    ArquivamentoExterno ae = (ArquivamentoExterno)obj;

                    SqlCommand cmd = new SqlCommand("INSERT INTO tbArquivamentosExternos(idDocumento,estante,prateleira,caixa,arquivoDocumento) VALUES(@IdDocumento,@Estante,@Prateleira,@Caixa,@ArquivoDocumento)", objConn);
                    cmd.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = ae.Documento.IdDocumento;
                    cmd.Parameters.Add("@Estante", SqlDbType.Int).Value = ae.Estante;
                    cmd.Parameters.Add("@Prateleira", SqlDbType.Int).Value = ae.Prateleira;
                    cmd.Parameters.Add("@Caixa", SqlDbType.Int).Value = ae.Caixa;
                    cmd.Parameters.Add("@ArquivoDocumento", SqlDbType.VarChar, 20).Value = ae.ArquivoDocumento;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    objConn.Close();
                }
            }
        }

        public void Excluir(object obj)
        {
            throw new NotImplementedException();
        }

        public void ExcluirPorIdDocumento(Int32 _IdDocumento)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM tbArquivamentosExternos WHERE idDocumento = " + _IdDocumento, objConn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    objConn.Close();
                }
            }
        }

        public void Alterar(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
