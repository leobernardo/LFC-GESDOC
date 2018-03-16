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
    public class ProcessoDAL : IDal
    {
        public Processo ObterDadosPorId(int _IdProcesso)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Processo p = new Processo();

                    SqlCommand cmd = new SqlCommand("SELECT IDProcesso,DSProcesso,NRPrazoMaximo,DSEmail,BTAtivo FROM TB_Processo WHERE IDProcesso = " + _IdProcesso, objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        p.IDProcesso = Convert.ToInt32(dr["IDProcesso"]);
                        p.DSProcesso = dr["DSProcesso"].ToString();
                        p.NRPrazoMaximo = Convert.ToInt32(dr["NRPrazoMaximo"]);
                        p.DSEmail = dr["DSEmail"].ToString();
                        p.BTAtivo = Convert.ToBoolean(dr["BTAtivo"]);
                    }

                    return p;
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

                    IList lst = new List<Processo>();

                    SqlCommand cmd = new SqlCommand("SELECT IDProcesso,DSProcesso,NRPrazoMaximo,DSEmail,BTAtivo FROM TB_Processo ORDER BY DSProcesso", objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(
                                new Processo()
                                {
                                    IDProcesso = Convert.ToInt32(dr["IDProcesso"]),
                                    DSProcesso = dr["DSProcesso"].ToString(),
                                    NRPrazoMaximo = Convert.ToInt32(dr["NRPrazoMaximo"]),
                                    DSEmail = dr["DSEmail"].ToString(),
                                    BTAtivo = Convert.ToBoolean(dr["BTAtivo"])
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

        public void Cadastrar(object obj)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Processo p = (Processo)obj;

                    SqlCommand cmd = new SqlCommand("INSERT INTO TB_Processo(DSProcesso,NRPrazoMaximo,DSEmail,BTAtivo) VALUES(@DSProcesso,@NRPrazoMaximo,@DSEmail,@BTAtivo)", objConn);
                    cmd.Parameters.Add("@DSProcesso", SqlDbType.VarChar, 100).Value = p.DSProcesso;
                    cmd.Parameters.Add("@NRPrazoMaximo", SqlDbType.Int).Value = p.NRPrazoMaximo;
                    cmd.Parameters.Add("@DSEmail", SqlDbType.VarChar, 60).Value = p.DSEmail;
                    cmd.Parameters.Add("@BTAtivo", SqlDbType.Bit).Value = p.BTAtivo;

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

                    Processo p = (Processo)obj;

                    SqlCommand cmd_1 = new SqlCommand("DELETE FROM TB_Usuario WHERE IDProcesso = @IDProcesso", objConn);
                    cmd_1.Parameters.Add("@IDProcesso", SqlDbType.Int).Value = p.IDProcesso;
                    cmd_1.ExecuteNonQuery();

                    SqlCommand cmd_2 = new SqlCommand("DELETE FROM TB_Processo WHERE IDProcesso = @IDProcesso", objConn);
                    cmd_2.Parameters.Add("@IDProcesso", SqlDbType.Int).Value = p.IDProcesso;
                    cmd_2.ExecuteNonQuery();
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

                    Processo p = (Processo)obj;

                    SqlCommand cmd = new SqlCommand("UPDATE TB_Processo SET DSProcesso=@DSProcesso,NRPrazoMaximo=@NRPrazoMaximo,DSEmail=@DSEmail,BTAtivo=@BTAtivo WHERE IDProcesso=@IDProcesso", objConn);
                    cmd.Parameters.Add("@DSProcesso", SqlDbType.VarChar, 100).Value = p.DSProcesso;
                    cmd.Parameters.Add("@NRPrazoMaximo", SqlDbType.Int).Value = p.NRPrazoMaximo;
                    cmd.Parameters.Add("@DSEmail", SqlDbType.VarChar, 60).Value = p.DSEmail;
                    cmd.Parameters.Add("@BTAtivo", SqlDbType.Bit).Value = p.BTAtivo;
                    cmd.Parameters.Add("@IDProcesso", SqlDbType.Int).Value = p.IDProcesso;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                { throw; }
                finally
                { objConn.Close(); }
            }   
        }
    }
}
