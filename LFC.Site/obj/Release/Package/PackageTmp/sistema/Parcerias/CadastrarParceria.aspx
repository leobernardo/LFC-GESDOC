<%@ Page Title="" Language="C#" MasterPageFile="~/sistema/MasterPages/mpGesDoc.Master" AutoEventWireup="true" CodeBehind="CadastrarParceria.aspx.cs" Inherits="LFC.GesDoc.Site.sistema.Parcerias.CadastrarParceria" %>

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

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <form runat="server">

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
        Parcerias
        <small>cadastrar parceria</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="../Home/Default.aspx"><i class="fa fa-home"></i> Página inicial</a></li>
            <li><a href="../Parcerias/ListarParcerias.aspx">Parcerias</a></li>
            <li class="active">Cadastrar Parceria</li>
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
                                    <label for="ddlUnidade">Unidade <asp:RequiredFieldValidator ID="rfvUnidade" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="ddlUnidade" SetFocusOnError="True" runat="server" /></label>
                                    <asp:DropDownList ID="ddlUnidade" CssClass="form-control" DataTextField="Descricao" DataValueField="IdUnidade" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtNome">Nome <asp:RequiredFieldValidator ID="rfvNome" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtNome" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtNome" CssClass="form-control" MaxLength="255" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="ddlTipo">Tipo <asp:RequiredFieldValidator ID="rfvTipo" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="ddlTipo" SetFocusOnError="True" runat="server" /></label>
                                    <asp:DropDownList ID="ddlTipo" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="" Value="" />
                                        <asp:ListItem Text="Pública" Value="Pública" />
                                        <asp:ListItem Text="Privada" Value="Privada" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtNome">Objetivo <asp:RequiredFieldValidator ID="rfvObjetivo" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtObjetivo" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtObjetivo" CssClass="form-control" TextMode="MultiLine" Height="200" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtNome">Observações <asp:RequiredFieldValidator ID="rfvObservacoes" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtObservacoes" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtObservacoes" CssClass="form-control" TextMode="MultiLine" Height="200" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Possui pagamento de RH?</label><br />
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="radPossuiPagamentoRH_N" GroupName="radPossuiPagamentoRH" Text="Não" Checked="true" runat="server" />
                                    </label>
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="radPossuiPagamentoRH_S" GroupName="radPossuiPagamentoRH" Text="Sim" runat="server" />
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Possui recursos financeiros?</label><br />
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="radPossuiRecursosFinanceiros_N" GroupName="radPossuiRecursosFinanceiros" Text="Não" Checked="true" runat="server" />
                                    </label>
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="radPossuiRecursosFinanceiros_S" GroupName="radPossuiRecursosFinanceiros" Text="Sim" runat="server" />
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div id="divValorPrevistoAnual" class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtValorPrevistoAnual">Valor previsto anual(R$)</label>
                                    <asp:TextBox ID="txtValorPrevistoAnual" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Possui vigência determinada?</label><br />
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="radPossuiVigencia_N" GroupName="radPossuiVigencia" Text="Não" Checked="true" runat="server" />
                                    </label>
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="radPossuiVigencia_S" GroupName="radPossuiVigencia" Text="Sim" runat="server" />
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div id="divVigencia">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="<%=txtDataInicioVigencia.ClientID%>">Início da vigência</label>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <asp:TextBox ID="txtDataInicioVigencia" CssClass="form-control pull-right" runat="server" />
                                    </div><!-- /.input group -->
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="<%=txtDataFimVigencia.ClientID%>">Fim da vigência</label>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <asp:TextBox ID="txtDataFimVigencia" CssClass="form-control pull-right" runat="server" />
                                    </div><!-- /.input group -->
                                </div>
                            </div>
                        </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Arquivo</label>
				                    <div class="input-group">
					                    <span class="input-group-btn">
						                    <span class="btn btn-primary btn-file">
							                    Procurar&hellip; <asp:FileUpload ID="txtArquivoParceria" runat="server" />
						                    </span>
					                    </span>
                                        <asp:TextBox ID="txtNomeArquivo" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
				                    </div>
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
        $(document).on('change', '.btn-file :file', function () {
            var input = $(this),
			numFiles = input.get(0).files ? input.get(0).files.length : 1,
			label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
            input.trigger('fileselect', [numFiles, label]);
        });

        $(function () {
            $('#divVigencia').hide();
            $('#divValorPrevistoAnual').hide();

            $("#<%=txtDataInicioVigencia.ClientID%>").datepicker({ format: "dd/mm/yyyy", language: "pt-BR" });
            $("#<%=txtDataFimVigencia.ClientID%>").datepicker({ format: "dd/mm/yyyy", language: "pt-BR" });

            $("#<%=txtValorPrevistoAnual.ClientID%>").priceFormat({ prefix: '', centsSeparator: ',', thousandsSeparator: '.' });

            $('.btn-file :file').on('fileselect', function (event, numFiles, label) {
                var input = $(this).parents('.input-group').find(':text'),
					log = numFiles > 1 ? numFiles + ' files selected' : label;

                if (input.length) {
                    input.val(log);
                } else {
                    if (log) alert(log);
                }
            });

            $('#<%=radPossuiRecursosFinanceiros_N.ClientID%>').click(function () {
                $('#divValorPrevistoAnual').hide();
            });

            $('#<%=radPossuiRecursosFinanceiros_S.ClientID%>').click(function () {
                $('#divValorPrevistoAnual').show();
            });

            $('#<%=radPossuiVigencia_N.ClientID%>').click(function () {
                $('#divVigencia').hide();
            });

            $('#<%=radPossuiVigencia_S.ClientID%>').click(function () {
                $('#divVigencia').show();
            });
        });
    </script>

</asp:Content>