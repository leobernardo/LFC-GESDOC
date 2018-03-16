<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualizarParceria.aspx.cs" Inherits="LFC.GesDoc.Site.sistema.Parcerias.VisualizarParceria" %>
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
                <h3 class="box-title">Parcerias <i class="fa fa-angle-right"></i> Listar Parcerias <i class="fa fa-angle-right"></i> Visualizar Parceria</h3>
            </div><!-- /.box-header -->
            <div class="box-body">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="form-group">
                            <label>Unidade</label><br />
                            <asp:Literal ID="litUnidade" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Nome</label><br />
                            <asp:Literal ID="litNome" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Tipo</label><br />
                            <asp:Literal ID="litTipo" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Objetivo</label><br />
                            <asp:Literal ID="litObjetivo" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Observações</label><br />
                            <asp:Literal ID="litObservacoes" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Possui pagamento de RH?</label><br />
                            <asp:Literal ID="litPossuiPagamentoRH" runat="server" />
                        </div>

                        <div class="form-group">
                            <label>Possui recursos financeiros?</label><br />
                            <asp:Literal ID="litPossuiRecursosFinanceiros" runat="server" />
                        </div>

                        <div id="divValorPrevistoAnual" class="form-group" visible="false" runat="server">
                            <label>Valor previsto anual</label><br />
                            <asp:Literal ID="litValorPrevistoAnual" runat="server" />
                        </div>

                        <div class="form-group">
                            <label>Possui vigência determinada?</label><br />
                            <asp:Literal ID="litPossuiVigencia" runat="server" />
                        </div>

                        <div id="divVigencia" class="form-group" visible="false" runat="server">
                            <label>Período de vigência</label><br />
                            <asp:Literal ID="litVigencia" runat="server" />
                        </div>
                    </div>
                </div>
            </div><!-- /.box-body -->
            <div class="box-body">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Repasses da Parceria</h3>
                    </div><!-- /.box-header -->
                    <div class="box-body">
                        <table class="table table-bordered table-striped">
                        <thead>
                            <tr>
                                <th>Data do vencimento</th>
                                <th>Data do repasse</th>
                                <th>Valor do repasse</th>
                                <th>Status</th>
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
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        </table>
                    </div><!-- /.box-body -->
                </div><!-- /.box -->
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
            
        });
    </script>

</body>
</html>
