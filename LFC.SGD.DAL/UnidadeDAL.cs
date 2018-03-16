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
    public class UnidadeDAL : IDal
    {
        public Unidade CarregarDadosPorIdUnidade(Int32 _IdUnidade)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Unidade u = new Unidade();

                    SqlCommand cmd = new SqlCommand("SELECT IDUnidade,DSUnidade,BTAtivo FROM TB_Unidade WHERE IDUnidade = " + _IdUnidade, objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        u.IdUnidade = Convert.ToInt32(dr["IDUnidade"]);
                        u.Descricao = dr["DSUnidade"].ToString();
                        u.Ativo = Convert.ToBoolean(dr["BTAtivo"]);
                    }

                    return u;
                }
                catch (Exception)
                { throw; }
                finally
                { objConn.Close(); }
            }
        }

        public IList Listar()
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    IList lst = new List<Unidade>();

                    SqlCommand cmd = new SqlCommand("SELECT IDUnidade,DSUnidade,BTAtivo FROM TB_Unidade", objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(
                                new Unidade()
                                {
                                    IdUnidade = Convert.ToInt32(dr["IDUnidade"]),
                                    Descricao = dr["DSUnidade"].ToString(),
                                    Ativo = Convert.ToBoolean(dr["BTAtivo"])
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

        public void Alterar(object obj)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Unidade u = (Unidade)obj;

                    SqlCommand cmd = new SqlCommand("UPDATE TB_Unidade SET DSUnidade=@DSUnidade,BTAtivo=@BTAtivo WHERE IDUnidade=@IDUnidade", objConn);
                    cmd.Parameters.Add("@DSUnidade", SqlDbType.VarChar, 100).Value = u.Descricao;
                    cmd.Parameters.Add("@BTAtivo", SqlDbType.Bit).Value = u.Ativo;
                    cmd.Parameters.Add("@IDUnidade", SqlDbType.Int).Value = u.IdUnidade;

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

                    Unidade u = (Unidade)obj;

                    SqlCommand cmd = new SqlCommand("INSERT INTO TB_Unidade(DSUnidade,BTAtivo) VALUES(@DSUnidade,@BTAtivo)", objConn);
                    cmd.Parameters.Add("@DSUnidade", SqlDbType.VarChar, 100).Value = u.Descricao;
                    cmd.Parameters.Add("@BTAtivo", SqlDbType.Bit).Value = u.Ativo;

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

                    Unidade u = (Unidade)obj;

                    SqlCommand cmd = new SqlCommand("DELETE FROM TB_Unidade WHERE IDUnidade = @IDUnidade", objConn);
                    cmd.Parameters.Add("@IDUnidade", SqlDbType.Int).Value = u.IdUnidade;
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
