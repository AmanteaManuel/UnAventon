<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UnAventon.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title> Home </title>   
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
    </style>

</head>
<body >
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
                <asp:LinkButton style="color:orangered" href="/Viajes/Listado-de-Viajes.aspx" runat="server"><b>continuar como invitado</b></asp:LinkButton>   
        </h4>
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
                                        <asp:CustomValidator ErrorMessage="errormessage" ControlToValidate="tbEmail" ID="cvEmail" ValidationGroup="GroupLogin" runat="server" OnServerValidate="cvEmail_ServerValidate" />
                                    </div>
                                    <div class="form-group" runat="server">
                                        <asp:TextBox runat="server" type="password" id="tbPassword" class="form-control" placeholder="Contraseña"/>     
                                        <asp:CustomValidator ErrorMessage="errormessage" ControlToValidate="tbPassword" ID="cvPassword" runat="server" ValidationGroup="GroupLogin" OnServerValidate="cvPassword_ServerValidate" />
                                    </div>                                   
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-sm-6 col-sm-offset-3">
                                                <asp:LinkButton Text="Iniciar Sesion" class="form-control btn btn-login align-center" runat="server" tabindex="4" id="idInciarSesion" OnClick="idInciarSesion_Click" />
                                            </div>
                                            <div class="col-sm-6 col-sm-offset-3">
                                                <asp:LinkButton Text="Registrar" runat="server" class="form-control btn btn-login" tabindex="4" ID="btnRegistrar" OnClick="btnRegistrar_Click" />
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
    </div>
</form>
</body>
</html>
