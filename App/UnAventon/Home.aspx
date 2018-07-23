<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UnAventon.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="~/img/logoicon.ico" />
    <title> Un Aventón </title>   
    <meta charset="UTF-8" />


    <link rel="stylesheet" href="<%=Page.ResolveUrl("~/Content/bootstrap.css") %>"> 
    <link rel="stylesheet" href="<%=Page.ResolveUrl("~/Scripts/aMainCss.css") %>">
    <script src="<%=Page.ResolveUrl("~/Scripts/jquery-3.3.1.js") %>"></script> 
    <script src="<%=Page.ResolveUrl("~/Scripts/bootstrap.js") %>"></script> 

    <style>
        body {
            background-image: url('<%=Page.ResolveUrl("~/img/Fondo5.jpg") %>');
            background-position: center center;
            backgroun-repeat: no-repeat;
            background-attachment: fixed;
            background-size: cover;
            background-color: #464646;
        }        
        .Text-Shadow{
            text-shadow: 
                3px 3px 5px #000000, 
                6px 6px 5px #464646, 
                9px 9px 5px #808080;
        }

        /*.boton_personalizado {
            font-family: 'arial black';
            color: #FFFFFF !important;
            font-size:12px;   
            padding:10px,25px;
            text-shadow: 0px 0px 10px #7A3A3C;
            box-shadow: 1px 1px 1px #7A3A3C;
            padding: 10px 25px;
            -moz-border-radius: 12px;
            -webkit-border-radius: 12px;
            border-radius: 12px;
            border: 2px groove #000000;
            background: #F17376;
            background: linear-gradient(top, #F17376, #A64F51);
            background: -ms-linear-gradient(top, #F17376, #A64F51);
            background: -webkit-gradient(linear, left top, left bottom, from(#F17376), to(#A64F51));
            background: -moz-linear-gradient(top, #F17376, #A64F51);
        }

            .boton_personalizado:hover {
                color: #FFFFFF !important;
                background: #F17376;
                background: linear-gradient(top, #C25C5F, #8F4446);
                background: -ms-linear-gradient(top, #C25C5F, #8F4446);
                background: -webkit-gradient(linear, left top, left bottom, from(#C25C5F), to(#8F4446));
                background: -moz-linear-gradient(top, #C25C5F, #8F4446);
    }*/

    .boton_personalizado {
    font-family: 'arial black';
    color: #FFFFFF !important;
    font-size: 14px;
    text-shadow: 0px 0px 10px #7A3A3C;
    box-shadow: 1px 1px 1px #7A3A3C;
    padding: 10px 25px;
    -moz-border-radius: 12px;
    -webkit-border-radius: 12px;
    border-radius: 12px;
    border: 2px groove #000000;
    background: #F17376;
    background: linear-gradient(top, #F17376, #A64F51);
    background: -ms-linear-gradient(top, #F17376, #A64F51);
    background: -webkit-gradient(linear, left top, left bottom, from(#F17376), to(#A64F51));
    background: -moz-linear-gradient(top, #F17376, #A64F51);
    width:160px;
    height:auto;  
    text-align:center;

}

    .boton_personalizado:hover {
        color: #FFFFFF !important;
        background: #F17376;
        background: linear-gradient(top, #C25C5F, #8F4446);
        background: -ms-linear-gradient(top, #C25C5F, #8F4446);
        background: -webkit-gradient(linear, left top, left bottom, from(#C25C5F), to(#8F4446));
        background: -moz-linear-gradient(top, #C25C5F, #8F4446);
    }
    </style>

</head>
<body >
    <div>        
    <form runat="server">
    <div class="rows">
        <div class="col-md-8" >
            <img style="margin-left:5%"  src="<%=Page.ResolveUrl("~/img/Logo.png")%>" height="8%" width="8%" alt="Logo Un Aventón"/>            
        </div>
        <div class="col-md-16">
            <h1 class="text-center Text-Shadow" style="color:white"><big> Bienvenido a Un Aventón</big></h1>
        </div>
    </div>
    <p class="text-center Text-Shadow" style="color:white" ><strong><big>En está página podrá buscar y compartir viajes con los demás usuarios<big></strong></p>
    <hr />
        <h4 class="text-center Text-Shadow"  style="color:white" > Por favor, ingresé los datos solicitados a continuación para poder usar la página o puede             
                <asp:LinkButton style="color:orangered" OnClick="Unnamed_Click" runat="server"><b>continuar como invitado</b></asp:LinkButton>   
        </h4>
        <%--MENSAJE ALERTA--%>
    <div class="row" id="divMsjAlerta" runat="server" visible="false">
        <div class="alert alert-danger" role="alert">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <asp:Literal runat="server" ID="liMensajeAlerta" />
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3" >
                <div class="panel panel-login" >
                    <div class="panel-heading" >                        
                        <hr/>
                    </div>
                    <div class="panel-body" >
                        <div class="row" >
                            <div class="col-md-16" >
                                <div id="login-form" role="form" style="display: block;">
                                    <div class="form-group" runat="server">
                                        <asp:TextBox runat="server" class="form-control" placeholder="Email" ID="tbEmail" />         
                                        <asp:CustomValidator Enabled="true" ErrorMessage="errormessage" ID="cvEmail" ValidationGroup="GroupLogin" runat="server" OnServerValidate="cvEmail_ServerValidate" />
                                    </div>
                                    <div class="form-group" runat="server">
                                        <asp:TextBox runat="server" type="password" id="tbPassword" class="form-control" placeholder="Contraseña"/>     
                                        <asp:CustomValidator Enabled="true" ErrorMessage="Usuario o Contraseña invalidos." ID="cvPassword" runat="server" ValidationGroup="GroupLogin" OnServerValidate="cvPassword_ServerValidate" />
                                    </div>                                   
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-sm-6 col-sm-offset-3">
                                                <asp:LinkButton Text="Iniciar Sesion" class="form-control boton_personalizado" runat="server" tabindex="4" id="idInciarSesion" OnClick="idInciarSesion_Click"/>
                                            </div>
                                            <div class="col-sm-6 col-sm-offset-3">
                                                <asp:LinkButton Text="Registrar" runat="server" class="form-control boton_personalizado" tabindex="4" ID="btnRegistrar" OnClick="btnRegistrar_Click"/>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-lg-12">                                                 
                                            </div>
                                        </div>
                                    </div>
                                </div>                               
                            </div>
                        </div>                        
                    </div>
                </div>
            </div>
        </div>
        <h6 class="text-center Text-Shadow"  style="color:white" > Si usted tenia una cuenta y la quiere recuperar haga click              
            <asp:LinkButton style="color:orangered" ID="lbRecuperarCuenta" OnClick="lbRecuperarCuenta_Click" runat="server"><b>aquí</b></asp:LinkButton>   
        </h6>
    </div>
</form>
</div>    
</body>
</html>
