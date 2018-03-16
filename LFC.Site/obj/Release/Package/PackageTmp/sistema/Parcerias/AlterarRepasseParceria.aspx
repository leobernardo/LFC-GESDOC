<%@ Page Title="" Language="C#" MasterPageFile="~/sistema/MasterPages/mpGesDoc.Master" AutoEventWireup="true" CodeBehind="AlterarRepasseParceria.aspx.cs" Inherits="LFC.GesDoc.Site.sistema.Parcerias.AlterarRepasseParceria" %>

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
        Repasses da Parceria
        <small>alterar repasse da parceria</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="../Home/Default.aspx"><i class="fa fa-home"></i> Página inicial</a></li>
            <li><a href="../Parcerias/ListarParcerias.aspx">Parcerias</a></li>
            <li>Repasses da Parceria</li>
            <li class="active">Alterar Repasse da Parceria</li>
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
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="<%=txtDataVencimento.ClientID%>">Data do vencimento <asp:RequiredFieldValidator ID="rfvDataVencimento" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtDataVencimento" SetFocusOnError="True" runat="server" /></label>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <asp:TextBox ID="txtDataVencimento" CssClass="form-control pull-right" runat="server" />
                                    </div><!-- /.input group -->
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="<%=txtDataRepasse.ClientID%>">Data do repasse</label>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <asp:TextBox ID="txtDataRepasse" CssClass="form-control pull-right" runat="server" />
                                    </div><!-- /.input group -->
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtValor">Valor(R$) <asp:RequiredFieldValidator ID="rfvValor" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtValor" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtValor" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlStatus">Status</label>
                                    <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Pago" Value="pago" />
                                        <asp:ListItem Text="Pendente" Value="pendente" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div><!-- /.box-body -->
                    <div class="box-footer">
                        <asp:Button ID="btnAlterar" CssClass="btn btn-primary" Text="Alterar" CausesValidation="true" OnClick="Alterar" runat="server" />
                    </div>
                </div><!-- /.box -->
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

    <script src="../plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="../plugins/datepicker/locales/bootstrap-datepicker.pt-BR.js"></script>

    <script src="../plugins/priceformat/jquery.price_format.2.0.js"></script>

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
            $("#<%=txtDataVencimento.ClientID%>").datepicker({ format: "dd/mm/yyyy", language: "pt-BR" });
            $("#<%=txtDataRepasse.ClientID%>").datepicker({ format: "dd/mm/yyyy", language: "pt-BR" });

            $("#<%=txtValor.ClientID%>").priceFormat({
                prefix: '',
                centsSeparator: ',',
                thousandsSeparator: '.'
            });
        });
    </script>

</asp:Content>