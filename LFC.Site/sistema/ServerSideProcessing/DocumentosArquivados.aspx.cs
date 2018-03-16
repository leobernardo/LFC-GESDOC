using System;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.sistema.ServerSideProcessing
{
    public partial class DocumentosArquivados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int echo, displayLength, displayStart;
                string search;

                if (Request.Params["sEcho"] != null)
                { echo = Int32.Parse(Request.Params["sEcho"]); }
                else
                { echo = 1; }

                if (Request.Params["iDisplayLength"] != null)
                { displayLength = Int32.Parse(Request.Params["iDisplayLength"]); }
                else
                { displayLength = 20; }

                if (Request.Params["iDisplayStart"] != null)
                { displayStart = Int32.Parse(Request.Params["iDisplayStart"]); }
                else
                { displayStart = 1; }

                if (Request.Params["sSearch"] != null)
                { search = Request.Params["sSearch"]; }
                else
                { search = ""; }

                ///////////
                //SEARCH (filter)
                //- build the where clause
                ////////
                StringBuilder sb = new StringBuilder();
                string whereClause = string.Empty;
                if (!String.IsNullOrEmpty(search))
                {
                    sb.Append(" WHERE setorAtual=" + Request.QueryString["idPrc"] + " AND arquivado = '1' AND ativo = 'S' AND (numero LIKE '%" + search + "%'");
                    sb.Append(" OR numero LIKE '%" + search + "%')");
                    //sb.Append(" OR numeroProcesso LIKE '%");
                    //sb.Append(search);
                    //sb.Append("%' OR destinatario LIKE '%");
                    //sb.Append(search);
                    //sb.Append("%' OR assunto LIKE '%");
                    //sb.Append(search);
                    //sb.Append("%')");
                    whereClause = sb.ToString();
                }
                else
                {
                    whereClause = " WHERE setorAtual=" + Request.QueryString["idPrc"] + " AND arquivado = '1' AND ativo = 'S'";
                }

                ///////////////
                //ORDERING
                //- build the order by clause
                //////////////

                //sb.Clear();
                sb.Length = 0;

                string orderByClause = string.Empty;
                //Check which column is to be sorted by in which direction
                for (int i = 0; i < 11; i++)
                {
                    if (Request.Params["bSortable_" + i] == "true")
                    {
                        sb.Append(Request.Params["iSortCol_" + i]);
                        sb.Append(" ");
                        sb.Append(Request.Params["sSortDir_" + i]);
                    }
                }
                orderByClause = sb.ToString();

                //Response.Write(orderByClause);
                //Response.End();

                //Replace the number corresponding the column position by the corresponding name of the column in the database
                if (!String.IsNullOrEmpty(orderByClause))
                {
                    orderByClause = orderByClause.Replace("0", ", idTipoDocumento");
                    orderByClause = orderByClause.Replace("1", ", numero");
                    orderByClause = orderByClause.Replace("2", ", dataEmissao");
                    //orderByClause = orderByClause.Replace("3", ", status");
                    //Eliminate the first comma of the variable "order"
                    orderByClause = orderByClause.Remove(0, 1);
                }
                else
                { orderByClause = "idDocumento DESC"; }

                orderByClause = "ORDER BY " + orderByClause;

                /////////////
                //T-SQL query
                //- ROW_NUMBER() is used for db side pagination
                /////////////

                //sb.Clear();
                sb.Length = 0;

                string query = "SELECT * FROM ( SELECT ROW_NUMBER() OVER ({0}) AS RowNumber,* FROM ( SELECT ( SELECT COUNT(*) FROM tbDocumentos {1} ) AS TotalDisplayRows, (SELECT COUNT(*) FROM tbDocumentos {1}) AS TotalRows,idDocumento,idTipoDocumento,numero,nomePortador,vencimentoVigencia,dataEmissao FROM tbDocumentos {1} ) RawResults ) Results WHERE RowNumber BETWEEN {2} AND {3}";

                query = String.Format(query, orderByClause, whereClause, displayStart + 1, displayStart + displayLength);

                //Response.Write(query);
                //Response.End();

                //Get result rows from DB
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBGesDoc"].ConnectionString);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                IDataReader rdrBrowsers = cmd.ExecuteReader();

                /////////////
                /// JSON output
                /// - build JSON output from DB results
                /// ///////////

                //sb.Clear();
                sb.Length = 0;

                string outputJson = string.Empty;
                int totalDisplayRecords = 0;
                int totalRecords = 0;
                while (rdrBrowsers.Read())
                {
                    if (totalRecords == 0)
                        totalRecords = Int32.Parse(rdrBrowsers["TotalRows"].ToString());
                    if (totalDisplayRecords == 0)
                        totalDisplayRecords = Int32.Parse(rdrBrowsers["TotalDisplayRows"].ToString());
                    sb.Append("[");
                    sb.Append("\"" + getTipoDocumentoLocalizacao(Convert.ToInt32(rdrBrowsers["idDocumento"]), Convert.ToInt32(rdrBrowsers["idTipoDocumento"])) + "\",");
                    sb.Append("\"" + rdrBrowsers["numero"] + "\",");

                    if (rdrBrowsers["dataEmissao"] == DBNull.Value)
                    { sb.Append("\"<span class='text-red'>N/D</span>\","); }
                    else
                    { sb.Append("\"" + Convert.ToDateTime(rdrBrowsers["dataEmissao"]).ToShortDateString() + "\","); }
                    //sb.Append("\"" + Convert.ToDateTime(rdrBrowsers["dataEmissao"]).ToShortDateString() + "\",");

                    sb.Append("\"" + getOpcoes(Convert.ToInt32(rdrBrowsers["idDocumento"])) + "\"");
                    sb.Append("],");
                }

                outputJson = sb.ToString();

                outputJson.Replace("\r\n", " ");
                outputJson.Replace("\r", " ");
                outputJson.Replace("\n", " ");
                outputJson.Replace("\\", "\\\\");
                outputJson.Replace("\"", "\\\"");

                char cr = (char)13;
                char lf = (char)10;
                char tab = (char)9;
                outputJson.Replace("\\r", cr.ToString());
                outputJson.Replace("\\n", lf.ToString());
                outputJson.Replace("\\t", tab.ToString());

                if (outputJson.Length > 0)
                { outputJson = outputJson.Remove(outputJson.Length - 1); }

                //sb.Clear();
                sb.Length = 0;

                sb.Append("{");
                sb.Append("\"sEcho\": ");
                sb.Append(echo);
                sb.Append(",");
                sb.Append("\"iTotalRecords\": ");
                sb.Append(totalRecords);
                sb.Append(",");
                sb.Append("\"iTotalDisplayRecords\": ");
                sb.Append(totalDisplayRecords);
                sb.Append(",");
                sb.Append("\"aaData\": [");
                sb.Append(outputJson);
                sb.Append("]}");
                outputJson = sb.ToString();

                /////////////
                /// Write to Response
                /// - clear other HTML elements
                /// - flush out JSON output
                /// ///////////
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.Write(outputJson);
                Response.Flush();
                Response.End();
            }
            catch (Exception)
            { throw; }
        }

        protected string getTipoDocumentoLocalizacao(Int32 _IdDocumento, Int32 _IdTipoDocumento)
        {
            try
            {
                ArquivamentoInternoDAL aiDAL = new ArquivamentoInternoDAL();
                ArquivamentoInterno ai = aiDAL.CarregarDadosPorIdDocumento(_IdDocumento);

                TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();

                String strTipoDocumentoLocalizacao;

                strTipoDocumentoLocalizacao = tdDAL.ObterDadosPorId(_IdTipoDocumento).DSTipoDocumento + "<br />";
                strTipoDocumentoLocalizacao += "(Arquivo: <span class=\\\"text-red\\\"><b>" + ai.Arquivo + "</b></span> | Gaveta: <span class=\\\"text-red\\\"><b>" + ai.Gaveta + "</b></span> | Pasta: <span class=\\\"text-red\\\"><b>" + ai.Pasta + "</b></span>)";

                return strTipoDocumentoLocalizacao;
            }
            catch (Exception)
            { throw; }
        }

        protected string getOpcoes(Int32 _IdDocumento)
        {
            try
            {
                String strOpcoes = "";

                DocumentoDAL dDAL = new DocumentoDAL();

                ArquivamentoInternoDAL aiDAL = new ArquivamentoInternoDAL();
                ArquivamentoInterno ai = aiDAL.CarregarDadosPorIdDocumento(_IdDocumento);

                if (ai.ArquivoDocumento == "-")
                { strOpcoes = strOpcoes + "<a href=\\\"JavaScript:alert('Documento sem arquivo cadastrado');\\\" data-toggle=\\\"tooltip\\\" data-placement=\\\"top\\\" title=\\\"Visualizar Documento\\\"><i class=\\\"fa fa-search\\\" style=\\\"margin-right:10px\\\"></i></a>"; }
                else
                { strOpcoes = strOpcoes + "<a href=\\\"http://www.lfcnet.org.br/gesdoc/arquivos/ArquivamentosInternos/" + ai.ArquivoDocumento + "\\\" data-toggle=\\\"tooltip\\\" data-placement=\\\"top\\\" title=\\\"Visualizar Documento\\\" target=\\\"_blank\\\"><i class=\\\"fa fa-search\\\" style=\\\"margin-right:10px\\\"></i></a>"; }

                strOpcoes = strOpcoes + "<a href=\\\"HistoricoDocumento.aspx?idDoc=" + _IdDocumento + "\\\" data-toggle=\\\"tooltip\\\" data-placement=\\\"top\\\" title=\\\"Histórico do Documento\\\" class=\\\"historicoDocumento\\\"><i class=\\\"fa fa-calendar\\\" style=\\\"margin-right:10px\\\"></i></a>";
                strOpcoes = strOpcoes + "<a href=\\\"ArquivarExterno.aspx?idDoc=" + _IdDocumento + "\\\" data-toggle=\\\"tooltip\\\" data-placement=\\\"top\\\" title=\\\"Arquivar Externamente o Documento\\\"><i class=\\\"fa fa-globe\\\" style=\\\"margin-right:10px\\\"></i></a>";
                strOpcoes = strOpcoes + "<a href=\\\"#\\\" onclick=\\\"return confirmaDesarquivamento(this, " + _IdDocumento + ");\\\" data-toggle=\\\"tooltip\\\" data-placement=\\\"top\\\" title=\\\"Desarquivar Documento\\\"><i class=\\\"fa fa-folder-open\\\"></i>";

                return strOpcoes;
            }
            catch (Exception)
            { throw; }
        }
    }
}