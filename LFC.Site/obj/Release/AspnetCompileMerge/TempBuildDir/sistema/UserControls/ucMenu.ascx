<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenu.ascx.cs" Inherits="LFC.GesDoc.Site.sistema.UserControls.ucMenu" %>

<!-- sidebar menu: : style can be found in sidebar.less -->
<ul class="sidebar-menu">
    <li class="header">MENU</li>
    <li><a href="../Home/Default.aspx"><i class="fa fa-home"></i> <span>Página inicial</span></a></li>

    <asp:Literal ID="litMenu" runat="server" />

    <%--<li class="treeview">
        <a href="#"><i class="fa fa-file-text"></i> <span>Documentos</span> <i class="fa fa-angle-left pull-right"></i></a>
        <ul class="treeview-menu">
            <li><a href="../Documentos/BuscarDocumentos.aspx"><i class="fa fa-circle-o"></i> Buscar Documentos</a></li>
            <li><a href="../Documentos/ListarDocumentos.aspx"><i class="fa fa-circle-o"></i> Listar Documentos</a></li>
            <li><a href="../Documentos/CadastrarDocumento.aspx"><i class="fa fa-circle-o"></i> Cadastrar Documento</a></li>
        </ul>
    </li>--%>
</ul>
