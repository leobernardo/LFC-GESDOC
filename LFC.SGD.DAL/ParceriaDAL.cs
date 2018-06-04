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
    public class ParceriaDAL : IDal
    {
        public Parceria ObterDadosPorId(int _IdParceria)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Parceria p = new Parceria();

                    SqlCommand cmd = new SqlCommand("SELECT IDParceria,IDUnidade,NMParceria,DSTipo,DSObjetivo,DSObservacoes,BTPossuiPagamentoRH,BTPossuiRecursosFinanceiros,BTPossuiVigencia,DTInicioVigencia,DTFimVigencia,BTEmExecucao,VLPrevistoAnual,DSArquivoAnexo,DSStatus FROM TB_Parceria WHERE IDParceria = " + _IdParceria, objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    UnidadeDAL uDAL = new UnidadeDAL();

                    if (dr.Read())
                    {
                        p.IdParceria = Convert.ToInt32(dr["IDParceria"]);
                        p.Unidade = uDAL.CarregarDadosPorIdUnidade(Convert.ToInt32(dr["IDUnidade"]));
                        p.Nome = dr["NMParceria"].ToString();
                        p.Tipo = dr["DSTipo"].ToString();
                        p.Objetivo = dr["DSObjetivo"].ToString();
                        p.Observacoes = dr["DSObservacoes"].ToString();
                        p.PossuiPagamentoRH = Convert.ToBoolean(dr["BTPossuiPagamentoRH"]);
                        p.PossuiRecursosFinanceiros = Convert.ToBoolean(dr["BTPossuiRecursosFinanceiros"]);
                        p.PossuiVigencia = Convert.ToBoolean(dr["BTPossuiVigencia"]);
                        p.InicioVigencia = Convert.ToDateTime(dr["DTInicioVigencia"]);
                        p.FimVigencia = Convert.ToDateTime(dr["DTFimVigencia"]);
                        p.EmExecucao = Convert.ToBoolean(dr["BTEmExecucao"]);
                        p.ValorPrevistoAnual = Convert.ToDecimal(dr["VLPrevistoAnual"]);
                        p.ArquivoAnexo = dr["DSArquivoAnexo"].ToString();
                        p.Status = dr["DSStatus"].ToString();
                    }

                    return p;
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

        public Parceria ObterUltimaCadastrada()
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Parceria p = new Parceria();

                    SqlCommand cmd1 = new SqlCommand("SELECT MAX(IDParceria) AS IDParceria FROM TB_Parceria", objConn);
                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    UnidadeDAL uDAL = new UnidadeDAL();

                    if (dr1.Read())
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT IDParceria,IDUnidade,NMParceria,DSTipo,DSObjetivo,DSObservacoes,BTPossuiPagamentoRH,BTPossuiRecursosFinanceiros,BTPossuiVigencia,DTInicioVigencia,DTFimVigencia,BTEmExecucao,VLPrevistoAnual,DSArquivoAnexo,DSStatus FROM TB_Parceria WHERE IDParceria = " + dr1["IDParceria"], objConn);
                        SqlDataReader dr2 = cmd2.ExecuteReader();

                        if (dr2.Read())
                        {
                            p.IdParceria = Convert.ToInt32(dr2["IDParceria"]);
                            p.Unidade = uDAL.CarregarDadosPorIdUnidade(Convert.ToInt32(dr2["IDUnidade"]));
                            p.Nome = dr2["NMParceria"].ToString();
                            p.Tipo = dr2["DSTipo"].ToString();
                            p.Objetivo = dr2["DSObjetivo"].ToString();
                            p.Observacoes = dr2["DSObservacoes"].ToString();
                            p.PossuiPagamentoRH = Convert.ToBoolean(dr2["BTPossuiPagamentoRH"]);
                            p.PossuiRecursosFinanceiros = Convert.ToBoolean(dr2["BTPossuiRecursosFinanceiros"]);
                            p.PossuiVigencia = Convert.ToBoolean(dr2["BTPossuiVigencia"]);
                            p.InicioVigencia = Convert.ToDateTime(dr2["DTInicioVigencia"]);
                            p.FimVigencia = Convert.ToDateTime(dr2["DTFimVigencia"]);
                            p.EmExecucao = Convert.ToBoolean(dr2["BTEmExecucao"]);
                            p.ValorPrevistoAnual = Convert.ToDecimal(dr2["VLPrevistoAnual"]);
                            p.ArquivoAnexo = dr2["DSArquivoAnexo"].ToString();
                            p.Status = dr2["DSStatus"].ToString();
                        }
                    }

                    return p;
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

                    Parceria p = (Parceria)obj;

                    SqlCommand cmd = new SqlCommand("UPDATE TB_Parceria SET IDUnidade=@IDUnidade,NMParceria=@NMParceria,DSTipo=@DSTipo,DSObjetivo=@DSObjetivo,DSObservacoes=@DSObservacoes,BTPossuiPagamentoRH=@BTPossuiPagamentoRH,BTPossuiRecursosFinanceiros=@BTPossuiRecursosFinanceiros,BTPossuiVigencia=@BTPossuiVigencia,DTInicioVigencia=@DTInicioVigencia,DTFimVigencia=@DTFimVigencia,BTEmExecucao=@BTEmExecucao,VLPrevistoAnual=@VLPrevistoAnual,DSArquivoAnexo=@DSArquivoAnexo,DSStatus=@DSStatus WHERE IDParceria=@IDParceria", objConn);
                    cmd.Parameters.Add("@IDUnidade", SqlDbType.Int).Value = p.Unidade.IdUnidade;
                    cmd.Parameters.Add("@NMParceria", SqlDbType.VarChar, 255).Value = p.Nome;
                    cmd.Parameters.Add("@DSTipo", SqlDbType.VarChar, 10).Value = p.Tipo;
                    cmd.Parameters.Add("@DSObjetivo", SqlDbType.Text).Value = p.Objetivo;
                    cmd.Parameters.Add("@DSObservacoes", SqlDbType.Text).Value = p.Observacoes;
                    cmd.Parameters.Add("@BTPossuiPagamentoRH", SqlDbType.Bit).Value = p.PossuiPagamentoRH;
                    cmd.Parameters.Add("@BTPossuiRecursosFinanceiros", SqlDbType.Bit).Value = p.PossuiRecursosFinanceiros;
                    cmd.Parameters.Add("@BTPossuiVigencia", SqlDbType.Bit).Value = p.PossuiVigencia;
                    cmd.Parameters.Add("@DTInicioVigencia", SqlDbType.SmallDateTime).Value = p.InicioVigencia;
                    cmd.Parameters.Add("@DTFimVigencia", SqlDbType.SmallDateTime).Value = p.FimVigencia;
                    cmd.Parameters.Add("@BTEmExecucao", SqlDbType.Bit).Value = p.EmExecucao;
                    cmd.Parameters.Add("@VLPrevistoAnual", SqlDbType.Decimal).Value = p.ValorPrevistoAnual;
                    cmd.Parameters.Add("@DSArquivoAnexo", SqlDbType.VarChar, 10).Value = p.ArquivoAnexo;
                    cmd.Parameters.Add("@DSStatus", SqlDbType.VarChar, 10).Value = p.Status;
                    cmd.Parameters.Add("@IDParceria", SqlDbType.Int).Value = p.IdParceria;

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

        public void Cadastrar(object obj)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Parceria p = (Parceria)obj;

                    SqlCommand cmd = new SqlCommand("INSERT INTO TB_Parceria(IDUnidade,NMParceria,DSTipo,DSObjetivo,DSObservacoes,BTPossuiPagamentoRH,BTPossuiRecursosFinanceiros,BTPossuiVigencia,DTInicioVigencia,DTFimVigencia,BTEmExecucao,VLPrevistoAnual,DSArquivoAnexo,DSStatus) VALUES(@IDUnidade,@NMParceria,@DSTipo,@DSObjetivo,@DSObservacoes,@BTPossuiPagamentoRH,@BTPossuiRecursosFinanceiros,@BTPossuiVigencia,@DTInicioVigencia,@DTFimVigencia,@BTEmExecucao,@VLPrevistoAnual,@DSArquivoAnexo,@DSStatus)", objConn);
                    cmd.Parameters.Add("@IDUnidade", SqlDbType.Int).Value = p.Unidade.IdUnidade;
                    cmd.Parameters.Add("@NMParceria", SqlDbType.VarChar, 255).Value = p.Nome;
                    cmd.Parameters.Add("@DSTipo", SqlDbType.VarChar, 10).Value = p.Tipo;
                    cmd.Parameters.Add("@DSObjetivo", SqlDbType.Text).Value = p.Objetivo;
                    cmd.Parameters.Add("@DSObservacoes", SqlDbType.Text).Value = p.Observacoes;
                    cmd.Parameters.Add("@BTPossuiPagamentoRH", SqlDbType.Bit).Value = p.PossuiPagamentoRH;
                    cmd.Parameters.Add("@BTPossuiRecursosFinanceiros", SqlDbType.Bit).Value = p.PossuiRecursosFinanceiros;
                    cmd.Parameters.Add("@BTPossuiVigencia", SqlDbType.Bit).Value = p.PossuiVigencia;
                    cmd.Parameters.Add("@DTInicioVigencia", SqlDbType.SmallDateTime).Value = p.InicioVigencia;
                    cmd.Parameters.Add("@DTFimVigencia", SqlDbType.SmallDateTime).Value = p.FimVigencia;
                    cmd.Parameters.Add("@BTEmExecucao", SqlDbType.Bit).Value = p.EmExecucao;
                    cmd.Parameters.Add("@VLPrevistoAnual", SqlDbType.Decimal).Value = p.ValorPrevistoAnual;
                    cmd.Parameters.Add("@DSArquivoAnexo", SqlDbType.VarChar, 10).Value = p.ArquivoAnexo;
                    cmd.Parameters.Add("@DSStatus", SqlDbType.VarChar, 10).Value = p.Status;

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
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Parceria p = (Parceria)obj;

                    // EXCLUI OS REPASSES DO CONVÊNIO //
                    RepasseParceriaDAL rcDAL = new RepasseParceriaDAL();
                    var repassesParceria = rcDAL.ListarPorParceria(p.IdParceria);

                    foreach (RepasseParceria rp in repassesParceria)
                    { rcDAL.Excluir(rp); }
                    // FIM //

                    SqlCommand cmd = new SqlCommand("DELETE FROM TB_Parceria WHERE IDParceria = @IDParceria", objConn);
                    cmd.Parameters.Add("@IDParceria", SqlDbType.Int).Value = p.IdParceria;
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

        public IList Listar()
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    UnidadeDAL uDAL = new UnidadeDAL();

                    IList lst = new List<Parceria>();

                    SqlCommand cmd = new SqlCommand("SELECT IDParceria,IDUnidade,NMParceria,DSTipo,DSObjetivo,DSObservacoes,BTPossuiPagamentoRH,BTPossuiRecursosFinanceiros,BTPossuiVigencia,DTInicioVigencia,DTFimVigencia,BTEmExecucao,VLPrevistoAnual,DSArquivoAnexo,DSStatus FROM TB_Parceria", objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(
                                new Parceria()
                                {
                                    IdParceria = Convert.ToInt32(dr["IDParceria"]),
                                    Unidade = uDAL.CarregarDadosPorIdUnidade(Convert.ToInt32(dr["IDUnidade"])),
                                    Nome = dr["NMParceria"].ToString(),
                                    Tipo = dr["DSTipo"].ToString(),
                                    Objetivo = dr["DSObjetivo"].ToString(),
                                    Observacoes = dr["DSObservacoes"].ToString(),
                                    PossuiPagamentoRH = Convert.ToBoolean(dr["BTPossuiPagamentoRH"]),
                                    PossuiRecursosFinanceiros = Convert.ToBoolean(dr["BTPossuiRecursosFinanceiros"]),
                                    PossuiVigencia = Convert.ToBoolean(dr["BTPossuiVigencia"]),
                                    InicioVigencia = Convert.ToDateTime(dr["DTInicioVigencia"]),
                                    FimVigencia = Convert.ToDateTime(dr["DTFimVigencia"]),
                                    EmExecucao = Convert.ToBoolean(dr["BTEmExecucao"]),
                                    ValorPrevistoAnual = Convert.ToDecimal(dr["VLPrevistoAnual"]),
                                    ArquivoAnexo = dr["DSArquivoAnexo"].ToString(),
                                    Status = dr["DSStatus"].ToString()
                                }
                        );
                    }

                    return lst;
                }
                catch (Exception)
                { throw; }
                finally
                { objConn.Close(); }
            }
        }

        public IList ListarPorUnidade(int _IdUnidade)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    UnidadeDAL uDAL = new UnidadeDAL();

                    IList lst = new List<Parceria>();

                    SqlCommand cmd = new SqlCommand("SELECT IDParceria,IDUnidade,NMParceria,DSObjetivo,DSObservacoes,BTPossuiPagamentoRH,BTPossuiRecursosFinanceiros,BTPossuiVigencia,DTInicioVigencia,DTFimVigencia,BTEmExecucao,VLPrevistoAnual,DSArquivoAnexo,DSStatus FROM TB_Parceria WHERE IDUnidade = " + _IdUnidade, objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(
                                new Parceria()
                                {
                                    IdParceria = Convert.ToInt32(dr["IDParceria"]),
                                    Unidade = uDAL.CarregarDadosPorIdUnidade(Convert.ToInt32(dr["IDUnidade"])),
                                    Nome = dr["NMParceria"].ToString(),
                                    Objetivo = dr["DSObjetivo"].ToString(),
                                    Observacoes = dr["DSObservacoes"].ToString(),
                                    PossuiPagamentoRH = Convert.ToBoolean(dr["BTPossuiPagamentoRH"]),
                                    PossuiRecursosFinanceiros = Convert.ToBoolean(dr["BTPossuiRecursosFinanceiros"]),
                                    PossuiVigencia = Convert.ToBoolean(dr["BTPossuiVigencia"]),
                                    InicioVigencia = Convert.ToDateTime(dr["DTInicioVigencia"]),
                                    FimVigencia = Convert.ToDateTime(dr["DTFimVigencia"]),
                                    EmExecucao = Convert.ToBoolean(dr["BTEmExecucao"]),
                                    ValorPrevistoAnual = Convert.ToDecimal(dr["VLPrevistoAnual"]),
                                    ArquivoAnexo = dr["DSArquivoAnexo"].ToString(),
                                    Status = dr["DSStatus"].ToString()
                                }
                        );
                    }

                    return lst;
                }
                catch (Exception)
                { throw; }
                finally
                { objConn.Close(); }
            }
        }
    }
}
