<%@ Page Title="" Language="C#" MasterPageFile="~/gestor/MasterPages/mpGesDoc.Master" AutoEventWireup="true" CodeBehind="ListarTiposDocumentos.aspx.cs" Inherits="LFC.GesDoc.Site.gestor.TiposDocumentos.ListarTiposDocumentos" %>

<asp:Content ContentPlaceHolderID="cphHEAD" Runat="Server">

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

<asp:Content ContentPlaceHolderID="cphCONTEUDO" Runat="Server">

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
        Listar Tipos de Documentos
        </h1>
        <ol class="breadcrumb">
            <li><a href="../Home/Default.aspx"><i class="fa fa-home"></i> Página inicial</a></li>
            <li>Tipos de Documentos</li>
            <li class="active">Listar Tipos de Documentos</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- Default box -->
        <div class="box">
            <div class="box-header">
                <button id="btnCadastrarTipoDocumento" class="btn btn-block btn-primary btn-sm" style="width:200px" onclick="location='CadastrarTipoDocumento.aspx'">Cadastrar Tipo de Documento</button>
            </div><!-- /.box-header -->
            <div class="box-body">
                <table id="dataTable" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Guarda interna</th>
                        <th>Guarda externa</th>
                        <th>Opções</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="TiposDocumentos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("Nome")%></td>
                                <td><%#Eval("GuardaInterna")%></td>
                                <td><%#Eval("GuardaExterna")%></td>
                                <td><a href="AlterarTipoDocumento.aspx?idTpd=<%#Eval("IdTipoDocumento")%>"><button class="btn btn-primary btn-xs"><i class="fa fa-edit"></i></button></a>&nbsp<button class="btn btn-primary btn-xs" onclick="return confirmaExclusao(this, <%#Eval("IdTipoDocumento")%>);"><i class="fa fa-trash"></i></button></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                </table>
            </div><!-- /.box-body -->
        </div><!-- /.box -->

    </section><!-- /.content -->

</asp:Content>

<asp:Content ContentPlaceHolderID="cphFOOTER" Runat="Server">

    <!-- jQuery 2.1.4 -->
    <script src="../plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="../bootstrap/js/bootstrap.min.js"></script>

    <!-- CUSTOM -->

    <!-- DataTables -->
    <script src="../plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>

    <!-- Bootbox -->
    <script src="../plugins/bootbox/bootbox.min.js"></script>

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
        function confirmaExclusao(sender, id) {
            if ($(sender).attr("confirmed") == "true") { return true; }

            //bootbox.confirm("Você tem certeza que deseja excluir este usuário?", function (confirmed) {
            //    if (confirmed) {
            //        window.location.href = "ListarDocumentos.aspx?act=exc&idDoc=" + id;
            //    }
            //});

            bootbox.confirm({
                title: 'Confirmar exclusão',
                message: 'Você tem certeza que deseja excluir este tipo de documento?',
                buttons: {
                    'cancel': {
                        label: 'Não',
                        className: 'btn-primary pull-left'
                    },
                    'confirm': {
                        label: 'Sim',
                        className: 'btn-danger pull-right'
                    }
                },
                callback: function (result) {
                    if (result) {
                        window.location.href = "ListarTiposDocumentos.aspx?act=exc&idTpd=" + id;
                    }
                }
            });

            return false;
        }

        $(function () {
            $('#dataTable').dataTable({
                "bAutoWidth": false,
                "aoColumns": [
                    { "sWidth": "50%", "bSortable": false },
                    { "sWidth": "20%", "bSortable": false },
                    { "sWidth": "20%", "bSortable": false },
                    { "sWidth": "10%", "bSortable": false }
                ],
                "oLanguage": {
                    "oPaginate": {
                        "sFirst": "Primeira",
                        "sPrevious": "Anterior",
                        "sNext": "Próxima",
                        "sLast": "Última"
                    },
                    "sProcessing": "Processando...",
                    "sLengthMenu": "Mostrando _MENU_ registros por página",
                    "sZeroRecords": "Registro não encontrado",
                    "sInfo": "Mostrando _START_ até _END_ de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
                    "sInfoFiltered": "(filtered from _MAX_ total records)",
                    "sSearch": "Pesquisar: "
                }
            });
        });
    </script>

</asp:Content>