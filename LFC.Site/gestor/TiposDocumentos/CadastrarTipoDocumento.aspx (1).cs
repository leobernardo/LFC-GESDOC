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
    public partial class CadastrarTipoDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                TipoDocumento td = new TipoDocumento();

                td.Nome = txtNome.Text;
                td.GuardaInterna = txtGuardaInterna.Text;
                td.GuardaExterna = txtGuardaExterna.Text;

                TipoDocumentoDAL tdDAL = new TipoDocumentoDAL();
                tdDAL.Cadastrar(td);

                Response.Write("<script language='JavaScript'>alert('Tipo de Documento cadastrado com sucesso');window.parent.location='ListarTiposDocumentos.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}