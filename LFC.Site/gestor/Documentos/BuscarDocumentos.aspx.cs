using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Documentos
{
    public partial class BuscarDocumentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    // PREENCHE OS PROCESSOS //
                    ProcessoDAL pDAL = new ProcessoDAL();
                    ddlProcesso.DataSource = pDAL.Listar();
                    ddlProcesso.DataBind();
                    ddlProcesso.Items.Insert(0, (new ListItem("", "0")));
                    // FIM //

                    // PREENCHE OS TIPOS DE DOCUMENTOS //
                    TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();
                    ddlTipoDocumento.DataSource = tdDAL.Listar();
                    ddlTipoDocumento.DataBind();
                    ddlTipoDocumento.Items.Insert(0, (new ListItem("", "0")));
                    // FIM //

                    divResultadoBusca.Visible = false;
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void Buscar(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    DocumentoDAL dDAL = new DocumentoDAL();

                    Int32 intIdProcesso = Convert.ToInt32(ddlProcesso.SelectedValue);
                    String strDescricao = txtDescricao.Text;
                    Int32 intIdTipoDocumento = Convert.ToInt32(ddlTipoDocumento.SelectedValue);

                    DateTime datCadastro = new DateTime();
                    if (txtDataCadastro.Text != "")
                    { datCadastro = Convert.ToDateTime(txtDataCadastro.Text); }

                    Documentos.DataSource = dDAL.Buscar(intIdProcesso, strDescricao, datCadastro, intIdTipoDocumento);
                    Documentos.DataBind();

                    divResultadoBusca.Visible = true;
                }
                catch (Exception)
                { throw; }
            }
            catch (Exception)
            { throw; }
        }

        protected string getTipoDocumento(Int32 _IdTipoDocumento)
        {
            try
            {
                TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();

                return tdDAL.ObterDadosPorId(_IdTipoDocumento).DSTipoDocumento;
            }
            catch (Exception)
            { throw; }
        }

        protected string getDataEmissao(DateTime _DataEmissao)
        {
            try
            {
                if (_DataEmissao == null)
                {
                    return "<span class='text-red'>N/D</span>";
                }
                else
                {
                    return _DataEmissao.ToShortDateString();
                }
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

                strOpcoes = strOpcoes + "<a href=\"HistoricoDocumento.aspx?idDoc=" + _IdDocumento + "\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Histórico do Documento\" class=\"historicoDocumento\"><i class=\"fa fa-calendar\" style=\"margin-right:10px\"></i></a>";
                strOpcoes = strOpcoes + "<a href=\"#\" onclick=\"return confirmaExclusao(this, " + _IdDocumento + ");\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Excluir Documento\"><i class=\"fa fa-trash\"></i></a>";

                return strOpcoes;
            }
            catch (Exception)
            { throw; }
        }
    }
}