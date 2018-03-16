<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LFC.GesDoc.Site.sistema.Login" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>GesDoc | Sistema de Gestão de Documentos LFC</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css">

    <!-- FancyBox -->
    <link rel="stylesheet" href="plugins/fancybox/jquery.fancybox.css?v=2.1.5" media="screen" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body class="hold-transition login-page">
    
    <form runat="server">

    <div class="login-box">
        <div class="login-logo">
            <b>GesDoc</b>LFC
        </div><!-- /.login-logo -->
        <div class="login-box-body">
            <p class="login-box-msg">Preencha o formul&aacute;rio abaixo</p>
            <div class="form-group has-feedback">
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
                <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
            </div>
            <div class="form-group has-feedback">
                <asp:TextBox ID="txtSenha" TextMode="Password" CssClass="form-control" runat="server" />
                <span class="glyphicon glyphicon-lock form-control-feedback"></span>
            </div>
            <div class="row">
                <div class="col-xs-4">
                    <asp:Button ID="btnEntrar" CssClass="btn btn-primary btn-block btn-flat" Text="Entrar" OnClick="Entrar" runat="server" />
                </div><!-- /.col -->
            </div>

            <br><a href="EsqueciSenha.aspx" class="esqueciSenha">Esqueci minha senha</a><br>
        </div><!-- /.login-box-body -->
    </div><!-- /.login-box -->

    <!-- jQuery 2.1.4 -->
    <script src="plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="bootstrap/js/bootstrap.min.js"></script>

    <!-- CUSTOM -->

    <!-- FancyBox -->
    <script src="plugins/fancybox/jquery.fancybox.js?v=2.1.5"></script>

    <!-- FIM-CUSTOM -->

    <script>
        $(function () {
            $("#txtEmail").attr("placeholder", "E-mail");
            $("#txtSenha").attr("placeholder", "Senha");

            $(".esqueciSenha").fancybox({
                'width': 450,
                'height': 375,
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

    </form>

</body>
</html>
