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
    public class UsuarioDAL : IDal
    {
        public Usuario ObterDadosPorId(int _IdUsuario)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Usuario u = new Usuario();

                    SqlCommand cmd = new SqlCommand("SELECT IDUsuario,IDProcesso,DSNome,DTNascimento,DSTelefone1,DSTelefone2,DSTelefone3,DSEmail,DSSenha,DSNivelAcesso,BTAtivo FROM TB_Usuario WHERE IDUsuario = " + _IdUsuario, objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    ProcessoDAL pDAL = new ProcessoDAL();

                    if (dr.Read())
                    {
                        u.IDUsuario = Convert.ToInt32(dr["IDUsuario"]);
                        u.Processo = pDAL.ObterDadosPorId(Convert.ToInt32(dr["IDProcesso"]));
                        u.DSNome = dr["DSNome"].ToString();

                        if (dr["DTNascimento"] != DBNull.Value)
                        { u.DTNascimento = Convert.ToDateTime(dr["DTNascimento"]); }

                        u.DSTelefone1 = dr["DSTelefone1"].ToString();
                        u.DSTelefone2 = dr["DSTelefone2"].ToString();
                        u.DSTelefone3 = dr["DSTelefone3"].ToString();
                        u.DSEmail = dr["DSEmail"].ToString();
                        u.DSSenha = dr["DSSenha"].ToString();
                        u.DSNivelAcesso = dr["DSNivelAcesso"].ToString();
                        u.BTAtivo = Convert.ToBoolean(dr["BTAtivo"]);
                    }

                    return u;
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

        public void Autenticar(string _Email, string _Senha)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT IDUsuario,IDProcesso,DSEmail,DSNivelAcesso FROM TB_Usuario WHERE DSEmail = @DSEmail AND DSSenha = @DSSenha AND BTAtivo = 1", objConn);
                    cmd.Parameters.Add("@DSEmail", SqlDbType.VarChar, 60).Value = _Email;
                    cmd.Parameters.Add("@DSSenha", SqlDbType.VarChar, 15).Value = _Senha;
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        UsuarioDAL uDAL = new UsuarioDAL();

                        HttpContext.Current.Session["sesIdUsuario"] = dr["IDUsuario"];
                        HttpContext.Current.Session["sesIdProcesso"] = dr["IDProcesso"];
                        HttpContext.Current.Session["sesEmail"] = dr["DSEmail"];
                        HttpContext.Current.Session["sesNivelAcesso"] = dr["DSNivelAcesso"];

                        HttpContext.Current.Response.Redirect("Home/Default.aspx");
                    }
                    else
                    { HttpContext.Current.Response.Write("<script language='JavaScript'>alert('E-mail ou DSSenha incorretos');history.go(-1);</script>"); }
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

                    IList lst = new List<Usuario>();

                    SqlCommand cmd = new SqlCommand("SELECT IDUsuario,IDProcesso,DSNome,DTNascimento,DSTelefone1,DSTelefone2,DSTelefone3,DSEmail,DSSenha,DSNivelAcesso,BTAtivo FROM TB_Usuario WHERE IDUsuario <> 1", objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    ProcessoDAL pDAL = new ProcessoDAL();

                    while (dr.Read())
                    {
                        DateTime dtNascimento = new DateTime(1900, 1, 1);

                        if (dr["DTNascimento"] != DBNull.Value)
                        { dtNascimento = Convert.ToDateTime(dr["DTNascimento"]); }

                        lst.Add(
                                new Usuario()
                                {
                                    IDUsuario = Convert.ToInt32(dr["IDUsuario"]),
                                    Processo = pDAL.ObterDadosPorId(Convert.ToInt32(dr["IDProcesso"])),
                                    DSNome = dr["DSNome"].ToString(),
                                    DTNascimento = dtNascimento,
                                    DSTelefone1 = dr["DSTelefone1"].ToString(),
                                    DSTelefone2 = dr["DSTelefone2"].ToString(),
                                    DSTelefone3 = dr["DSTelefone3"].ToString(),
                                    DSEmail = dr["DSEmail"].ToString(),
                                    DSSenha = dr["DSSenha"].ToString(),
                                    DSNivelAcesso = dr["DSNivelAcesso"].ToString(),
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

                    Usuario u = (Usuario)obj;

                    SqlCommand cmd = new SqlCommand("INSERT INTO TB_Usuario(IDProcesso,DSNome,DTNascimento,DSTelefone1,DSTelefone2,DSTelefone3,DSEmail,DSSenha,DSNivelAcesso,BTAtivo) VALUES(@IDProcesso,@DSNome,@DTNascimento,@DSTelefone1,@DSTelefone2,@DSTelefone3,@DSEmail,@DSSenha,@DSNivelAcesso,@BTAtivo)", objConn);
                    cmd.Parameters.Add("@IDProcesso", SqlDbType.Int).Value = u.Processo.IDProcesso;
                    cmd.Parameters.Add("@DSNome", SqlDbType.VarChar, 100).Value = u.DSNome;
                    cmd.Parameters.Add("@DTNascimento", SqlDbType.Date).Value = u.DTNascimento;
                    cmd.Parameters.Add("@DSTelefone1", SqlDbType.VarChar, 15).Value = u.DSTelefone1;
                    cmd.Parameters.Add("@DSTelefone2", SqlDbType.VarChar, 20).Value = u.DSTelefone2;
                    cmd.Parameters.Add("@DSTelefone3", SqlDbType.VarChar, 20).Value = u.DSTelefone3;
                    cmd.Parameters.Add("@DSEmail", SqlDbType.VarChar, 60).Value = u.DSEmail;
                    cmd.Parameters.Add("@DSSenha", SqlDbType.VarChar, 15).Value = u.DSSenha;
                    cmd.Parameters.Add("@DSNivelAcesso", SqlDbType.VarChar, 20).Value = u.DSNivelAcesso;
                    cmd.Parameters.Add("@BTAtivo", SqlDbType.Bit).Value = u.BTAtivo;

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

                    Usuario u = (Usuario)obj;

                    SqlCommand cmd = new SqlCommand("DELETE FROM TB_Usuario WHERE IDUsuario = @IDUsuario", objConn);
                    cmd.Parameters.Add("@IDUsuario", SqlDbType.Int).Value = u.IDUsuario;
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

                    Usuario u = (Usuario)obj;

                    SqlCommand cmd = new SqlCommand("UPDATE TB_Usuario SET IDProcesso=@IDProcesso,DSNome=@DSNome,DTNascimento=@DTNascimento,DSTelefone1=@DSTelefone1,DSTelefone2=@DSTelefone2,DSTelefone3=@DSTelefone3,DSEmail=@DSEmail,DSSenha=@DSSenha,DSNivelAcesso=@DSNivelAcesso,BTAtivo=@BTAtivo WHERE IDUsuario=@IDUsuario", objConn);
                    cmd.Parameters.Add("@IDProcesso", SqlDbType.Int).Value = u.Processo.IDProcesso;
                    cmd.Parameters.Add("@DSNome", SqlDbType.VarChar, 100).Value = u.DSNome;
                    cmd.Parameters.Add("@DTNascimento", SqlDbType.Date).Value = u.DTNascimento;
                    cmd.Parameters.Add("@DSTelefone1", SqlDbType.VarChar, 15).Value = u.DSTelefone1;
                    cmd.Parameters.Add("@DSTelefone2", SqlDbType.VarChar, 20).Value = u.DSTelefone2;
                    cmd.Parameters.Add("@DSTelefone3", SqlDbType.VarChar, 20).Value = u.DSTelefone3;
                    cmd.Parameters.Add("@DSEmail", SqlDbType.VarChar, 60).Value = u.DSEmail;
                    cmd.Parameters.Add("@DSSenha", SqlDbType.VarChar, 15).Value = u.DSSenha;
                    cmd.Parameters.Add("@DSNivelAcesso", SqlDbType.VarChar, 20).Value = u.DSNivelAcesso;
                    cmd.Parameters.Add("@BTAtivo", SqlDbType.Bit).Value = u.BTAtivo;
                    cmd.Parameters.Add("@IDUsuario", SqlDbType.Int).Value = u.IDUsuario;

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
