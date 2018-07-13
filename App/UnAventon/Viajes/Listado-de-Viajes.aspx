<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Listado-de-Viajes.aspx.cs" Inherits="UnAventon.Viajes.Listado_de_Viajes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<div id="global" class="margin-general">   
    <div class="row">
        <div class="col-sm-6 col-lg-6">
            <h3><strong>
                <label>Listado de Viajes</label></strong></h3>
            <p>
                <label>En esta página podrá ver el listado de todos los viajes.</label></p>
        </div>
        <div class="col-sm-6 col-lg-6">
            <asp:UpdatePanel runat="server" ID="upBusqueda" UpdateMode="Conditional">
                <ContentTemplate>
                    <strong>Provincia Salida</strong>
                    <asp:DropDownList ID="ddlProvSalida" OnSelectedIndexChanged="ddlProvSalida_SelectedIndexChanged" runat="server" CssClass="roundedCorner" AutoPostBack="true">
                    </asp:DropDownList>

                    <strong>Ciudad Salida</strong>
                    <asp:DropDownList runat="server" ID="ddlCiudadSalida" CssClass="roundedCorner">
                    </asp:DropDownList><br />

                    <br />

                    <strong>Provincia Destino</strong>
                    <asp:DropDownList runat="server" ID="ddlProvDestino" OnSelectedIndexChanged="ddlProvDestino_SelectedIndexChanged" CssClass="roundedCorner" AutoPostBack="true">
                    </asp:DropDownList>

                    <strong>Ciudad Destino</strong>
                    <asp:DropDownList runat="server" ID="ddlCiudadDestino" CssClass="roundedCorner">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button Text="Buscar" CssClass="links" ID="btnBuscar" OnClick="btnBuscar_Click1" runat="server" />
        </div>
    </div>
    </div>
        
    <div class="row">
        <div class="col-sm-12 col-lg-12">
           <div class="panel panel-default">        
        <div class="table-responsive">
            <table class="table table-hover">               
                <tbody>
                    <asp:Repeater runat="server" ID="rptViajes" OnItemCommand="rptViajes_ItemCommand">
                        <HeaderTemplate>
                            <tr>
                                <th>Origen</th>
                                <th>Destino</th>
                                <th>Precio</th>
                                <th>Fecha</th>
                                <th>Hora</th>
                                <th>Lugares Disponibles</th>
                                <th>Detalle</th>
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
                                    $<asp:Literal Text='<%# Eval("Precio") %>' runat="server" ID="liPrecio" />
                                </td>
                                <td>
                                    <asp:Literal Text='<%# Eval("ShortDate") %>' runat="server" ID="liFecha" />
                                </td>
                                <td>
                                    <asp:Literal Text='<%# Eval("HoraSalida") %>' runat="server" ID="liHora" />
                                </td>
                                <td align="left">
                                    <asp:Literal Text='<%# Eval("LugaresDisponibles") %>' runat="server" ID="liUsuario" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbDetalle" CssClass="links" CommandName="DETALLE" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Ver Detalle"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </tbody>
            </table>
        </div>
    </div>
            </div>
     </div>
</div>
</asp:Content>
