using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.TiposDocumentos
{
    public partial class AlterarTipoDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();
                    TipoDocumento td = tdDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idTpd"]));

                    txtNome.Text = td.DSTipoDocumento;
                    txtGuardaInterna.Text = td.DSGuardaInterna;
                    txtGuardaExterna.Text = td.DSGuardaExterna;
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void Alterar(object sender, EventArgs e)
        {
            try
            {
                TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();
                TipoDocumento td = tdDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idTpd"]));

                td.DSTipoDocumento = Util.formataTexto(txtNome.Text);
                td.DSGuardaInterna = txtGuardaInterna.Text;
                td.DSGuardaExterna = txtGuardaExterna.Text;

                tdDAL.Alterar(td);

                Response.Write("<script language='JavaScript'>alert('Tipo de Documento alterado com sucesso');window.parent.location='ListarTiposDocumentos.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}