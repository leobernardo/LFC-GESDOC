﻿<%@ Page Title="" Language="C#" MasterPageFile="~/gestor/MasterPages/mpGesDoc.Master" AutoEventWireup="true" CodeBehind="CadastrarUnidade.aspx.cs" Inherits="LFC.GesDoc.Site.gestor.Unidades.CadastrarUnidade" %>

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
        Unidades
        <small>cadastrar unidade</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="../Home/Default.aspx"><i class="fa fa-home"></i> Página inicial</a></li>
            <li><a href="../Unidades/ListarUnidades.aspx">Unidades</a></li>
            <li class="active">Cadastrar Unidade</li>
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
                                    <label for="txtDescricao">Descrição <asp:RequiredFieldValidator ID="rfvDescricao" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtDescricao" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtDescricao" CssClass="form-control" MaxLength="100" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Ativo?</label><br />
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="radAtivo_N" GroupName="radAtivo" Text="Não" Checked="true" runat="server" />
                                    </label>
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="radAtivo_S" GroupName="radAtivo" Text="Sim" runat="server" />
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div><!-- /.box-body -->
                    <div class="box-footer">
                        <asp:Button ID="btnCadastrar" CssClass="btn btn-primary" Text="Cadastrar" CausesValidation="true" OnClick="Cadastrar" runat="server" />
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

</asp:Content>