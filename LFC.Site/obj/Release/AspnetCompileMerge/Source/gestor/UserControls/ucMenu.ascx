<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenu.ascx.cs" Inherits="LFC.GesDoc.Site.gestor.UserControls.ucMenu" %>

<!-- sidebar menu: : style can be found in sidebar.less -->
<ul class="sidebar-menu">
    <li class="header">MENU</li>
    <li><a href="../Home/Default.aspx"><i class="fa fa-home"></i> <span>Página inicial</span></a></li>

    <li class="treeview">
        <a href="#"><i class="fa fa-file-text"></i> <span>Documentos</span> <i class="fa fa-angle-left pull-right"></i></a>
        <ul class="treeview-menu">
            <li><a href="../Documentos/BuscarDocumentos.aspx"><i class="fa fa-circle-o"></i> Buscar Documentos</a></li>
            <li><a href="../Documentos/ListarDocumentos.aspx"><i class="fa fa-circle-o"></i> Listar Documentos</a></li>
        </ul>
    </li>

    <li class="treeview">
        <a href="#"><i class="fa fa-exchange"></i> <span>Parcerias</span> <i class="fa fa-angle-left pull-right"></i></a>
        <ul class="treeview-menu">
            <li><a href="../Parcerias/ListarParcerias.aspx"><i class="fa fa-circle-o"></i> Listar Parcerias</a></li>
            <li><a href="../Parcerias/CadastrarParceria.aspx"><i class="fa fa-circle-o"></i> Cadastrar Parceria</a></li>
        </ul>
    </li>

    <li class="treeview">
        <a href="#"><i class="fa fa-sitemap"></i> <span>Processos</span> <i class="fa fa-angle-left pull-right"></i></a>
        <ul class="treeview-menu">
            <li><a href="../Processos/ListarProcessos.aspx"><i class="fa fa-circle-o"></i> Listar Processos</a></li>
            <li><a href="../Processos/CadastrarProcesso.aspx"><i class="fa fa-circle-o"></i> Cadastrar Processo</a></li>
        </ul>
    </li>

    <li class="treeview">
        <a href="#"><i class="fa fa-files-o"></i> <span>Tipos de Documentos</span> <i class="fa fa-angle-left pull-right"></i></a>
        <ul class="treeview-menu">
            <li><a href="../TiposDocumentos/ListarTiposDocumentos.aspx"><i class="fa fa-circle-o"></i> Listar Tipos de Documentos</a></li>
            <li><a href="../TiposDocumentos/CadastrarTipoDocumento.aspx"><i class="fa fa-circle-o"></i> Cadastrar Tipo de Documento</a></li>
        </ul>
    </li>

    <li class="treeview">
        <a href="#"><i class="fa fa-building"></i> <span>Unidades</span> <i class="fa fa-angle-left pull-right"></i></a>
        <ul class="treeview-menu">
            <li><a href="../Unidades/ListarUnidades.aspx"><i class="fa fa-circle-o"></i> Listar Unidades</a></li>
            <li><a href="../Unidades/ListarUnidades.aspx"><i class="fa fa-circle-o"></i> Cadastrar Unidade</a></li>
        </ul>
    </li>

    <li class="treeview">
        <a href="#"><i class="fa fa-user"></i> <span>Usuários</span> <i class="fa fa-angle-left pull-right"></i></a>
        <ul class="treeview-menu">
            <li><a href="../Usuarios/ListarUsuarios.aspx"><i class="fa fa-circle-o"></i> Listar Usuários</a></li>
            <li><a href="../Usuarios/CadastrarUsuario.aspx"><i class="fa fa-circle-o"></i> Cadastrar Usuário</a></li>
        </ul>
    </li>
</ul>