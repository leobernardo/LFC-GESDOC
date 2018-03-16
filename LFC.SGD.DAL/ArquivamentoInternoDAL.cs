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
    public class ArquivamentoInternoDAL : IDal
    {
        public ArquivamentoInterno CarregarDadosPorIdDocumento(Int32 _IdDocumento)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    ArquivamentoInterno ai = new ArquivamentoInterno();

                    SqlCommand cmd = new SqlCommand("SELECT idArquivamentoInterno,idDocumento,arquivo,gaveta,pasta,arquivoDocumento FROM tbArquivamentosInternos WHERE idDocumento = " + _IdDocumento, objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    DocumentoDAL dDAL = new DocumentoDAL();

                    if (dr.Read())
                    {
                        ai.IdArquivamentoInterno = Convert.ToInt32(dr["idArquivamentoInterno"]);
                        ai.Documento = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(dr["idDocumento"]));
                        ai.Arquivo = Convert.ToInt32(dr["arquivo"]);
                        ai.Gaveta = Convert.ToInt32(dr["gaveta"]);
                        ai.Pasta = Convert.ToInt32(dr["pasta"]);
                        ai.ArquivoDocumento = dr["arquivoDocumento"].ToString();
                    }

                    return ai;
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

        public ArquivamentoInterno CarregarDadosUltimoCadastrado()
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    DocumentoDAL dDAL = new DocumentoDAL();

                    ArquivamentoInterno ai = new ArquivamentoInterno();

                    SqlCommand cmd1 = new SqlCommand("SELECT MAX(idArquivamentoInterno) AS idArquivamentoInterno FROM tbArquivamentosInternos", objConn);
                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    if (dr1.Read())
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT idArquivamentoInterno,idDocumento,arquivo,gaveta,pasta,arquivoDocumento FROM tbArquivamentosInternos WHERE idArquivamentoInterno = " + dr1["idArquivamentoInterno"].ToString(), objConn);
                        SqlDataReader dr2 = cmd2.ExecuteReader();

                        if (dr2.Read())
                        {
                            ai.IdArquivamentoInterno = Convert.ToInt32(dr2["idArquivamentoInterno"]);
                            ai.Documento = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(dr2["idDocumento"]));
                            ai.Arquivo = Convert.ToInt32(dr2["arquivo"]);
                            ai.Gaveta = Convert.ToInt32(dr2["gaveta"]);
                            ai.Pasta = Convert.ToInt32(dr2["pasta"]);
                            ai.ArquivoDocumento = dr2["arquivoDocumento"].ToString();
                        }
                    }

                    return ai;
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

                    ArquivamentoInterno ai = (ArquivamentoInterno)obj;

                    SqlCommand cmd = new SqlCommand("INSERT INTO tbArquivamentosInternos(idDocumento,arquivo,gaveta,pasta,arquivoDocumento) VALUES(@IdDocumento,@Arquivo,@Gaveta,@Pasta,@ArquivoDocumento)", objConn);
                    cmd.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = ai.Documento.IdDocumento;
                    cmd.Parameters.Add("@Arquivo", SqlDbType.Int).Value = ai.Arquivo;
                    cmd.Parameters.Add("@Gaveta", SqlDbType.Int).Value = ai.Gaveta;
                    cmd.Parameters.Add("@Pasta", SqlDbType.Int).Value = ai.Pasta;
                    cmd.Parameters.Add("@ArquivoDocumento", SqlDbType.VarChar, 20).Value = ai.ArquivoDocumento;

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

                    SqlCommand cmd = new SqlCommand("DELETE FROM tbArquivamentosInternos WHERE idDocumento = " + _IdDocumento, objConn);
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
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    ArquivamentoInterno ai = (ArquivamentoInterno)obj;

                    SqlCommand cmd = new SqlCommand("UPDATE tbArquivamentosInternos SET arquivo=@Arquivo,gaveta=@Gaveta,pasta=@Pasta,arquivoDocumento=@ArquivoDocumento WHERE idArquivamentoInterno=@IdArquivamentoInterno", objConn);
                    cmd.Parameters.Add("@Arquivo", SqlDbType.Int).Value = ai.Arquivo;
                    cmd.Parameters.Add("@Gaveta", SqlDbType.Int).Value = ai.Gaveta;
                    cmd.Parameters.Add("@Pasta", SqlDbType.Int).Value = ai.Pasta;
                    cmd.Parameters.Add("@ArquivoDocumento", SqlDbType.VarChar, 20).Value = ai.ArquivoDocumento;
                    cmd.Parameters.Add("@IdArquivamentoInterno", SqlDbType.Int).Value = ai.IdArquivamentoInterno;

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
    }
}
