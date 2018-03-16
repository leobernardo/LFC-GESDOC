using System;
using System.Linq;
using System.Collections.Generic;

using LFC.GesDoc.DAL;
using LFC.GesDoc.Modelos;

namespace LFC.GesDoc.Site.sistema.Unidades
{
    public partial class ListarUnidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UnidadeDAL uDAL = new UnidadeDAL();

                // LISTA AS UNIDADES //
                List<Unidade> unidades = (List<Unidade>)uDAL.Listar();
                Unidades.DataSource = unidades;
                Unidades.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected int ObterTotalParcerias(int _IdUnidade)
        {
            try
            {
                ParceriaDAL pDAL = new ParceriaDAL();

                List<Parceria> parcerias = (List<Parceria>)pDAL.Listar();

                return parcerias.Where(uEF => uEF.Unidade.IdUnidade == _IdUnidade).Count();
            }
            catch (Exception)
            { throw; }
        }
    }
}