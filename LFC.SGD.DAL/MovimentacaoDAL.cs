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
    public class MovimentacaoDAL : IDal
    {
        public Movimentacao CarregarDadosPorIdMovimentacao(Int32 _IdMovimentacao)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Movimentacao m = new Movimentacao();

                    SqlCommand cmd = new SqlCommand("SELECT idMovimentacao,idDocumento,setorOrigem,setorDestino,movimentadoPor,dataHoraMovimentacao,recebido,recebidoPor,dataHoraRecebimento,prazo,despacho,entreguePara,alertaPrazo FROM tbMovimentacoes WHERE idMovimentacao = " + _IdMovimentacao, objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    DocumentoDAL dDAL = new DocumentoDAL();
                    
                    if (dr.Read())
                    {
                        m.IdMovimentacao = Convert.ToInt32(dr["idMovimentacao"]);
                        m.Documento = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(dr["idDocumento"]));
                        m.ProcessoOrigem = Convert.ToInt32(dr["setorOrigem"]);
                        m.ProcessoDestino = Convert.ToInt32(dr["setorDestino"]);
                        m.MovimentadoPor = dr["movimentadoPor"].ToString();
                        m.DataHoraMovimentacao = dr["dataHoraMovimentacao"].ToString();
                        m.Recebido = dr["recebido"].ToString();
                        m.RecebidoPor = dr["recebidoPor"].ToString();
                        m.DataHoraRecebimento = dr["dataHoraRecebimento"].ToString();
                        m.Prazo = Convert.ToDateTime(dr["prazo"]);
                        m.Despacho = dr["despacho"].ToString();
                        m.EntreguePara = dr["entreguePara"].ToString();
                        m.AlertaPrazo = dr["alertaPrazo"].ToString();
                    }

                    return m;
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

        public IList ListarPorIdDocumento(Int32 _IdDocumento)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    IList lst = new List<Movimentacao>();

                    SqlCommand cmd = new SqlCommand("SELECT idMovimentacao,idDocumento,setorOrigem,setorDestino,movimentadoPor,dataHoraMovimentacao,recebido,recebidoPor,dataHoraRecebimento,prazo,despacho,entreguePara,alertaPrazo FROM tbMovimentacoes WHERE idDocumento = " + _IdDocumento + " ORDER BY idMovimentacao DESC", objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    DocumentoDAL dDAL = new DocumentoDAL();

                    while (dr.Read())
                    {
                        lst.Add(
                                new Movimentacao()
                                {
                                    IdMovimentacao = Convert.ToInt32(dr["idMovimentacao"]),
                                    Documento = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(dr["idDocumento"])),
                                    ProcessoOrigem = Convert.ToInt32(dr["setorOrigem"]),
                                    ProcessoDestino = Convert.ToInt32(dr["setorDestino"]),
                                    MovimentadoPor = dr["movimentadoPor"].ToString(),
                                    DataHoraMovimentacao = dr["dataHoraMovimentacao"].ToString(),
                                    Recebido = dr["recebido"].ToString(),
                                    RecebidoPor = dr["recebidoPor"].ToString(),
                                    DataHoraRecebimento = dr["dataHoraRecebimento"].ToString(),
                                    Prazo = Convert.ToDateTime(dr["prazo"]),
                                    Despacho = dr["despacho"].ToString(),
                                    EntreguePara = dr["entreguePara"].ToString(),
                                    AlertaPrazo = dr["alertaPrazo"].ToString()
                                }
                        );
                    }

                    return lst;
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

        public IList ListarPorProcessoDestinoRecebido(Int32 _ProcessoDestino, String _Recebido)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    IList lst = new List<Movimentacao>();

                    SqlCommand cmd = new SqlCommand("SELECT idMovimentacao,idDocumento,setorOrigem,setorDestino,movimentadoPor,dataHoraMovimentacao,recebido,recebidoPor,dataHoraRecebimento,prazo,despacho,entreguePara,alertaPrazo FROM tbMovimentacoes WHERE setorDestino = " + _ProcessoDestino + " And recebido = '" + _Recebido + "'", objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    DocumentoDAL dDAL = new DocumentoDAL();

                    while (dr.Read())
                    {
                        lst.Add(
                                new Movimentacao()
                                {
                                    IdMovimentacao = Convert.ToInt32(dr["idMovimentacao"]),
                                    Documento = dDAL.CarregarDadosPorIdDocumento(Convert.ToInt32(dr["idDocumento"])),
                                    ProcessoOrigem = Convert.ToInt32(dr["setorOrigem"]),
                                    ProcessoDestino = Convert.ToInt32(dr["setorDestino"]),
                                    MovimentadoPor = dr["movimentadoPor"].ToString(),
                                    DataHoraMovimentacao = dr["dataHoraMovimentacao"].ToString(),
                                    Recebido = dr["recebido"].ToString(),
                                    RecebidoPor = dr["recebidoPor"].ToString(),
                                    DataHoraRecebimento = dr["dataHoraRecebimento"].ToString(),
                                    Prazo = Convert.ToDateTime(dr["prazo"]),
                                    Despacho = dr["despacho"].ToString(),
                                    EntreguePara = dr["entreguePara"].ToString(),
                                    AlertaPrazo = dr["alertaPrazo"].ToString()
                                }
                        );
                    }

                    return lst;
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

                    Movimentacao m = (Movimentacao)obj;

                    SqlCommand cmd = new SqlCommand("INSERT INTO tbMovimentacoes(idDocumento,setorOrigem,setorDestino,dataHoraMovimentacao,movimentadoPor,recebido,dataHoraRecebimento,prazo,despacho,entreguePara,alertaPrazo) VALUES(@IdDocumento,@SetorOrigem,@SetorDestino,@DataHoraMovimentacao,@MovimentadoPor,@Recebido,@DataHoraRecebimento,@Prazo,@Despacho,@EntreguePara,@AlertaPrazo)", objConn);
                    cmd.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = m.Documento.IdDocumento;
                    cmd.Parameters.Add("@SetorOrigem", SqlDbType.Int).Value = m.ProcessoOrigem;
                    cmd.Parameters.Add("@SetorDestino", SqlDbType.Int).Value = m.ProcessoDestino;
                    cmd.Parameters.Add("@DataHoraMovimentacao", SqlDbType.VarChar, 20).Value = m.DataHoraMovimentacao;
                    cmd.Parameters.Add("@MovimentadoPor", SqlDbType.VarChar, 100).Value = m.MovimentadoPor;
                    cmd.Parameters.Add("@Recebido", SqlDbType.VarChar, 3).Value = m.Recebido;
                    cmd.Parameters.Add("@DataHoraRecebimento", SqlDbType.VarChar, 20).Value = m.DataHoraRecebimento;
                    cmd.Parameters.Add("@Prazo", SqlDbType.Date).Value = m.Prazo;
                    cmd.Parameters.Add("@Despacho", SqlDbType.Text).Value = m.Despacho;
                    cmd.Parameters.Add("@EntreguePara", SqlDbType.VarChar, 100).Value = m.EntreguePara;
                    cmd.Parameters.Add("@AlertaPrazo", SqlDbType.VarChar, 3).Value = m.AlertaPrazo;
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

        public void Alterar(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
