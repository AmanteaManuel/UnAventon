<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Listado-de-Viajes.aspx.cs" Inherits="UnAventon.Viajes.Listado_de_Viajes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default panel-container-dnst">
        <div class="panel-body listadoUsuarios">

            <!-- fila que dice los campos a listar-->
            <div class="row">
                <div class="col-xs-12 col-md-12 col-lg-12">
                    <ul id="ulHeader" class="" runat="server">
                        <li class="">
                            <div class="col-sm-4 header">
                                <span>Origen</span>
                            </div>
                            <div class="col-sm-2 columna1">
                                <span>Destino</span>
                            </div>
                            <div class="col-sm-2 columna2">
                                <span>Precio</span>
                            </div>
                            <div class="col-sm-2 columna3">
                                <span>Fecha</span>
                            </div>
                            <div class="col-sm-2">
                                <span>Usuario</span>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <%--<--!EMPYTY STATE-->--%>
            <div class="row">
                <div class="col-xs-12 col-md-12 col-lg-12">
                    <ul class="">
                        <li id="liEmptyState" visible="false" runat="server">
                            <div class="">
                                <i class="zmdi zmdi-info-outline"></i>
                                <span>No Se encontraron resultados</span>
                            </div>
                        </li>

                        <%--<--!DATOS QUE SE VAN A REPETIR(VIAJES)-->--%>
                        <asp:Repeater runat="server" ID="rptViajes">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlDetallViaje" runat="server">
                                    <li class="">
                                        <div class="col-sm-1">
                                            <asp:Image src="../img/car.png" CssClass="img-circle" runat="server" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Literal ID="liOrigen" Text="Texto de Prueba" runat="server" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Literal ID="liDestino" Text="Texto de Prueba" runat="server" />
                                        </div>
                                        <div class="col-sm-1">
                                            <asp:Literal ID="liPrecio" Text="Texto de Prueba" runat="server" />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Literal ID="liFecha" Text="Texto de Prueba" runat="server" />
                                        </div>
                                        <div class="col-sm-2">
                                            <span>
                                                <asp:Literal ID="liNombreUsuario" Text="Texto de Prueba" runat="server" />
                                                <asp:Literal ID="liReputacion" Text="Texto de Prueba" runat="server" />
                                            </span>
                                        </div>
                                    </li>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
