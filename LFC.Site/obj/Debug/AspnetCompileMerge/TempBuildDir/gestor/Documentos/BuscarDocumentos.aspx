<%@ Page Title="" Language="C#" MasterPageFile="~/gestor/MasterPages/mpGesDoc.Master" AutoEventWireup="true" CodeBehind="BuscarDocumentos.aspx.cs" Inherits="LFC.GesDoc.Site.gestor.Documentos.BuscarDocumentos" %>

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
    <!-- DatePicker -->
    <link rel="stylesheet" href="../plugins/datepicker/datepicker3.css" />
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
        Documentos
        <small>buscar documentos</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="../Home/Default.aspx"><i class="fa fa-home"></i> Página inicial</a></li>
            <li><a href="../Documentos/ListarDocumentos.aspx">Documentos</a></li>
            <li class="active">Buscar Documentos</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <div class="row">
            <!-- left column -->
            <div class="col-md-12">
                <!-- Default box -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Preencha o formulário abaixo</h3>
                    </div><!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="ddlProcesso">Processo</label>
                                    <asp:DropDownList ID="ddlProcesso" CssClass="form-control" DataTextField="Nome" DataValueField="IdProcesso" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtDescricao">Descrição</label>
                                    <asp:TextBox ID="txtDescricao" CssClass="form-control" MaxLength="100" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="ddlTipoDocumento">Tipo de Documento</label>
                                    <asp:DropDownList ID="ddlTipoDocumento" CssClass="form-control" DataTextField="Nome" DataValueField="IdTipoDocumento" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="<%=txtDataCadastro.ClientID%>">Data do cadastro</label>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <asp:TextBox ID="txtDataCadastro" CssClass="form-control pull-right" runat="server" />
                                    </div><!-- /.input group -->
                                </div>
                            </div>
                        </div>
                    </div><!-- /.box-body -->
                    <div class="box-footer">
                        <asp:Button ID="btnBuscar" CssClass="btn btn-primary" Text="Buscar" OnClick="Buscar" runat="server" />
                    </div>
                </div><!-- /.box -->

                <div id="divResultadoBusca" class="box" runat="server">
                    <div class="box-body">
                        <table id="dataTable" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>Tipo de documento</th>
                                    <th>Descrição</th>
                                    <th>Data da emissão</th>
                                    <th>Opções</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="Documentos" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#getTipoDocumento(Convert.ToInt32(Eval("TipoDocumento.IdTipoDocumento")))%></td>
                                            <td><%#Eval("Descricao")%></td>
                                            <td><%#getDataEmissao(Convert.ToDateTime(Eval("DataEmissao")))%></td>
                                            <td><%#getOpcoes(Convert.ToInt32(Eval("IdDocumento")))%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div><!-- /.col-md-6 -->
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

    <script src="../plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="../plugins/datepicker/locales/bootstrap-datepicker.pt-BR.js"></script>

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

            bootbox.confirm("Você tem certeza que deseja excluir este documento?", function (confirmed) {
                if (confirmed) {
                    window.location.href = "ListarDocumentos.aspx?act=exc&idDoc=" + id;
                }
            });

            return false;
        }

        $(function () {
            $('#dataTable').dataTable({
                "bAutoWidth": false,
                "aoColumns": [
                    { "sWidth": "20%", "bSortable": false },
                    { "sWidth": "55%", "bSortable": false },
                    { "sWidth": "15%", "bSortable": false },
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

            $("#<%=txtDataCadastro.ClientID%>").datepicker({ format: "dd/mm/yyyy", language: "pt-BR" });
        });
    </script>

</asp:Content>
