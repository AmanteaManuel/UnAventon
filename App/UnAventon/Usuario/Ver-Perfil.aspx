﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ver-Perfil.aspx.cs" Inherits="UnAventon.Usuario.Ver_Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
<div class="container">
	<div class="row">
		<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xs-offset-0 col-sm-offset-0 col-md-offset-3 col-lg-offset-3 toppad" >
			<div class="panel panel-info">
				<div class="panel-heading">
					<h3 class="panel-title">Mi Perfil</h3>
				</div>
				<div class="panel-body">
					<div class="row">
						<div class="col-md-3 col-lg-3 " align="center"></div>
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
						</div>
					</div>            
				</div>
			</div>
		</div>
    <div class="row">
		<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xs-offset-0 col-sm-offset-0 col-md-offset-3 col-lg-offset-3 toppad" >
			<div class="panel panel-info">
				<div class="panel-heading">
					<h3 class="panel-title">Mis vehiculos</h3>
				</div>
				<div class="panel-body">
					<div class="row">
						<div class="col-md-3 col-lg-3 " align="center"></div>
							<div class=" col-md-9 col-lg-9 "> 
                                <div class="table-responsive-vehiculo">
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
                                                        <asp:LinkButton CssClass="DeleteButton" ID="linkDetalle" CommandName="DELETE" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Eliminar"></asp:LinkButton></td>
                                                    <td>
                                                        <asp:LinkButton CssClass="UpdateButton" ID="LinkButton1" CommandName="UPDATE" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Modificar"></asp:LinkButton></td>
                                                    <%--<asp:Button  runat="server" ID="btnBorraVehiculo" OnClick="btnBorraVehiculo_Click" Text="X"/>   --%>
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
    </div>
</body>
</asp:Content>
