﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovimentarDocumento.aspx.cs" Inherits="LFC.GesDoc.Site.sistema.Documentos.MovimentarDocumento" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>GesDoc | Sistema de Gestão de Documentos LFC</title>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="../bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- DataTables -->
    <link rel="stylesheet" href="../plugins/datatables/dataTables.bootstrap.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="../dist/css/AdminLTE.min.css">
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="../dist/css/skins/_all-skins.min.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>

    <form runat="server">

    <div>
        <!-- Main content -->
        <section class="content">

        <!-- Default box -->
        <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Documentos <i class="fa fa-angle-right"></i> Listar Documentos <i class="fa fa-angle-right"></i> Movimentar Documento <label class="text-red"><asp:Label ID="lblDescricao" runat="server" /></label></h3>
            </div><!-- /.box-header -->
            <div class="box-body">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label>Descrição</label><br />
                            <asp:Literal ID="litDescricao" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Tipo</label><br />
                            <asp:Literal ID="litTipo" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Portador</label><br />
                            <asp:Literal ID="litPortador" runat="server" />
                        </div>
                        <div class="form-group">
                            <label for="<%=ddlProcessoDestino.ClientID%>">Processo destino <asp:RequiredFieldValidator ID="rfvProcessoDestino" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="ddlProcessoDestino" SetFocusOnError="True" runat="server" /></label>
                            <asp:DropDownList ID="ddlProcessoDestino" CssClass="form-control" DataTextField="Nome" DataValueField="IdProcesso" runat="server" />
                        </div>
                        <div class="form-group">
                            <label for="<%=txtDespacho.ClientID%>">Despacho <asp:RequiredFieldValidator ID="rfvDespacho" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtDespacho" SetFocusOnError="True" runat="server" /></label>
                            <asp:TextBox ID="txtDespacho" CssClass="form-control" TextMode="MultiLine" runat="server" />
                        </div>
                        <div class="form-group">
                            <label for="<%=txtEntreguePara.ClientID%>">Entregue para <asp:RequiredFieldValidator ID="rfvEntreguePara" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtEntreguePara" SetFocusOnError="True" runat="server" /></label>
                            <asp:TextBox ID="txtEntreguePara" CssClass="form-control" runat="server" />
                        </div>
                    </div>
                </div>
            </div><!-- /.box-body -->
            <div class="box-footer">
                <asp:Button ID="btnMovimentar" CssClass="btn btn-primary" Text="Movimentar" CausesValidation="true" OnClick="Movimentar" runat="server" />
            </div>
        </div><!-- /.box -->

        </section><!-- /.content -->
    </div>

    </form>

    <!-- jQuery 2.1.4 -->
    <script src="../plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="../bootstrap/js/bootstrap.min.js"></script>

    <!-- CUSTOM -->

    

    <!-- FIM-CUSTOM -->

    <!-- SlimScroll -->
    <script src="../plugins/slimScroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="../plugins/fastclick/fastclick.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../dist/js/app.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../dist/js/demo.js"></script>
    <!-- page script -->
    <script>
        $(function () {
            
        });
    </script>

</body>
</html>
