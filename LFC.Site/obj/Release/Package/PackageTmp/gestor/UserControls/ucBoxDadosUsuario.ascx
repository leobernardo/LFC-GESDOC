<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBoxDadosUsuario.ascx.cs" Inherits="LFC.GesDoc.Site.gestor.UserControls.ucBoxDadosUsuario" %>

<!-- User Account: style can be found in dropdown.less -->
<li class="dropdown user user-menu">
    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
        <img src="../dist/img/user.png" class="user-image" alt="User Image">
        <span class="hidden-xs"><asp:Literal ID="litNome" runat="server"></asp:Literal></span>
    </a>
    <ul class="dropdown-menu">
        <!-- User image -->
        <li class="user-header">
            <img src="../dist/img/user.png" class="img-circle" alt="User Image">
            <p>
                <asp:Literal ID="litEmail" runat="server"></asp:Literal>
                <small><asp:Literal ID="litNivelAcesso" runat="server"></asp:Literal></small>
            </p>
        </li>
        <!-- Menu Body -->
        <li class="user-body">
            <div class="col-xs-12 text-center">
                <b><asp:Literal ID="litProcesso" runat="server"></asp:Literal></b>
            </div>
        </li>
        <!-- Menu Footer-->
        <li class="user-footer">
            <div class="pull-left">
                <a href="#" class="btn btn-default btn-flat">Perfil</a>
            </div>
            <div class="pull-right">
                <a href="../Login.aspx?log=0" class="btn btn-default btn-flat">Sair</a>
            </div>
        </li>
    </ul>
</li>