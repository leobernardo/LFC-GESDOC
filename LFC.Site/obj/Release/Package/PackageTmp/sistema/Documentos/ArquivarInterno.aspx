<%@ Page Title="" Language="C#" MasterPageFile="~/sistema/MasterPages/mpGesDoc.Master" AutoEventWireup="true" CodeBehind="ArquivarInterno.aspx.cs" Inherits="LFC.GesDoc.Site.sistema.Documentos.ArquivarInterno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHEAD" runat="server">

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

    <style>
        body { overflow-x: hidden; }
        .btn-file { position: relative; overflow: hidden; }
		.btn-file input[type=file] {
            position: absolute;
		    top: 0;
		    right: 0;
		    min-width: 100%;
		    min-height: 100%;
		    font-size: 999px;
		    text-align: right;
		    filter: alpha(opacity=0);
		    opacity: 0;
		    background: red;
		    cursor: inherit;
		    display: block;
		}
        input[readonly] { background-color: white !important; cursor: text !important; }
    </style>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <form runat="server">

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
        Documentos
        <small>arquivar documento (interno)</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="../Home/Default.aspx"><i class="fa fa-home"></i> Página inicial</a></li>
            <li><a href="../Documentos/ListarDocumentos.aspx">Documentos</a></li>
            <li class="active">Arquivar Documento (interno)</li>
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
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <label for="<%=txtArquivo.ClientID%>">Arquivo <asp:RequiredFieldValidator ID="rfvArquivo" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtArquivo" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtArquivo" CssClass="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="<%=txtGaveta.ClientID%>">Gaveta <asp:RequiredFieldValidator ID="rfvGaveta" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtGaveta" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtGaveta" CssClass="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="<%=txtPasta.ClientID%>">Pasta <asp:RequiredFieldValidator ID="rfvPasta" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtPasta" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtPasta" CssClass="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label>Arquivo</label>
				                    <div class="input-group">
					                    <span class="input-group-btn">
						                    <span class="btn btn-primary btn-file">
							                    Procurar&hellip; <asp:FileUpload ID="txtArquivoDocumento" runat="server" />
						                    </span>
					                    </span>
                                        <asp:TextBox ID="txtNomeArquivo" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
				                    </div>
                                </div>
                            </div>
                        </div>
                    </div><!-- /.box-body -->
                    <div class="box-footer">
                        <asp:Button ID="btnArquivar" CssClass="btn btn-primary" Text="Arquivar" CausesValidation="true" OnClick="Arquivar" runat="server" />
                    </div>
                </div><!-- /.box -->
            </div><!-- /.col-md-6 -->
        </div><!-- /.row -->

    </section><!-- /.content -->

    </form>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphFOOTER" runat="server">

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
        $(document).on('change', '.btn-file :file', function () {
            var input = $(this),
			numFiles = input.get(0).files ? input.get(0).files.length : 1,
			label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
            input.trigger('fileselect', [numFiles, label]);
        });

        $(function () {
            $('.btn-file :file').on('fileselect', function (event, numFiles, label) {
                var input = $(this).parents('.input-group').find(':text'),
					log = numFiles > 1 ? numFiles + ' files selected' : label;

                if (input.length) {
                    input.val(log);
                } else {
                    if (log) alert(log);
                }
            });
        });
    </script>

</asp:Content>
