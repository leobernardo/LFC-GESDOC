<%@ Page Title="" Language="C#" MasterPageFile="~/gestor/MasterPages/mpGesDoc.Master" AutoEventWireup="true" CodeBehind="RepassesParceria.aspx.cs" Inherits="LFC.GesDoc.Site.gestor.Parcerias.RepassesParceria" %>

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

</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <form runat="server">

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
        Repasses da Parceria
        </h1>
        <ol class="breadcrumb">
            <li><a href="../Home/Default.aspx"><i class="fa fa-home"></i> Página inicial</a></li>
            <li><a href="ListarParcerias.aspx">Parcerias</a></li>
            <li class="active">Repasses da Parceria</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- Default box -->
        <div class="box">
            <div class="box-header">
                <asp:Button ID="btnCadastrarRepasseParceria" CssClass="btn btn-block btn-primary btn-sm" Width="200" Text="Cadastrar Repasse da Parceria" OnClick="CadastrarRepasseParceria" runat="server" />
            </div><!-- /.box-header -->
            <div class="box-body">
                <table id="dataTable" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>Data do vencimento</th>
                        <th>Data do repasse</th>
                        <th>Valor do repasse</th>
                        <th>Status</th>
                        <th>Opções</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptRepassesParceria" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#String.Format("{0:dd/MM/yyyy}", Eval("DataVencimento"))%></td>
                                <td><%#getDataRepasse(Convert.ToDateTime(Eval("DataRepasse")))%></td>
                                <td><%#String.Format("{0:0.00}", Eval("ValorRepasse"))%></td>
                                <td><%#getStatus(Convert.ToString(Eval("Status")))%></td>
                                <td><a href="AlterarRepasseParceria.aspx?idPrc=<%#Eval("Parceria.IdParceria")%>&idRpp=<%#Eval("IdRepasseParceria")%>" data-toggle="tooltip" data-placement="top" title="Alterar Repasse da Parceria"><i class="fa fa-edit" style="margin-right:10px"></i></a><a href="#" onclick="return confirmaExclusao(this, <%#Eval("IdRepasseParceria")%>);" data-toggle="tooltip" data-placement="top" title="Excluir Repasse da Parceria"><i class="fa fa-trash"></i></a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                </table>
            </div><!-- /.box-body -->
        </div><!-- /.box -->

        <div class="row">
            <div class="col-lg-4 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-aqua">
                    <div class="inner">
                        <h3><asp:Literal ID="litTotalRepasses" runat="server" /></h3>
                        <p>Total de repasses</p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-dollar"></i>
                    </div>
                </div>
            </div><!-- ./col -->

            <div class="col-lg-4 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-green">
                    <div class="inner">
                        <h3><asp:Literal ID="litTotalRepassesPagos" runat="server" /></h3>
                        <p>Repasses pagos</p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-dollar"></i>
                    </div>
                </div>
            </div><!-- ./col -->

            <div class="col-lg-4 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-red">
                    <div class="inner">
                        <h3><asp:Literal ID="litTotalRepassesPendentes" runat="server" /></h3>
                        <p>Repasses pendentes</p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-dollar"></i>
                    </div>
                </div>
            </div><!-- ./col -->
        </div><!-- /.row -->

    </section><!-- /.content -->

    </form>

</asp:Content>

<asp:Content ContentPlaceHolderID="cphFOOTER" runat="server">

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

            bootbox.confirm({
                title: 'Confirmar exclusão',
                message: 'Você tem certeza que deseja excluir este repasse da parceria?',
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
                        window.location.href = "RepassesParceria.aspx?act=exc&idPrc=<%=Request.QueryString["idPrc"]%>&idRpp=" + id;
                    }
                }
            });

            return false;
        }

        $(function () {
            $('#dataTable').dataTable({
                "bAutoWidth": false,
                "aoColumns": [
                    { "sWidth": "30%", "bSortable": false },
                    { "sWidth": "30%", "bSortable": false },
                    { "sWidth": "20%", "bSortable": false },
                    { "sWidth": "10%", "bSortable": false },
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