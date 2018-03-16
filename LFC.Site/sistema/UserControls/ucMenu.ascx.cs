using System;

namespace LFC.GesDoc.Site.sistema.UserControls
{
    public partial class ucMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int intProcesso = Convert.ToInt32(Session["sesIdProcesso"]);

                switch (intProcesso)
                {
                    case 6:
                    case 15:
                    case 17:
                    case 45:

                        litMenu.Text = "<li class=\"treeview\">";
                        litMenu.Text += "<a href=\"#\"><i class=\"fa fa-file-text\"></i> <span>Documentos</span> <i class=\"fa fa-angle-left pull-right\"></i></a>";
                        litMenu.Text += "<ul class=\"treeview-menu\">";
                        litMenu.Text += "<li><a href=\"../Documentos/BuscarDocumentos.aspx\"><i class=\"fa fa-circle-o\"></i> Buscar Documentos</a></li>";
                        litMenu.Text += "<li><a href=\"../Documentos/ListarDocumentos.aspx\"><i class=\"fa fa-circle-o\"></i> Listar Documentos</a></li>";
                        litMenu.Text += "<li><a href=\"../Documentos/CadastrarDocumento.aspx\"><i class=\"fa fa-circle-o\"></i> Cadastrar Documento</a></li>";
                        litMenu.Text += "</ul>";
                        litMenu.Text += "</li>";

                        litMenu.Text += "<li class=\"treeview\">";
                        litMenu.Text += "<a href=\"#\" ><i class=\"fa fa-exchange\"></i> <span>Parcerias</span> <i class=\"fa fa-angle-left pull-right\"></i></a>";
                        litMenu.Text += "<ul class=\"treeview-menu\">";
                        litMenu.Text += "<li><a href=\"../Parcerias/BuscarParcerias.aspx\"><i class=\"fa fa-circle-o\"></i> Buscar Parcerias</a></li>";
                        litMenu.Text += "<li><a href=\"../Parcerias/ListarParcerias.aspx\"><i class=\"fa fa-circle-o\"></i> Listar Parcerias</a></li>";
                        litMenu.Text += "<li><a href=\"../Parcerias/CadastrarParceria.aspx\"><i class=\"fa fa-circle-o\"></i> Cadastrar Parceria</a></li>";
                        litMenu.Text += "<li><a href=\"../Parcerias/RelatorioParcerias.aspx\"><i class=\"fa fa-circle-o\"></i> Relatório de Parcerias</a></li>";
                        litMenu.Text += "</ul>";
                        litMenu.Text += "</li>";

                        litMenu.Text += "<li class=\"treeview\">";
                        litMenu.Text += "<a href=\"#\" ><i class=\"fa fa-building\"></i> <span>Unidades</span> <i class=\"fa fa-angle-left pull-right\"></i></a>";
                        litMenu.Text += "<ul class=\"treeview-menu\">";
                        litMenu.Text += "<li><a href=\"../Unidades/ListarUnidades.aspx\"><i class=\"fa fa-circle-o\"></i> Listar Unidades</a></li>";
                        litMenu.Text += "</ul>";
                        litMenu.Text += "</li>";

                        break;
                    default:

                        litMenu.Text = "<li class=\"treeview\">";
                        litMenu.Text += "<a href=\"#\"><i class=\"fa fa-file-text\"></i> <span>Documentos</span> <i class=\"fa fa-angle-left pull-right\"></i></a>";
                        litMenu.Text += "<ul class=\"treeview-menu\">";
                        litMenu.Text += "<li><a href=\"../Documentos/BuscarDocumentos.aspx\"><i class=\"fa fa-circle-o\"></i> Buscar Documentos</a></li>";
                        litMenu.Text += "<li><a href=\"../Documentos/ListarDocumentos.aspx\"><i class=\"fa fa-circle-o\"></i> Listar Documentos</a></li>";
                        litMenu.Text += "<li><a href=\"../Documentos/CadastrarDocumento.aspx\"><i class=\"fa fa-circle-o\"></i> Cadastrar Documento</a></li>";
                        litMenu.Text += "</ul>";
                        litMenu.Text += "</li>";

                        break;
                }
            }
            catch (Exception)
            { throw; }
        }
    }
}