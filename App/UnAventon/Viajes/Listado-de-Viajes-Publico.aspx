<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listado-de-Viajes-Publico.aspx.cs" Inherits="UnAventon.Viajes.Listado_de_Viajes_Publico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio</title>

    <link rel="stylesheet" href="<%=Page.ResolveUrl("~/Content/bootstrap.css") %>">
    <link rel="stylesheet" href="<%=Page.ResolveUrl("~/Scripts/aMainCss.css") %>">
    <script src="<%=Page.ResolveUrl("~/Scripts/jquery-3.3.1.js") %>"></script>
    <script src="<%=Page.ResolveUrl("~/Scripts/bootstrap.js") %>"></script>

    <style>
      body {
           background-image: url('<%=Page.ResolveUrl("~/img/FondoMaster.jpg") %>');
            background-position: center center;
            backgroun-repeat: no-repeat;
            background-attachment: fixed;
            background-size: cover;
            background-color: #464646;
            height: 100%;
            width: 100%;

            
        }        

        .Transparent-background {
            background-color: rgba(0,0,0,0.0);
        }
        
        .links{
            font-family: impact;
            color: #D9D9D9 !important;
            font-size: 15px;
            box-shadow: 0px 0px 10px #9E4B4D;
            padding: 7px 25px;
            -moz-border-radius: 15px;
            -webkit-border-radius: 15px;
            border-radius: 15px;
            border: 2px solid #000000;
            background: #F17376;
            background: linear-gradient(top,  #F17376,  #AD5355);
            background: -ms-linear-gradient(top,  #F17376,  #AD5355);
            background: -webkit-gradient(linear, left top, left bottom, from(#F17376), to(#AD5355));
            background: -moz-linear-gradient(top,  #F17376,  #AD5355);
        }
        .links:hover{
            color: #FFFFFF !important;
            background: #468CCF;
            background: linear-gradient(top,  #99494B,  #CF6265);
            background: -ms-linear-gradient(top,  #99494B,  #CF6265);
            background: -webkit-gradient(linear, left top, left bottom, from(#99494B), to(#CF6265));
            background: -moz-linear-gradient(top,  #99494B,  #CF6265);
        }
    </style>    
</head>

<form id="form1" runat="server">   
    <asp:scriptmanager runat="server" asyncpostbacktimeout="999" />
        <div>
            <img style="margin-left: 5%" src="<%=Page.ResolveUrl("~/img/Logo.png")%>" height="5%" width="5%" alt="Logo Un Aventón" />
        </div>
    <br/>        
</form>
<body runat="server">    
    </div>
    <div class="table-responsive">
        <table class="table table-hover">
            <thead class="silver-background">
                &nbsp
                <br width="55%" />
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="rptViajes">
                    <HeaderTemplate>
                        <tr>
                            <th>Origen</th>
                            <th>Destino</th>
                            <th>Precio</th>
                            <th>Fecha</th>
                            <th>Hora</th>
                            <th>Lugares Disponibles</th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Literal Text='<%# Eval("Origen.Descripcion") %>' runat="server" ID="liOrigen" />
                            </td>
                            <td>
                                <asp:Literal Text='<%# Eval("Destino.Descripcion") %>' runat="server" ID="liDestino" />
                            </td>
                            <td>
                                <asp:Literal Text='<%# Eval("Precio") %>' runat="server" ID="liPrecio" />
                            </td>
                            <td>
                                <asp:Literal Text='<%# Eval("FechaSalida") %>' runat="server" ID="liFecha" />
                            </td>
                            <td>
                                <asp:Literal Text='<%# Eval("HoraSalida") %>' runat="server" ID="liHora" />
                            </td>
                            <td>
                                <asp:Literal Text='<%# Eval("LugaresDisponibles") %>' runat="server" ID="liUsuario" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</body>   
</html>
