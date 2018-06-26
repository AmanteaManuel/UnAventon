<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ver-Perfil.aspx.cs" Inherits="UnAventon.Usuario.Ver_Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    

<div class="container margin-general">
    <h3 class="panel-title"><strong>Mi Perfil</strong></h3>
    <p><label>En esta página podrá ver el detalles de su perfil, administrar sus vehículos y ver sus postulaciones a viajes.</label></p>
	<div class="row">
		<div class="col-xs-12 col-sm-12 col-md-6 col-lg- " >
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
                                        <asp:Repeater runat="server" ID="rptVehiculos" OnItemCommand="rptVehiculos_ItemCommand">
                                            <HeaderTemplate>
                                                <tr>
                                                    <th>Marca</th>
                                                    <th>Modelo</th>
                                                    <th>Patente</th>
                                                    <th>Color</th>
                                                    <th>Asientos</th>
                                                    <th>Eliminar</th>
                                                    <th>Modificar</th>
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
                                                        <asp:LinkButton CssClass="UpdateButton" ID="LinkButton1" CommandName="UPDATE" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Modificar"></asp:LinkButton></td>
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
                                                    <asp:LinkButton ID="lbBaja" CssClass="DeleteButton" CommandName="BAJA" CommandArgument='<%# Eval("id") %>' runat="server" Text="Darme de Baja"></asp:LinkButton>
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
</div>
</asp:Content>
