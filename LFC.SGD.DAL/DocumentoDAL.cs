using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Web;

using System.Data;
using System.Data.SqlClient;

using LFC.GesDoc.Interfaces;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.DAL
{
    public class DocumentoDAL : IDal
    {
        public Documento CarregarDadosPorIdDocumento(Int32 _IdDocumento)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Documento d = new Documento();

                    SqlCommand cmd = new SqlCommand("SELECT idDocumento,idTipoDocumento,numero,nomePortador,rg,numeroInss,cpfCnpj,vigencia,vencimentoVigencia,dataEmissao,dataEmissao,dataAssinatura,dataCadastro,descarte,setorAtual,arquivado,alertaVencimentoVigencia,dataPagamentoRecebimento,numeroParcelas,valorPrevistoParcela,arquivo,ativo FROM tbDocumentos WHERE idDocumento = " + _IdDocumento, objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();
                    
                    if (dr.Read())
                    {
                        d.IdDocumento = Convert.ToInt32(dr["idDocumento"]);
                        d.TipoDocumento = tdDAL.ObterDadosPorId(Convert.ToInt32(dr["idTipoDocumento"]));
                        d.Descricao = dr["numero"].ToString();
                        d.NomePortador = dr["nomePortador"].ToString();
                        d.RG = dr["rg"].ToString();
                        d.NumeroINSS = dr["numeroInss"].ToString();
                        d.CPFCNPJ = dr["cpfCnpj"].ToString();
                        d.Vigencia = Convert.ToInt32(dr["vigencia"]);

                        if (dr["vencimentoVigencia"] != DBNull.Value)
                        { d.VencimentoVigencia = Convert.ToDateTime(dr["vencimentoVigencia"]); }

                        if (dr["dataEmissao"] != DBNull.Value)
                        { d.DataEmissao = Convert.ToDateTime(dr["dataEmissao"]); }

                        if (dr["dataAssinatura"] != DBNull.Value)
                        { d.DataAssinatura = Convert.ToDateTime(dr["dataAssinatura"]); }

                        d.DataCadastro = Convert.ToDateTime(dr["dataCadastro"]);

                        if (dr["descarte"] != DBNull.Value)
                        { d.Descarte = Convert.ToDateTime(dr["descarte"]); }

                        d.SetorAtual = Convert.ToInt32(dr["setorAtual"]);
                        d.Arquivado = dr["arquivado"].ToString();
                        d.AlertaVencimentoVigencia = dr["alertaVencimentoVigencia"].ToString();

                        if (dr["dataPagamentoRecebimento"] != DBNull.Value)
                        { d.DataPagamentoRecebimento = Convert.ToDateTime(dr["dataPagamentoRecebimento"]); }

                        d.NumeroParcelas = dr["numeroParcelas"].ToString();
                        d.ValorPrevistoParcela = dr["valorPrevistoParcela"].ToString();
                        d.Arquivo = dr["arquivo"].ToString();
                        d.Ativo = dr["ativo"].ToString();
                    }

                    return d;
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

        public Documento CarregarDadosUltimoCadastrado()
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();

                    Documento d = new Documento();

                    SqlCommand cmd1 = new SqlCommand("SELECT MAX(idDocumento) AS idDocumento FROM tbDocumentos", objConn);
                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    if (dr1.Read())
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT idDocumento,idTipoDocumento,numero,nomePortador,rg,numeroInss,cpfCnpj,vigencia,vencimentoVigencia,dataEmissao,dataEmissao,dataAssinatura,dataCadastro,descarte,setorAtual,arquivado,alertaVencimentoVigencia,dataPagamentoRecebimento,numeroParcelas,valorPrevistoParcela,arquivo,ativo FROM tbDocumentos WHERE idDocumento = " + dr1["idDocumento"].ToString(), objConn);
                        SqlDataReader dr2 = cmd2.ExecuteReader();

                        if (dr2.Read())
                        {
                            d.IdDocumento = Convert.ToInt32(dr2["idDocumento"]);
                            d.TipoDocumento = tdDAL.ObterDadosPorId(Convert.ToInt32(dr2["idTipoDocumento"]));
                            d.Descricao = dr2["numero"].ToString();
                            d.NomePortador = dr2["nomePortador"].ToString();
                            d.RG = dr2["rg"].ToString();
                            d.NumeroINSS = dr2["numeroInss"].ToString();
                            d.CPFCNPJ = dr2["cpfCnpj"].ToString();
                            d.Vigencia = Convert.ToInt32(dr2["vigencia"]);

                            if (dr2["vencimentoVigencia"] != DBNull.Value)
                            { d.VencimentoVigencia = Convert.ToDateTime(dr2["vencimentoVigencia"]); }

                            if (dr2["dataEmissao"] != DBNull.Value)
                            { d.DataEmissao = Convert.ToDateTime(dr2["dataEmissao"]); }

                            if (dr2["dataAssinatura"] != DBNull.Value)
                            { d.DataAssinatura = Convert.ToDateTime(dr2["dataAssinatura"]); }

                            d.DataCadastro = Convert.ToDateTime(dr2["dataCadastro"]);

                            if (dr2["descarte"] != DBNull.Value)
                            { d.Descarte = Convert.ToDateTime(dr2["descarte"]); }

                            d.SetorAtual = Convert.ToInt32(dr2["setorAtual"]);
                            d.Arquivado = dr2["arquivado"].ToString();
                            d.AlertaVencimentoVigencia = dr2["alertaVencimentoVigencia"].ToString();

                            if (dr2["dataPagamentoRecebimento"] != DBNull.Value)
                            { d.DataPagamentoRecebimento = Convert.ToDateTime(dr2["dataPagamentoRecebimento"]); }

                            d.NumeroParcelas = dr2["numeroParcelas"].ToString();
                            d.ValorPrevistoParcela = dr2["valorPrevistoParcela"].ToString();
                            d.Arquivo = dr2["arquivo"].ToString();
                            d.Ativo = dr2["ativo"].ToString();
                        }
                    }

                    return d;
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

        public bool NaoRecebido(int _IdDocumento, int _IdProcesso)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT idDocumento FROM tbMovimentacoes WHERE idDocumento = " + _IdDocumento + " AND setorDestino = " + _IdProcesso  + " AND recebido = 'Não'", objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    { return true; }
                    else
                    { return false; }
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

        public IList Buscar(Int32 _IdProcesso, String _Descricao, DateTime _DataCadastro, Int32 _IdTipoDocumento)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    IList lst = new List<Documento>();

                    Boolean bolWhere = false;
                    String strSQL = "SELECT idDocumento,idTipoDocumento,numero,nomePortador,vencimentoVigencia,dataEmissao FROM tbDocumentos WHERE";

                    if (_IdProcesso != 0)
                    {
                        strSQL += " setorAtual = " + _IdProcesso;
                        bolWhere = true;
                    }

                    if (_Descricao != "")
                    {
                        if (bolWhere)
                        { strSQL += " AND numero LIKE '%" + _Descricao + "%'"; }
                        else
                        { strSQL += " numero LIKE '%" + _Descricao + "%'"; }

                        bolWhere = true;
                    }

                    if (_DataCadastro != new DateTime(1, 1, 1))
                    {
                        if (bolWhere)
                        { strSQL += " AND dataCadastro = '" + _DataCadastro.Month + "/" + _DataCadastro.Day + "/" + _DataCadastro.Year + "'"; }
                        else
                        { strSQL += " dataCadastro = '" + _DataCadastro.Month + "/" + _DataCadastro.Day + "/" + _DataCadastro.Year + "'"; }

                        bolWhere = true;
                    }

                    if (_IdTipoDocumento != 0)
                    {
                        if (bolWhere)
                        { strSQL += " AND idTipoDocumento = " + _IdTipoDocumento; }
                        else
                        { strSQL += " idTipoDocumento = " + _IdTipoDocumento; }

                        bolWhere = true;
                    }

                    if (bolWhere)
                    { strSQL += " AND arquivado = '0' Order By dataCadastro DESC"; }
                    else
                    { strSQL += " arquivado = '0' Order By dataCadastro DESC"; }

                    //HttpContext.Current.Response.Write(strSQL);

                    SqlCommand cmd = new SqlCommand(strSQL, objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();

                    while (dr.Read())
                    {
                        DateTime dtVencimentoVigencia = new DateTime(1900, 1, 1);
                        DateTime dtEmissao = new DateTime(1900, 1, 1);

                        if (dr["vencimentoVigencia"] != DBNull.Value)
                        { dtVencimentoVigencia = Convert.ToDateTime(dr["vencimentoVigencia"]); }

                        if (dr["dataEmissao"] != DBNull.Value)
                        { dtEmissao = Convert.ToDateTime(dr["dataEmissao"]); }

                        lst.Add(
                                new Documento()
                                {
                                    IdDocumento = Convert.ToInt32(dr["idDocumento"]),
                                    TipoDocumento = tdDAL.ObterDadosPorId(Convert.ToInt32(dr["idTipoDocumento"])),
                                    Descricao = dr["numero"].ToString(),
                                    NomePortador = dr["nomePortador"].ToString(),
                                    VencimentoVigencia = dtVencimentoVigencia,
                                    DataEmissao = dtEmissao
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

        public IList Listar()
        { throw new NotImplementedException(); }

        public IList ListarPorIdProcesso(int _IdProcesso)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    IList lst = new List<Documento>();

                    SqlCommand cmd = new SqlCommand("SELECT idDocumento,idTipoDocumento,numero,nomePortador,vencimentoVigencia,dataEmissao FROM tbDocumentos WHERE setorAtual = " + _IdProcesso + " And arquivado = '0' Order By dataCadastro DESC", objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();

                    while (dr.Read())
                    {
                        DateTime dtVencimentoVigencia = new DateTime(1900, 1, 1);
                        DateTime dtEmissao = new DateTime(1900, 1, 1);

                        if (dr["vencimentoVigencia"] != DBNull.Value)
                        { dtVencimentoVigencia = Convert.ToDateTime(dr["vencimentoVigencia"]); }

                        if (dr["dataEmissao"] != DBNull.Value)
                        { dtVencimentoVigencia = Convert.ToDateTime(dr["dataEmissao"]); }

                        lst.Add(
                                new Documento()
                                {
                                    IdDocumento = Convert.ToInt32(dr["idDocumento"]),
                                    TipoDocumento = tdDAL.ObterDadosPorId(Convert.ToInt32(dr["idTipoDocumento"])),
                                    Descricao = dr["numero"].ToString(),
                                    NomePortador = dr["nomePortador"].ToString(),
                                    VencimentoVigencia = dtVencimentoVigencia,
                                    DataEmissao = dtEmissao
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

        public IList ListarPorIdProcessoArquivado(Int32 _IdProcesso, String _Arquivado)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    IList lst = new List<Documento>();

                    SqlCommand cmd = new SqlCommand("SELECT idDocumento,idTipoDocumento,numero,nomePortador,vencimentoVigencia,dataEmissao FROM tbDocumentos WHERE setorAtual = " + _IdProcesso + " And arquivado = '" + _Arquivado + "' And ativo = 'S' Order By dataCadastro DESC", objConn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();

                    while (dr.Read())
                    {
                        DateTime dtVencimentoVigencia = new DateTime(1900, 1, 1);
                        DateTime dtEmissao = new DateTime(1900, 1, 1);

                        if (dr["vencimentoVigencia"] != DBNull.Value)
                        { dtVencimentoVigencia = Convert.ToDateTime(dr["vencimentoVigencia"]); }

                        if (dr["dataEmissao"] != DBNull.Value)
                        { dtVencimentoVigencia = Convert.ToDateTime(dr["dataEmissao"]); }

                        lst.Add(
                                new Documento()
                                {
                                    IdDocumento = Convert.ToInt32(dr["idDocumento"]),
                                    TipoDocumento = tdDAL.ObterDadosPorId(Convert.ToInt32(dr["idTipoDocumento"])),
                                    Descricao = dr["numero"].ToString(),
                                    NomePortador = dr["nomePortador"].ToString(),
                                    VencimentoVigencia = dtVencimentoVigencia,
                                    DataEmissao = dtEmissao
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

                    Documento d = (Documento)obj;

                    SqlCommand cmd = new SqlCommand("INSERT INTO tbDocumentos(idTipoDocumento,numero,nomePortador,rg,numeroInss,cpfCnpj,vigencia,vencimentoVigencia,dataEmissao,dataAssinatura,dataCadastro,descarte,setorAtual,arquivado,alertaVencimentoVigencia,dataPagamentoRecebimento,numeroParcelas,valorPrevistoParcela,arquivo,ativo) VALUES(@IdTipoDocumento,@Numero,@NomePortador,@Rg,@NumeroInss,@CpfCnpj,@Vigencia,@VencimentoVigencia,@DataEmissao,@DataAssinatura,@DataCadastro,@Descarte,@SetorAtual,@Arquivado,@AlertaVencimentoVigencia,@DataPagamentoRecebimento,@NumeroParcelas,@ValorPrevistoParcela,@Arquivo,@Ativo)", objConn);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO tbDocumentos(idTipoDocumento,numero,nomePortador,rg,numeroInss,cpfCnpj,vigencia,vencimentoVigencia,setorAtual,arquivado,alertaVencimentoVigencia,numeroParcelas,valorPrevistoParcela,arquivo,ativo) VALUES(@IdTipoDocumento,@Numero,@NomePortador,@Rg,@NumeroInss,@CpfCnpj,@Vigencia,@VencimentoVigencia,@SetorAtual,@Arquivado,@AlertaVencimentoVigencia,@NumeroParcelas,@ValorPrevistoParcela,@Arquivo,@Ativo)", objConn);
                    cmd.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = d.TipoDocumento.IDTipoDocumento;
                    cmd.Parameters.Add("@Numero", SqlDbType.VarChar, 100).Value = d.Descricao;
                    cmd.Parameters.Add("@NomePortador", SqlDbType.VarChar, 100).Value = d.NomePortador;
                    cmd.Parameters.Add("@Rg", SqlDbType.VarChar, 20).Value = d.RG;
                    cmd.Parameters.Add("@NumeroInss", SqlDbType.VarChar, 20).Value = d.NumeroINSS;
                    cmd.Parameters.Add("@CpfCnpj", SqlDbType.VarChar, 20).Value = d.CPFCNPJ;
                    cmd.Parameters.Add("@Vigencia", SqlDbType.Int).Value = d.Vigencia;

                    if (d.VencimentoVigencia == new DateTime(1900, 1, 1))
                    { cmd.Parameters.Add("@VencimentoVigencia", SqlDbType.Date).Value = DBNull.Value; }
                    else
                    { cmd.Parameters.Add("@VencimentoVigencia", SqlDbType.Date).Value = d.VencimentoVigencia; }

                    if (d.DataEmissao == new DateTime(1900, 1, 1))
                    { cmd.Parameters.Add("@DataEmissao", SqlDbType.Date).Value = DBNull.Value; }
                    else
                    { cmd.Parameters.Add("@DataEmissao", SqlDbType.Date).Value = d.DataEmissao; }

                    if (d.DataAssinatura == new DateTime(1900, 1, 1))
                    { cmd.Parameters.Add("@DataAssinatura", SqlDbType.Date).Value = DBNull.Value; }
                    else
                    { cmd.Parameters.Add("@DataAssinatura", SqlDbType.Date).Value = d.DataAssinatura; }

                    cmd.Parameters.Add("@DataCadastro", SqlDbType.Date).Value = d.DataCadastro;

                    if (d.Descarte == new DateTime(1900, 1, 1))
                    { cmd.Parameters.Add("@Descarte", SqlDbType.Date).Value = DBNull.Value; }
                    else
                    { cmd.Parameters.Add("@Descarte", SqlDbType.Date).Value = d.Descarte; }

                    cmd.Parameters.Add("@SetorAtual", SqlDbType.Int).Value = d.SetorAtual;
                    cmd.Parameters.Add("@Arquivado", SqlDbType.VarChar, 1).Value = d.Arquivado;
                    cmd.Parameters.Add("@AlertaVencimentoVigencia", SqlDbType.VarChar, 3).Value = d.AlertaVencimentoVigencia;

                    if (d.DataPagamentoRecebimento == new DateTime(1900, 1, 1))
                    { cmd.Parameters.Add("@DataPagamentoRecebimento", SqlDbType.Date).Value = DBNull.Value; }
                    else
                    { cmd.Parameters.Add("@DataPagamentoRecebimento", SqlDbType.Date).Value = d.DataPagamentoRecebimento; }

                    cmd.Parameters.Add("@NumeroParcelas", SqlDbType.VarChar, 10).Value = d.NumeroParcelas;
                    cmd.Parameters.Add("@ValorPrevistoParcela", SqlDbType.VarChar, 10).Value = d.ValorPrevistoParcela;
                    cmd.Parameters.Add("@Arquivo", SqlDbType.VarChar, 20).Value = d.Arquivo;
                    cmd.Parameters.Add("@Ativo", SqlDbType.VarChar, 1).Value = d.Ativo;

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

                    Documento d = (Documento)obj;

                    SqlCommand cmd_1 = new SqlCommand("DELETE FROM tbArquivamentosInternos WHERE idDocumento = @IdDocumento", objConn);
                    cmd_1.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = d.IdDocumento;
                    cmd_1.ExecuteNonQuery();
                    
                    SqlCommand cmd_2 = new SqlCommand("DELETE FROM tbArquivamentosExternos WHERE idDocumento = @IdDocumento", objConn);
                    cmd_2.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = d.IdDocumento;
                    cmd_2.ExecuteNonQuery();
                    
                    SqlCommand cmd_3 = new SqlCommand("DELETE FROM tbMovimentacoes WHERE idDocumento = @IdDocumento", objConn);
                    cmd_3.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = d.IdDocumento;
                    cmd_3.ExecuteNonQuery();
                    
                    SqlCommand cmd_4 = new SqlCommand("DELETE FROM tbDocumentos WHERE idDocumento = @IdDocumento", objConn);
                    cmd_4.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = d.IdDocumento;
                    cmd_4.ExecuteNonQuery();
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

                    Documento d = (Documento)obj;

                    SqlCommand cmd = new SqlCommand("UPDATE tbDocumentos SET idTipoDocumento=@IdTipoDocumento,numero=@Numero,nomePortador=@NomePortador,rg=@Rg,numeroInss=@NumeroInss,cpfCnpj=@CpfCnpj,vigencia=@Vigencia,vencimentoVigencia=@VencimentoVigencia,dataEmissao=@DataEmissao,dataAssinatura=@DataAssinatura,descarte=@Descarte,arquivado=@Arquivado,dataPagamentoRecebimento=@DataPagamentoRecebimento,numeroParcelas=@NumeroParcelas,valorPrevistoParcela=@ValorPrevistoParcela WHERE idDocumento=@IdDocumento", objConn);
                    cmd.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = d.TipoDocumento.IDTipoDocumento;
                    cmd.Parameters.Add("@Numero", SqlDbType.VarChar, 100).Value = d.Descricao;
                    cmd.Parameters.Add("@NomePortador", SqlDbType.VarChar, 100).Value = d.NomePortador;
                    cmd.Parameters.Add("@Rg", SqlDbType.VarChar, 20).Value = d.RG;
                    cmd.Parameters.Add("@NumeroInss", SqlDbType.VarChar, 20).Value = d.NumeroINSS;
                    cmd.Parameters.Add("@CpfCnpj", SqlDbType.VarChar, 20).Value = d.CPFCNPJ;
                    cmd.Parameters.Add("@Vigencia", SqlDbType.Int).Value = d.Vigencia;

                    if (d.VencimentoVigencia == new DateTime(1900, 1, 1) || d.VencimentoVigencia == new DateTime(0001, 1, 1))
                    { cmd.Parameters.Add("@VencimentoVigencia", SqlDbType.Date).Value = DBNull.Value; }
                    else
                    { cmd.Parameters.Add("@VencimentoVigencia", SqlDbType.Date).Value = d.VencimentoVigencia; }

                    if (d.DataEmissao == new DateTime(1900, 1, 1) || d.DataEmissao == new DateTime(0001, 1, 1))
                    { cmd.Parameters.Add("@DataEmissao", SqlDbType.Date).Value = DBNull.Value; }
                    else
                    { cmd.Parameters.Add("@DataEmissao", SqlDbType.Date).Value = d.DataEmissao; }

                    if (d.DataAssinatura == new DateTime(1900, 1, 1) || d.DataAssinatura == new DateTime(0001, 1, 1))
                    { cmd.Parameters.Add("@DataAssinatura", SqlDbType.Date).Value = DBNull.Value; }
                    else
                    { cmd.Parameters.Add("@DataAssinatura", SqlDbType.Date).Value = d.DataAssinatura; }

                    if (d.Descarte == new DateTime(1900, 1, 1) || d.Descarte == new DateTime(0001, 1, 1))
                    { cmd.Parameters.Add("@Descarte", SqlDbType.Date).Value = DBNull.Value; }
                    else
                    { cmd.Parameters.Add("@Descarte", SqlDbType.Date).Value = d.Descarte; }

                    cmd.Parameters.Add("@Arquivado", SqlDbType.VarChar, 1).Value = d.Arquivado;

                    if (d.DataPagamentoRecebimento == new DateTime(1900, 1, 1) || d.DataPagamentoRecebimento == new DateTime(0001, 1, 1))
                    { cmd.Parameters.Add("@DataPagamentoRecebimento", SqlDbType.Date).Value = DBNull.Value; }
                    else
                    { cmd.Parameters.Add("@DataPagamentoRecebimento", SqlDbType.Date).Value = d.DataPagamentoRecebimento; }

                    cmd.Parameters.Add("@NumeroParcelas", SqlDbType.VarChar, 10).Value = d.NumeroParcelas;
                    cmd.Parameters.Add("@ValorPrevistoParcela", SqlDbType.VarChar, 10).Value = d.ValorPrevistoParcela;
                    cmd.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = d.IdDocumento;

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

        public void Receber(Int32 _IdDocumento)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    UsuarioDAL uDAL = new UsuarioDAL();

                    SqlCommand cmd = new SqlCommand("UPDATE tbMovimentacoes Set recebido='Sim',recebidoPor='" + uDAL.ObterDadosPorId(Convert.ToInt32(HttpContext.Current.Session["sesIdUsuario"])).DSNome + "',dataHoraRecebimento='" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "' WHERE idDocumento = " + _IdDocumento + " And recebido = 'Não'", objConn);
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

        public void Movimentar(Movimentacao m, Int32 _IdDocumento)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    // CADASTRA A MOVIMENTAÇÃO //
                    SqlCommand cmd_1 = new SqlCommand("INSERT INTO tbMovimentacoes(idDocumento,setorOrigem,setorDestino,dataHoraMovimentacao,movimentadoPor,recebido,dataHoraRecebimento,prazo,despacho,entreguePara,alertaPrazo) VALUES(@IdDocumento,@SetorOrigem,@SetorDestino,@DataHoraMovimentacao,@MovimentadoPor,@Recebido,@DataHoraRecebimento,@Prazo,@Despacho,@EntreguePara,@AlertaPrazo)", objConn);
                    cmd_1.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = m.Documento.IdDocumento;
                    cmd_1.Parameters.Add("@SetorOrigem", SqlDbType.Int).Value = m.ProcessoOrigem;
                    cmd_1.Parameters.Add("@SetorDestino", SqlDbType.Int).Value = m.ProcessoDestino;
                    cmd_1.Parameters.Add("@DataHoraMovimentacao", SqlDbType.VarChar, 20).Value = m.DataHoraMovimentacao;
                    cmd_1.Parameters.Add("@MovimentadoPor", SqlDbType.VarChar, 100).Value = m.MovimentadoPor;
                    cmd_1.Parameters.Add("@Recebido", SqlDbType.VarChar, 3).Value = m.Recebido;
                    cmd_1.Parameters.Add("@DataHoraRecebimento", SqlDbType.VarChar, 20).Value = m.DataHoraRecebimento;
                    cmd_1.Parameters.Add("@Prazo", SqlDbType.Date).Value = m.Prazo;
                    cmd_1.Parameters.Add("@Despacho", SqlDbType.Text).Value = m.Despacho;
                    cmd_1.Parameters.Add("@EntreguePara", SqlDbType.VarChar, 100).Value = m.EntreguePara;
                    cmd_1.Parameters.Add("@AlertaPrazo", SqlDbType.VarChar, 100).Value = m.AlertaPrazo;
                    cmd_1.ExecuteNonQuery();
                    // FIM //

                    // ALTERA O SETOR ATUAL DO DOCUMENTO //
                    SqlCommand cmd_2 = new SqlCommand("UPDATE tbDocumentos Set setorAtual=" + m.ProcessoDestino + " WHERE idDocumento = " + _IdDocumento, objConn);
                    cmd_2.ExecuteNonQuery();
                    // FIM //
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

        public void Desarquivar(Int32 _IdDocumento)
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    UsuarioDAL uDAL = new UsuarioDAL();

                    SqlCommand cmd_1 = new SqlCommand("DELETE FROM tbArquivamentosInternos WHERE idDocumento = " + _IdDocumento, objConn);
                    SqlCommand cmd_2 = new SqlCommand("DELETE FROM tbArquivamentosExternos WHERE idDocumento = " + _IdDocumento, objConn);
                    SqlCommand cmd_3 = new SqlCommand("UPDATE tbDocumentos SET arquivado = '0' WHERE idDocumento = " + _IdDocumento, objConn);
                    cmd_1.ExecuteNonQuery();
                    cmd_2.ExecuteNonQuery();
                    cmd_3.ExecuteNonQuery();
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
