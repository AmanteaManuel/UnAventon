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
                                                    <asp:Literal Text="text" runat="server" id="liDuracion"/>Horas
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><strong>Precio:</strong></td>
                                                <td>
                                                    $<asp:Literal Text="text" runat="server" id="liPrecio"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><strong>Precio Total:</strong></td>
                                                <td>
                                                    $<asp:Literal runat="server" id="liPrecioTotal"/>
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
                                                <td><strong>Auto:</strong></td>
                                                <td>
                                                    <asp:Literal runat="server" id="liAuto"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><strong>Lugares Totales:</strong></td>
                                                <td>
                                                    <asp:Literal runat="server" id="liLugares"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><strong>Lugares Disponibles:</strong></td>
                                                <td>
                                                    <asp:Literal runat="server" id="liLugaresDisponibles"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><strong>Estado del viaje:</strong></td>
                                                <td>
                                                    <strong><asp:label runat="server" id="liEstadoDelViaje"/></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><strong>Viaje Pagado:</strong></td>
                                                <td>
                                                    <strong><asp:label runat="server" id="liPagado"/></strong>
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
        <asp:Button Text="Eliminar" runat="server" ID="btnEliminarViaje" CssClass="boton_personalizado" OnClick="btnEliminarViaje_Click" OnClientClick="return confirm('¿Desea eliminar el viaje?, si el viaje posee pasajeros será penalizado.');" />
        <asp:Button Text="Modificar" runat="server" ID="btnModificar" CssClass="boton_personalizado" OnClick="btnModificar_Click" />
        <asp:Button id="btnPagar" runat="server" Text="Pagar" CssClass="boton_personalizado" OnClick="btnPagar_Click1" />               
        <asp:Button Text="Postularse" runat="server" ID="btnPostularse" CssClass="boton_personalizado" OnClick="btnPostularse_Click" OnClientClick="return confirm('¿Desea postularse al viaje?');" />        
        <div id="divEstadoPostulacion" class="Estado" runat="server">
            <h4><asp:Label runat="server" id="liEstado" /></h4>      
        </div>

    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upGeneral">
        <ContentTemplate>
    <!-- Lista de postulantes-->
    <div class="row" id="divPostulacion" runat="server">    
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
                                                <%--<div id="divAccionesPostulacioncol" runat="server">--%>
                                                    <th>Aceptar</th>
                                                    <th>Rechazar</th>
                                                    <th>Eliminar</th>
                                                    <th>Datos</th>
                                                    <th>Estado</th>
                                                    <th>Calificar Pasajero</th>
                                               <%-- </div>--%>
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
                                                <div>
                                                    <td>
                                                        <asp:LinkButton CssClass="UpdateButton" CommandName="ACEPTAR" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Aceptar" ID="lbAceptar"></asp:LinkButton>                                                
                                                    </td>

                                                    <td>
                                                        <asp:LinkButton CssClass="DeleteButton" CommandName="RECHAZAR" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Rechazar" ID="lbRechazar"></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton CssClass="DeleteButton" CommandName="ELIMINAR" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Eliminar" ID="lbEliminar" OnClientClick="return confirm('¿Desea eliminar el pasajero?,si el mismo está aceptado usted será penalizado.');"></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton CssClass="UpdateButton" CommandName="DATOS" CommandArgument='<%#Eval("Id") %>' runat="server" Text="Datos" ID="lbDatos"></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <strong ><asp:Label runat="server" id="liEstado" /></strong>                                                
                                                    </td>
                                                    <td>
                                                       <%-- data-target="#exampleModal"   data-toggle="modal" --%>
                                                        <asp:LinkButton CssClass="UpdateButton" CommandName="CALIFICACION" CommandArgument='<%#Eval("Id") %>' runat="server" Text="Calificar" ID="lbCalifiacion"></asp:LinkButton>                                                        
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
            <div class="center"><label><strong>Datos del Usuario</strong></label></div> <br>                       
            <label><strong>Email: </strong></label> <asp:Literal runat="server" ID="liEmail" /><br>
            <label><strong>Nombre: </strong></label><asp:Literal runat="server" ID="liNombre" /><br>
            <label><strong>Apellido: </strong></label><asp:Literal runat="server" ID="liApellido" /><br>
            <label><strong>Reputacion: </strong></label><asp:Literal runat="server" ID="liReputacion"/>
        </div>
     </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--SECCION DE PREGUNTAS--%>
    <br /><h3 class="panel-title">Preguntas</h3><br />    
    <div class="row">       
            <div class=" col-md-2 col-lg-2 "><asp:Panel runat="server" BackColor="Transparent"></asp:Panel></div>
                <div class=" col-md-8 col-lg-8">
                    <asp:Repeater runat="server" ID="rptPreguntas" OnItemCommand="rptPreguntas_ItemCommand" OnItemDataBound="rptPreguntas_ItemDataBound">
                        <ItemTemplate>
                            <div class="divPreguntas">
                                <strong><asp:Label ID="lbPregunta" CssClass="pregunta"  Text="Hola que tal tenes aire acondicionado?" runat="server" /></strong><br /><br />
                                <asp:Label ID="lbRespuesta" CssClass="respuesta" Text="Que te importa" runat="server" />
                            </div>
                            <asp:LinkButton CssClass="boton_personalizado" CommandName="RESPUESTA" CommandArgument='<%#Eval("Id")%>' runat="server" Text="Responder" ID="lbResponder"></asp:LinkButton>                                          
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            <div class=" col-md-2 col-lg-2 "></div>
    </div>
    <%--FIN SECCION DE PREGUNTAS--%>

    
    <%--MODAL CALIFICAR PASAJERO--%>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Calificar Pasajero</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form>

                        <div class="form-group">
                            <label for="recipient-name" class="col-form-label">Calificación:</label>
                            <br />
                            <label for="message-text" class="col-form-label">Buena</label>
                            <input type="radio" runat="server" id="radioCalificacionBuena" name="Calficiacion" />
                            <label for="message-text" class="col-form-label">Mala</label>
                            <input runat="server" id="radioCalificacionMala" type="radio" name="Calficiacion" />
                        </div>
                        <div class="form-group">
                            <label for="message-text" class="col-form-label">Comentario:</label>
                            <asp:TextBox runat="server" class="form-control" ID="tbmessage" />
                        </div>

                    </form>
                </div>
                <div class="modal-footer">
                    <asp:Button type="button" class="btn btn-secondary" data-dismiss="modal" Text="Cancelar" runat="server" />
                    <asp:Button Text="Aceptar" type="button" class="btn btn-primary" runat="server" ID="btnAceptarComentario" OnClick="btnAceptarComentario_Click" />
                </div>
            </div>
        </div>
    </div>
    <%--FIN MODAL CALIFICAR PASAJERO--%>
    
    <%--MODAL PAGAR VIAJE--%>
    <div class="modal fade" id="exampleModal1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel1">Pagar Viaje</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group">

                            <strong><label for="recipient-name" class="col-form-label">Datos de Tarjeta:</label></strong>
                            <br />

                            <label for="message-text" class="col-form-label">Nombre</label><br />
                            <asp:TextBox runat="server" id="tbNombreTarjeta" />
                            <asp:CustomValidator id="cvtbNombreTarjeta" runat="server" OnServerValidate="cvtbNombreTarjeta_ServerValidate" ValidationGroup="Pago" /><br />


                            <label for="message-text" class="col-form-label">Numero Tarjeta</label><br />
                            <asp:TextBox runat="server" id="tbNumeroTarjeta" MaxLength="16" />
                            <asp:CustomValidator  runat="server" ID="cvNumeroTarjeta"  OnServerValidate="cvNumeroTarjeta_ServerValidate" ValidationGroup="Pago" /><br />

                            <label for="message-text" class="col-form-label" runat="server" >Banco</label><br />
                            <asp:DropDownList runat="server" id="ddlBanco">
                                <asp:ListItem Text="Seleccione" />
                                <asp:ListItem Text="Visa" />
                                <asp:ListItem Text="Master Card" />
                                <asp:ListItem Text="Banco Provincia" />
                                <asp:ListItem Text="ICBC" />
                                <asp:ListItem Text="Banco Nacion" />
                                <asp:ListItem Text="HSBC" />                                
                            </asp:DropDownList><br />
                            <asp:CustomValidator  ID="cvddlBanco" runat="server" OnServerValidate="cvddlBanco_ServerValidate" ValidationGroup="Pago" />  <br />

                            <label for="message-text" class="col-form-label">Fecha Vencimiento</label><br />
                            <asp:TextBox runat="server" id="tbFechaVencimiento" MaxLength="5" />
                            <asp:CustomValidator ID="cvtbFechaVencimiento" runat="server" OnServerValidate="cvtbFechaVencimiento_ServerValidate" ValidationGroup="Pago" /><br />

                            <label for="message-text" class="col-form-label">Codigo</label><br />
                            <asp:TextBox runat="server" id="tbCodigoSeguridad" MaxLength="3" />
                            <asp:CustomValidator ID="cvtbCodigoSeguridad" runat="server" OnServerValidate="cvtbCodigoSeguridad_ServerValidate" ValidationGroup="Pago" /><br />

                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <asp:Button type="button" class="btn btn-secondary" data-dismiss="modal" Text="Cancelar" runat="server" />
                    <asp:Button Text="Pagar" type="button" class="btn btn-primary" runat="server" ID="Button1" OnClick="btnPagar_Click" />
                </div>
            </div>
        </div>
    </div>
    <%--FIN MODAL CALIFICAR PASAJERO--%>

    <asp:TextBox ID="tbHiddenId" style="display:none" runat="server" />
</div>
     <script>
        function Pago()
        {
            <%-- alert($('#<%= tbHiddenId.ClientID %>').val());--%>
            $("#exampleModal1").modal("show")
            //--data-target = "#exampleModal1"
        }

        function Calificacion()
        {
            <%-- alert($('#<%= tbHiddenId.ClientID %>').val());--%>
            $("#exampleModal").modal("show")
            //--data-target = "#exampleModal1"
        }
    </script>
</asp:Content>
