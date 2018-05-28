<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Listado-de-Viajes.aspx.cs" Inherits="UnAventon.Viajes.Listado_de_Viajes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table-responsive">
<table class="table table-hover" >

    <thead class="silver-background">
        &nbsp
        <br width=55%>
        
    </thead>
    <tbody>
        <asp:Repeater runat="server" ID="rptViajes" >
            <HeaderTemplate >
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
                    <asp:LinkButton runat="server" id="lbDetalle">
                    <td>
                        <asp:Literal Text='<%# Eval("Origen.Descripcion") %>' runat="server" ID="liOrigen" />
                    </td>                  
                    <td>
                        <asp:Literal Text='<%# Eval("Destino.Descripcion") %>' runat="server" ID="liDestino"/>
                    </td>
                    <td>
                        <asp:Literal Text='<%# Eval("Precio") %>' runat="server" ID="liPrecio"/>
                    </td>                 
                    <td>                  
                        <asp:Literal Text='<%# Eval("FechaSalida") %>' runat="server" ID="liFecha"/>
                    </td>                
                    <td>                  
                        <asp:Literal Text='<%# Eval("HoraSalida") %>' runat="server" ID="liHora"/>
                    </td>                 
                    <td>                  
                        <asp:Literal Text='<%# Eval("LugaresDisponibles") %>' runat="server" ID="liUsuario"/>
                    </td>
                    </asp:LinkButton>
                </tr> 
            </ItemTemplate>
        </asp:Repeater>        
    </tbody>
</table>
</div>
</asp:Content>
