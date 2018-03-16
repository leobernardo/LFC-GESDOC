<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoricoDocumento.aspx.cs" Inherits="LFC.GesDoc.Site.gestor.Documentos.HistoricoDocumento" %>
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
                <h3 class="box-title">Documentos <i class="fa fa-angle-right"></i> Listar Documentos <i class="fa fa-angle-right"></i> Histórico do Documento <label class="text-red"><asp:Label ID="lblDescricao" runat="server" /></label></h3>
            </div><!-- /.box-header -->
            <div class="box-body">
                <table class="table table-striped">
                    <tr>
                        <th style="width:20%">Data e hora da movimentação</th>
                        <th style="width:15%">Processo origem</th>
                        <th style="width:15%">Processo destino</th>
                        <th style="width:15%">Recebido</th>
                        <th style="width:20%">Data e hora do recebimento</th>
                        <th style="width:15%">Prazo</th>
                    </tr>
                    <asp:Repeater ID="rptHistoricoDocumento" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("DataHoraMovimentacao")%></td>
                                <td><%#getProcesso(Convert.ToInt32(Eval("ProcessoOrigem")))%><br /><b><i>(<%#Eval("MovimentadoPor")%>)</i></b></td>
                                <td><%#getProcesso(Convert.ToInt32(Eval("ProcessoDestino")))%><br /><br /><b>Entregue para: <%#Eval("EntreguePara")%><br /><br />Recebido por: <%#Eval("RecebidoPor")%></b></td>
                                <td><%#getRecebido(Eval("Recebido").ToString())%></td>
                                <td><%#Eval("DataHoraRecebimento")%></td>
                                <td><%#Convert.ToDateTime(Eval("Prazo")).ToShortDateString()%></td>
                            </tr>
                            <tr><td colspan="6">Despacho: <b><%#Eval("Despacho")%></b></td></tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div><!-- /.box-body -->
        </div><!-- /.box -->

        </section><!-- /.content -->
    </div>

    </form>

    <!-- jQuery 2.1.4 -->
    <script src="../plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="../bootstrap/js/bootstrap.min.js"></script>

    <!-- CUSTOM -->

    <!-- DataTables -->
    <script src="../plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>

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
            //$('#dataTable').dataTable({
            //    "oLanguage": {
            //        "oPaginate": {
            //            "sFirst": "Primeira",
            //            "sPrevious": "Anterior",
            //            "sNext": "Próxima",
            //            "sLast": "Última"
            //        },
            //        "sProcessing": "Processando...",
            //        "sLengthMenu": "Mostrando _MENU_ registros por página",
            //        "sZeroRecords": "Registro não encontrado",
            //        "sInfo": "Mostrando _START_ até _END_ de _TOTAL_ registros",
            //        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            //        "sInfoFiltered": "(filtered from _MAX_ total records)",
            //        "sSearch": "Pesquisar: "
            //    },
            //    "bAutoWidth": false,
            //    "aoColumns": [
            //      { "sWidth": "20%" },
            //      { "sWidth": "15%" },
            //      { "sWidth": "15%" },
            //      { "sWidth": "15%" },
            //      { "sWidth": "20%" },
            //      { "sWidth": "15%" }
            //    ]
            //});
        });
    </script>

</body>
</html>
