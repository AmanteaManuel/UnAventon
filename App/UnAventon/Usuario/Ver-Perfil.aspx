<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ver-Perfil.aspx.cs" Inherits="UnAventon.Usuario.Ver_Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    

<div class="container margin-general">
    <div class="row">
        <div class="col-md-10 col-lg-10">
            <h3 class="panel-title"><strong>Mi Perfil</strong></h3>    
            <p><label>En esta página podrá ver el detalles de su perfil, administrar sus vehículos y ver sus postulaciones a viajes.</label></p>
        </div>
        <div class="col-md-2 col-lg-2 center">     
            <br />
             <strong>Eliminar Cuenta</strong>    
            <asp:LinkButton ID="lbeliminarCuenta" CssClass="DeleteButton" runat="server" Text="Eliminar" OnClick="lbeliminarCuenta_Click" OnClientClick="return confirm('¿Esta seguro que desea eliminar la cuenta?');" />
        </div>
    </div>    
	<div class="row">
		<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
			<div class="panel panel-info">
				<div class="panel-heading">			
                    <h3 class="panel-title"><strong>Perfil</strong></h3>
				</div>
				<div class="panel-body">
					<div class="row">						
							<div class="col-md-9 col-lg-9 ">
                                <div class="table-responsive">
								    <table class="table table-user-information">
									    <tbody>
										    <tr>
											    <td><strong>Nombre:</strong></td>
											    <td><asp:Literal runat="server" ID="liNombre" /></td>
										    </tr>
										    <tr>
											    <td><strong>Apellido:</strong></td>
											    <td><asp:Literal runat="server" ID="liApellido" /></td>
										    </tr>
										    <tr>
											    <td><strong>DNI:</strong></td>
											    <td><asp:Literal runat="server" ID="liDni" /></td>
										    </tr>
                                            <tr>
											    <td><strong>Fecha Nacimiento:</strong></td>
											    <td><asp:Literal runat="server" ID="liFechaNacimiento" /></td>
										    </tr>
										    <tr>
											    <td><strong>Email:</strong></td>
											    <td><asp:Literal runat="server" ID="liEmail" /></td>
										    </tr>
										    <tr>
											    <td><strong>Reputacion como Chofer:</strong></td>
											    <td><asp:Literal runat="server" ID="liReputacionChofer" /></td>
										    </tr>
										    <tr>
											    <td><strong>Reputacion como Pasajero:</strong></td>
											    <td><asp:Literal runat="server" ID="liReputacionPasajero" /></td>
										    </tr>
									    </tbody>
								        </table>
                                    </div>
                                <hr/>
							</div>

                        <%--<div class="col-md-3 col-lg-3 " align="center"></div>--%>
						</div>
					</div>            
				</div>
			</div>
		
		<div class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xs-offset-0 col-sm-offset-0 col-md-offset-3 col-lg-offset-3 toppad" >
			<div class="panel panel-info">
				<div class="panel-heading">
					<h3 class="panel-title"><strong>Mis vehiculos</strong></h3>
				</div>
				<div class="panel-body">
					<div class="row">	
                         <div class="table-responsive-vehiculo">
							<div class=" col-md-12 col-lg-12">                                
                                    <table class="table table-hover">
                                        <asp:Repeater runat="server" ID="rptVehiculos" OnItemCommand="rptVehiculos_ItemCommand" OnItemDataBound="rptVehiculos_ItemDataBound">
                                            <HeaderTemplate>
                                                <tr>
                                                    <th>Marca</th>
                                                    <th>Modelo</th>
                                                    <th>Patente</th>
                                                    <th>Color</th>
                                                    <th>Asientos</th>
                                                    <th>Eliminar</th>
                                                    <th>Modificar</th>
                                                    <th>Activo</th>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Literal Text='<%# Eval("Marca") %>' runat="server" /></td>
                                                    <td>
                                                        <asp:Literal Text='<%# Eval("Modelo") %>' runat="server" /></td>
                                                    <td>
                                                        <asp:Literal Text='<%# Eval("Patente") %>' runat="server" /></td>
                                                    <td>
                                                        <asp:Literal Text='<%# Eval("Color") %>' runat="server" /></td>
                                                    <td>
                                                        <asp:Literal Text='<%# Eval("AsientosDisponibles") %>' runat="server" /></td>
                                                    <td>
                                                        <asp:LinkButton CssClass="DeleteButton" ID="linkDetalle" CommandName="DELETE" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Eliminar" OnClientClick="return confirm('¿Desea eliminar el vehículo?');"></asp:LinkButton></td>
                                                    <td>
                                                        <asp:LinkButton CssClass="UpdateButton" ID="LinkButton1" CommandName="UPDATE" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Modificar"></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <strong ><asp:Label runat="server" id="liEstadoVehiculo" /></strong>                                                
                                                    </td> 
                                                    <%--<asp:Button  runat="server" ID="btnBorraVehiculo" OnClick="btnBorraVehiculo_Click" Text="X"/>   --%>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
						    </div>
                        <div class="col-md-3 col-lg-3"></div>
					</div>            
				</div>
			</div>
		</div>
        </div>    
   

    <div>
        <!-- Aca empieza la lista de Postulaciones-->
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 ">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><strong>Mis postulaciones</strong></h3>
                </div>
                <div class="panel-body">
                    <div class="row ">
                        <div class="table-responsive-vehiculo">
                            <%--<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 ">--%>
                                <table class="table table-hover">
                                    <asp:Repeater runat="server" ID="rptPostulaciones" OnItemDataBound="rptPostulaciones_ItemDataBound" OnItemCommand="rptPostulaciones_ItemCommand">
                                        <HeaderTemplate>
                                            <tr>
                                                <th>Origen</th>
                                                <th>Destino</th>
                                                <th>Fecha</th>
                                                <th>Hora</th>
                                                <th>Estado</th>
                                                <th>Detalle</th>
                                                <th>Datos de Contacto</th>
                                                <th>Baja del viaje</th>
                                                <th>Calificar Chofer</th>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td><asp:Literal Text='<%# Eval("Origen.Descripcion") %>' runat="server"/></td>
                                                <td><asp:Literal Text='<%# Eval("Destino.Descripcion") %>' runat="server"/></td>                                       
                                                <td><asp:Literal Text='<%# Eval("ShortDate") %>' runat="server"/></td>                   
                                                <td><asp:Literal Text='<%# Eval("HoraSalida") %>' runat="server"/></td>                                                
                                                <td>
                                                    <strong ><asp:Label runat="server" id="liEstado" /></strong>                                                
                                                </td> 
                                                <td>
                                                    <asp:LinkButton ID="lbDetalle" CssClass="links" CommandName="DETALLE" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Ver Detalle"></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="lbDatos" CssClass="UpdateButton" CommandName="DATOS" CommandArgument='<%# Eval("id") %>' runat="server" Text="Contacto Chofer"></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="lbBaja" CssClass="DeleteButton" CommandName="BAJA" CommandArgument='<%# Eval("id") %>' runat="server" Text="Darme de Baja" OnClientClick="return confirm('¿Desea darse de baja? Si ya fue aceptado usted será penalizado.');"></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton CssClass="UpdateButton" CommandName="CALIFICACION" CommandArgument='<%#Eval("Id") %>' runat="server" Text="Calificar" ID="lbCalifiacion"></asp:LinkButton>  
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            <%--</div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Aca termina la lista de Postulaciones-->
     <div class="row" id="divDatosChofer" runat="server">
        <div class="alert alert-success" role="alert">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <div class="center"><label><strong>Datos del Chofer</strong></label></div> <br>                       
            <label><strong>Email: </strong></label> <asp:Literal runat="server" ID="liEmail1" /><br>   
            <label><strong>Nombre: </strong></label><asp:Literal runat="server" ID="liNombre1" /><br>   
            <label><strong>Apellido: </strong></label><asp:Literal runat="server" ID="liApellido1" /><br>  
            <label><strong>Reputacion: </strong></label><asp:Literal runat="server" ID="liReputacion1"/>
        </div>
     </div>

    
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Calificar Chofer</h5>
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
              <input type="radio" runat="server" id="radioCalificacionBuena" name="Calficiacion"/>
              <label for="message-text" class="col-form-label">Mala</label>
              <input runat="server" id="radioCalificacionMala" type="radio" name="Calficiacion"/>                   
          </div>
          <div class="form-group">
            <label for="message-text" class="col-form-label">Comentario:</label>
            <asp:TextBox runat="server" class="form-control" id="tbmessage"/> 
        </form>
      </div>
      <div class="modal-footer">
        <asp:Button type="button" class="btn btn-secondary" data-dismiss="modal" Text="Cancelar" runat="server" />
        <asp:Button Text="Aceptar" type="button" class="btn btn-primary" runat="server" ID="btnAceptarComentario" OnClick="btnAceptarComentario_Click" />        
      </div>
    </div>
  </div>
</div>

</div>
     <script>

        function Calificacion()
        {
           <%-- alert($('#<%= tbHiddenId.ClientID %>').val());--%>
            $("#exampleModal").modal("show")
            //--data-target = "#exampleModal1"
        }


    </script>
</asp:Content>
