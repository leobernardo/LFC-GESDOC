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
    public class TipoDocumentoDAL : IDal
    {
        public TipoDocumento ObterDadosPorId(int _IdTipoDocumento)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    TipoDocumento td = new TipoDocumento();

                    SqlCommand cmd = new SqlCommand("SELECT IDTipoDocumento,DSTipoDocumento,DSGuardaInterna,DSGuardaExterna FROM TB_TipoDocumento WHERE IDTipoDocumento = " + _IdTipoDocumento, objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        td.IDTipoDocumento = Convert.ToInt32(dr["IDTipoDocumento"]);
                        td.DSTipoDocumento = dr["DSTipoDocumento"].ToString();
                        td.DSGuardaInterna = dr["DSGuardaInterna"].ToString();
                        td.DSGuardaExterna = dr["DSGuardaExterna"].ToString();
                    }

                    return td;
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

                    IList lst = new List<TipoDocumento>();

                    SqlCommand cmd = new SqlCommand("SELECT IDTipoDocumento,DSTipoDocumento,DSGuardaInterna,DSGuardaExterna FROM TB_TipoDocumento Order By DSTipoDocumento", objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(
                                new TipoDocumento()
                                {
                                    IDTipoDocumento = Convert.ToInt32(dr["IDTipoDocumento"]),
                                    DSTipoDocumento = dr["DSTipoDocumento"].ToString(),
                                    DSGuardaInterna = dr["DSGuardaInterna"].ToString(),
                                    DSGuardaExterna = dr["DSGuardaExterna"].ToString()
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

                    TipoDocumento td = (TipoDocumento)obj;

                    SqlCommand cmd = new SqlCommand("INSERT INTO TB_TipoDocumento(DSTipoDocumento,DSGuardaInterna,DSGuardaExterna) VALUES(@DSTipoDocumento,@DSGuardaInterna,@DSGuardaExterna)", objConn);
                    cmd.Parameters.Add("@DSTipoDocumento", SqlDbType.VarChar, 100).Value = td.DSTipoDocumento;
                    cmd.Parameters.Add("@DSGuardaInterna", SqlDbType.VarChar, 100).Value = td.DSGuardaInterna;
                    cmd.Parameters.Add("@DSGuardaExterna", SqlDbType.VarChar, 100).Value = td.DSGuardaExterna;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                { throw; }
                finally
                { objConn.Close(); }
            }
        }

        public void Excluir(object obj)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    TipoDocumento td = (TipoDocumento)obj;

                    SqlCommand cmd = new SqlCommand("DELETE FROM TB_TipoDocumento WHERE IDTipoDocumento = @IDTipoDocumento", objConn);
                    cmd.Parameters.Add("@IDTipoDocumento", SqlDbType.Int).Value = td.IDTipoDocumento;
                    cmd.ExecuteNonQuery();
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

                    TipoDocumento td = (TipoDocumento)obj;

                    SqlCommand cmd = new SqlCommand("UPDATE TB_TipoDocumento SET DSTipoDocumento=@DSTipoDocumento,DSGuardaInterna=@DSGuardaInterna,DSGuardaExterna=@DSGuardaExterna WHERE IDTipoDocumento=@IDTipoDocumento", objConn);
                    cmd.Parameters.Add("@DSTipoDocumento", SqlDbType.VarChar, 100).Value = td.DSTipoDocumento;
                    cmd.Parameters.Add("@DSGuardaInterna", SqlDbType.VarChar, 100).Value = td.DSGuardaInterna;
                    cmd.Parameters.Add("@DSGuardaExterna", SqlDbType.VarChar, 100).Value = td.DSGuardaExterna;
                    cmd.Parameters.Add("@IDTipoDocumento", SqlDbType.Int).Value = td.IDTipoDocumento;

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
