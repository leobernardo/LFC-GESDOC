using System;
using System.Collections;
using System.Collections.Generic;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using LFC.GesDoc.Interfaces;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.DAL
{
    public class RepasseParceriaDAL : IDal
    {
        public RepasseParceria ObterDadosPorId(int _IdRepasseParceria)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    RepasseParceria rp = new RepasseParceria();

                    SqlCommand cmd = new SqlCommand("SELECT IDRepasseParceria,IDParceria,DTVencimento,DTRepasse,VLRepasse,DSStatus FROM TB_RepasseParceria WHERE IDRepasseParceria = " + _IdRepasseParceria, objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    ParceriaDAL pDAL = new ParceriaDAL();

                    if (dr.Read())
                    {
                        rp.IdRepasseParceria = Convert.ToInt32(dr["IDRepasseParceria"]);
                        rp.Parceria = pDAL.ObterDadosPorId(Convert.ToInt32(dr["IDParceria"]));
                        rp.DataVencimento = Convert.ToDateTime(dr["DTVencimento"]);

                        if (dr["DTRepasse"] != DBNull.Value)
                        { rp.DataRepasse = Convert.ToDateTime(dr["DTRepasse"]); }

                        rp.ValorRepasse = Convert.ToDecimal(dr["VLRepasse"]);
                        rp.Status = dr["DSStatus"].ToString();
                    }

                    return rp;
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

                    RepasseParceria rc = (RepasseParceria)obj;

                    SqlCommand cmd = new SqlCommand("UPDATE TB_RepasseParceria SET IDParceria=@IDParceria,DTVencimento=@DTVencimento,DTRepasse=@DTRepasse,VLRepasse=@VLRepasse,DSStatus=@DSStatus WHERE IDRepasseParceria=@IDRepasseParceria", objConn);
                    cmd.Parameters.Add("@IDParceria", SqlDbType.Int).Value = rc.Parceria.IdParceria;
                    cmd.Parameters.Add("@DTVencimento", SqlDbType.SmallDateTime).Value = rc.DataVencimento;
                    cmd.Parameters.Add("@DTRepasse", SqlDbType.SmallDateTime).Value = rc.DataRepasse;
                    cmd.Parameters.Add("@VLRepasse", SqlDbType.Decimal).Value = rc.ValorRepasse;
                    cmd.Parameters.Add("@DSStatus", SqlDbType.VarChar, 10).Value = rc.Status;
                    cmd.Parameters.Add("@IDRepasseParceria", SqlDbType.Int).Value = rc.IdRepasseParceria;

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

                    RepasseParceria rc = (RepasseParceria)obj;

                    SqlCommand cmd = new SqlCommand("INSERT INTO TB_RepasseParceria(IDParceria,DTVencimento,DTRepasse,VLRepasse,DSStatus) VALUES(@IDParceria,@DTVencimento,@DTRepasse,@VLRepasse,@DSStatus)", objConn);
                    cmd.Parameters.Add("@IDParceria", SqlDbType.Int).Value = rc.Parceria.IdParceria;
                    cmd.Parameters.Add("@DTVencimento", SqlDbType.SmallDateTime).Value = rc.DataVencimento;
                    cmd.Parameters.Add("@DTRepasse", SqlDbType.SmallDateTime).Value = rc.DataRepasse;
                    cmd.Parameters.Add("@VLRepasse", SqlDbType.Decimal).Value = rc.ValorRepasse;
                    cmd.Parameters.Add("@DSStatus", SqlDbType.VarChar, 10).Value = rc.Status;

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

                    RepasseParceria rc = (RepasseParceria)obj;

                    SqlCommand cmd = new SqlCommand("DELETE FROM TB_RepasseParceria WHERE IDRepasseParceria = @IDRepasseParceria", objConn);
                    cmd.Parameters.Add("@IDRepasseParceria", SqlDbType.Int).Value = rc.IdRepasseParceria;
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
            throw new NotImplementedException();
        }

        public IList ListarPorParceria(int _IdParceria)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    ParceriaDAL pDAL = new ParceriaDAL();

                    IList lst = new List<RepasseParceria>();

                    SqlCommand cmd = new SqlCommand("SELECT IDRepasseParceria,IDParceria,DTVencimento,DTRepasse,VLRepasse,DSStatus FROM TB_RepasseParceria WHERE IDParceria = " + _IdParceria, objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(
                                new RepasseParceria()
                                {
                                    IdRepasseParceria = Convert.ToInt32(dr["IDRepasseParceria"]),
                                    Parceria = pDAL.ObterDadosPorId(Convert.ToInt32(dr["IDParceria"])),
                                    DataVencimento = Convert.ToDateTime(dr["DTVencimento"]),
                                    DataRepasse = Convert.ToDateTime(dr["DTRepasse"]),
                                    ValorRepasse = Convert.ToDecimal(dr["VLRepasse"]),
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
