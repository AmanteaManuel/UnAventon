<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ver-Viaje.aspx.cs" Inherits="UnAventon.Viajes.Ver_Viaje" %>
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
   <asp:Button Text="Eliminar" runat="server" ID="btnEliminarViaje" CssClass="boton_personalizado" OnClick="btnEliminarViaje_Click" />

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
                                                <div id="divAccionesPostulacioncol" runat="server">
                                                    <th>Aceptar</th>
                                                    <th>Rechazar</th>
                                                    <th>Eliminar</th>
                                                    <th>Datos</th>
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
                                                <div id="divAccionesPostulacionbtn" runat="server">
                                                    <td>
                                                        <asp:LinkButton CssClass="UpdateButton" CommandName="ACEPTAR" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Aceptar" ID="lbAceptar"></asp:LinkButton>                                                
                                                    </td>

                                                    <td>
                                                        <asp:LinkButton CssClass="DeleteButton" CommandName="RECHAZAR" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Rechazar" ID="lbRechazar"></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton CssClass="DeleteButton" CommandName="ELIMINAR" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Eliminar" ID="lbEliminar"></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton CssClass="UpdateButton" CommandName="DATOS" CommandArgument='<%#Eval("Id") %>' runat="server" Text="Datos" ID="lbDatos"></asp:LinkButton>
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
     <div class="row" id="divDatosUsuario" runat="server">
                    <div class="alert alert-success" role="alert">
                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                       <label><strong>Email: </strong></label> <asp:Literal runat="server" ID="liEmail" /><br>
                        <label><strong>Nombre: </strong></label><asp:Literal runat="server" ID="liNombre" /><br>
                        <label><strong>Apellido: </strong></label><asp:Literal runat="server" ID="liApellido" /><br>
                        <label><strong>Reputacion: </strong></label><asp:Literal runat="server" ID="liReputacion"/>
                    </div>
     </div>
</asp:Content>
