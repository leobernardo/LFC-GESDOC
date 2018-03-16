<%@ Page Title="" Language="C#" MasterPageFile="~/sistema/MasterPages/mpGesDoc.Master" AutoEventWireup="true" CodeBehind="ListarDocumentosReceber.aspx.cs" Inherits="LFC.GesDoc.Site.sistema.Documentos.ListarDocumentosReceber" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server">

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
    <!-- Fancybox -->
    <link rel="stylesheet" href="../plugins/fancybox/jquery.fancybox.css?v=2.1.5" media="screen" type="text/css" />
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

</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <form runat="server">

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
        Listar Documentos a Receber
        </h1>
        <ol class="breadcrumb">
            <li><a href="../Home/Default.aspx"><i class="fa fa-home"></i> Página inicial</a></li>
            <li class="active">Listar Documentos a Receber</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- Default box -->
        <div class="box">
            <div class="box-body">
                <table class="table table-striped">
                    <tr>
                        <th style="width:10%">&nbsp;</th>
                        <th style="width:80%">Descrição</th>
                        <th style="width:10%">&nbsp;</th>
                    </tr>
                    <asp:Repeater ID="DocumentosReceber" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><input type="checkbox" name="chkDocumentos" value="<%#Eval("Documento.IdDocumento")%>"></td>
                                <td><%#Eval("Documento.Descricao")%></td>
                                <td><a href="HistoricoDocumento.aspx?idDoc=<%#Eval("Documento.IdDocumento")%>" class="historicoDocumento"><button class="btn btn-primary btn-xs"><i class="fa fa-calendar"></i></button></a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table><br />
            </div><!-- /.box-body -->
            <div class="box-footer">
                <asp:Button ID="btnReceberSelecionados" CssClass="btn btn-success" Text="Receber documentos selecionados" OnClick="ReceberSelecionados" runat="server" />
            </div><!-- /.box-footer -->
        </div><!-- /.box -->

    </section><!-- /.content -->

    </form>

</asp:Content>

<asp:Content ContentPlaceHolderID="cphFOOTER" runat="server">

    <!-- jQuery 2.1.4 -->
    <script src="../plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="../bootstrap/js/bootstrap.min.js"></script>

    <!-- CUSTOM -->

    <!-- Fancybox -->
    <script src="../plugins/fancybox/jquery.fancybox.js?v=2.1.5"></script>

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
            $(".historicoDocumento").fancybox({
                'width': 950,
                'height': 600,
                'padding': 10,
                'autoScale': false,
                'type': 'iframe',
                autoSize: false,
                closeClick: false,
                openEffect: 'none',
                closeEffect: 'none',
                helpers: {
                    overlay: {
                        opacity: 0.5,
                        css: { 'background': 'rgba(0, 0, 0, 0.5)' }
                    }
                }
            });
        });
    </script>

</asp:Content>
