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
        <asp:Repeater runat="server" ID="rptViajes" OnItemDataBound="rptViajes_ItemDataBound">
            <HeaderTemplate >
                <tr>            
                    <th>Origen</th>
                    <th>Destino</th>
                    <th>Precio</th>
                    <th>Fecha</th>
                    <th>Hora</th>
                    <th>Usuario</th>            
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Literal Text="text" runat="server" />
                    </td>                  
                    <td>
                        <asp:Literal Text="text" runat="server" />
                    </td>
                    <td>
                        <asp:Literal Text="text" runat="server" />
                    </td>
                    <td>
                        <asp:Literal Text="text" runat="server" />
                    </td>
                    <td>
                        <asp:Literal Text="text" runat="server" />
                    </td>
                    <td>
                        <asp:Literal Text="text" runat="server" />
                    </td>
                </tr> 
                <tr>
                    <td>Repeater</td>
                    <td>Repeater</td>
                    <td>Repeater</td>
                    <td>Repeater</td>
                    <td>Repeater</td>
                    <td>Repeater</td>
              </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td>Origen5</td>
            <td>Destino5</td>
            <td>Precio5</td>
            <td>Fecha5</td>
            <td>Hora5</td>
            <td>Usuario5</td>

      </tr>
        <tr>
            <td>Origen5</td>
            <td>Destino5</td>
            <td>Precio5</td>
            <td>Fecha5</td>
            <td>Hora5</td>
            <td>Usuario5</td>

      </tr>
    </tbody>
</table>
</div>
</asp:Content>
