﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ver-Viaje.aspx.cs" Inherits="UnAventon.Viajes.Ver_Viaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
        <div class="container margin-general">
            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xs-offset-0 col-sm-offset-0 col-md-offset-3 col-lg-offset-3 toppad">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title">Detalles del viaje</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class=" col-md-9 col-lg-9 ">
                                    <div class="table-responsive">
                                    <table class="table table-user-information">
                                        <tbody>
                                            <tr>
                                                <td><strong>Ciudad Origen:</strong></td>
                                                <td>
                                                    <asp:Literal Text="text" runat="server" ID="liCudadOrigen" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><strong>Ciudad Destino:</strong></td>
                                                <td>
                                                    <asp:Literal Text="text" runat="server" id="liCiudadDestino"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><strong>Duracion:</strong></td>
                                                <td>
                                                    <asp:Literal Text="text" runat="server" id="liDuracion"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><strong>Precio:</strong></td>
                                                <td>
                                                    <asp:Literal Text="text" runat="server" id="liPrecio"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><strong>Fecha:</strong></td>
                                                <td>
                                                    <asp:Literal Text="text" runat="server" id="liFecha"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><strong>Hora:</strong></td>
                                                <td>
                                                    <asp:Literal Text="text" runat="server" id="liHora"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><strong>Lugares Disponibles:</strong></td>
                                                <td>
                                                    <asp:Literal Text="text" runat="server" id="liLugares"/>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td><strong>Reputacion Chofer:</strong></td>
                                                <td>
                                                    <asp:Literal Text="text" runat="server" id="liReputacionChofer"/>
                                                </td>
                                            </tr>--%>
                                        </tbody>
                                    </table>
                                    </div>
                                </div>
                                <div class="col-md-3 col-lg-3" id="divDescripcion" runat="server" visible=" true">
                                    <div class="form-group">
                                        <label><strong>Comentario:</strong></label>
                                        <asp:TextBox runat="server" ID="tbComentario" TextMode="MultiLine" Enabled="false" Height="150px" Width="500" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <!-- Lista de postulantes-->
    <div class="row">    
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xs-offset-0 col-sm-offset-0 col-md-offset-3 col-lg-offset-3 toppad">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><strong>Postulantes</strong></h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="table-responsive-vehiculo">
                            <div class=" col-md-9 col-lg-9 ">
                                <table class="table table-hover">
                                    <asp:Repeater runat="server" ID="rptListaPostulantes" OnItemCommand="rptListaPostulantes_ItemCommand" OnItemDataBound="rptListaPostulantes_ItemDataBound" >
                                        <HeaderTemplate>
                                            <tr>
                                                <th>Nombre</th>
                                                <th>Apellido</th>
                                                <th>Reputacion</th>
                                                <div id="divAccionesPostulacioncol" visible="false" runat="server">
                                                    <th>Aceptar</th>
                                                    <th>Rechazar</th>
                                                </div>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Literal Text='<%# Eval("Nombre") %>' runat="server" />                                                
                                                </td>

                                                <td>
                                                    <asp:Literal Text='<%# Eval("Apellido") %>' runat="server" />                                                
                                                </td>

                                                <td>
                                                    <asp:Literal Text='<%# Eval("ReputacioPasajero") %>' runat="server" />                                               
                                                </td>
                                                <div id="divAccionesPostulacionbtn" visible="false" runat="server">
                                                    <td>
                                                        <asp:LinkButton CssClass="UpdateButton" CommandName="ACEPTAR" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Aceptar"></asp:LinkButton>                                                
                                                    </td>

                                                    <td>
                                                        <asp:LinkButton CssClass="DeleteButton" CommandName="RECHAZAR" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Rechazar"></asp:LinkButton>
                                                    </td>
                                                </div>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>    
    </div>
    <!-- FIN Lista de postulantes-->
</asp:Content>
