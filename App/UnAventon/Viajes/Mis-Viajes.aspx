<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mis-Viajes.aspx.cs" Inherits="UnAventon.Viajes.Mis_Viajes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
    <div id="global" class="margin-general">
        <div>
            <h3><strong>
                <label>Mis Viajes</label></strong></h3>
            <p>
                <label>En esta página podrá ver el listado de todos sus viajes.</label></p>
        </div>
        <div class="row">
            <div class="col-sm-12 col-lg-12">
                <div class="panel panel-default">
                    <div class="table-responsive">
                        <table class="table table-hover">
                            <tbody>
                                <asp:Repeater runat="server" ID="rptMisViajes" OnItemCommand="rptViajes_ItemCommand" OnItemDataBound="rptMisViajes_ItemDataBound">
                                    <HeaderTemplate>
                                        <tr>
                                            <th>Origen</th>
                                            <th>Destino</th>
                                            <th>Precio</th>
                                            <th>Fecha</th>
                                            <th>Hora</th>
                                            <th>Lugares Disponibles</th>
                                            <th>Detalle</th>
                                            <th>Pagado</th>
                                            <th>Calificado</th>
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
                                            <td>$<asp:Literal Text='<%# Eval("Precio") %>' runat="server" ID="liPrecio" />
                                            </td>
                                            <td>
                                                <asp:Literal Text='<%# Eval("ShortDate") %>' runat="server" ID="liFecha" />
                                            </td>
                                            <td>
                                                <asp:Literal Text='<%# Eval("HoraSalida") %>' runat="server" ID="liHora" />
                                            </td>
                                            <td>
                                                <asp:Literal Text='<%# Eval("LugaresDisponibles") %>' runat="server" ID="liUsuario" />
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lbDetalle" CssClass="links" CommandName="DETALLE" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Ver Detalle"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <strong><asp:Label runat="server" ID="lbSiPagado"></asp:Label></strong>
                                            </td>
                                            <td>
                                                <strong><asp:Label runat="server" ID="lbSiCalificado"></asp:Label></strong>
                                            </td>
                                            
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="col-sm-12 col-lg-12">
                <div class="panel panel-default">
                    <div class="table-responsive">
                        <table class="table table-hover">
                            <tbody>
                                <asp:Repeater runat="server" ID="ViajesParticipados" OnItemCommand="rptViajes_ItemCommand">
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
                                            <td>$<asp:Literal Text='<%# Eval("Precio") %>' runat="server" ID="liPrecio" />
                                            </td>
                                            <td>
                                                <asp:Literal Text='<%# Eval("ShortDate") %>' runat="server" ID="liFecha" />
                                            </td>
                                            <td>
                                                <asp:Literal Text='<%# Eval("HoraSalida") %>' runat="server" ID="liHora" />
                                            </td>
                                            <td>
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
