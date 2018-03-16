using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.gestor.Processos
{
    public partial class CadastrarProcesso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                Processo p = new Processo();

                p.DSProcesso = Util.formataTexto(txtDescricao.Text);
                p.DSEmail = Util.formataTexto(txtEmail.Text);
                p.NRPrazoMaximo = Convert.ToInt32(txtPrazoMaximo.Text);

                if (radAtivo_N.Checked == true)
                { p.BTAtivo = false; }
                else
                { p.BTAtivo = true; }

                ProcessoDAL pDAL = new ProcessoDAL();
                pDAL.Cadastrar(p);

                Response.Write("<script language='JavaScript'>alert('Processo cadastrado com sucesso');window.parent.location='ListarProcessos.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}