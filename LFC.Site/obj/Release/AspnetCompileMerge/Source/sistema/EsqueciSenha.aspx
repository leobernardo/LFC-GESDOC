<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EsqueciSenha.aspx.cs" Inherits="LFC.GesDoc.Site.sistema.EsqueciSenha" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>GesDoc | Sistema de Gestão de Documentos LFC</title>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- DatePicker -->
    <link rel="stylesheet" href="plugins/datepicker/datepicker3.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css">

    <style>
        body { overflow-x: hidden; }
    </style>

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
                <h3 class="box-title">Esqueci minha senha</h3>
            </div><!-- /.box-header -->
            <div class="box-body">
                <div class="alert alert-info alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <h4><i class="icon fa fa-info"></i> Atenção!</h4>
                    Informe seu e-mail de cadastro, o mesmo usado para o login no sistema.
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="<%=txtEmail.ClientID%>">E-mail <asp:RequiredFieldValidator ID="rfvEmail" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtEmail" SetFocusOnError="True" runat="server" /></label>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
                        </div>
                    </div>
                </div>
            </div><!-- /.box-body -->
            <div class="box-footer">
                <asp:Button ID="btnEnviar" CssClass="btn btn-primary" Text="Enviar" CausesValidation="true" OnClick="Enviar" runat="server" />
            </div>
        </div><!-- /.box -->

        </section><!-- /.content -->
    </div>

    </form>

    <!-- jQuery 2.1.4 -->
    <script src="plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="bootstrap/js/bootstrap.min.js"></script>

    <!-- CUSTOM -->
    <!-- FIM-CUSTOM -->

    <!-- SlimScroll -->
    <script src="plugins/slimScroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="plugins/fastclick/fastclick.min.js"></script>
    <!-- AdminLTE App -->
    <script src="dist/js/app.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="dist/js/demo.js"></script>
    <!-- page script -->
    <script>
        $(function () {
            
        });
    </script>

</body>
</html>
