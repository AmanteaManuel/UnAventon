<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ver-Perfil.aspx.cs" Inherits="UnAventon.Usuario.Ver_Perfil" %>
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
							<div class=" col-md-9 col-lg-9 "> 
								<table class="table table-user-information">
									<tbody>
										<tr>
											<td><strong>Nombre:</strong></td>
											<td>NombreUsuario</td>
										</tr>
										<tr>
											<td><strong>Apellido:</strong></td>
											<td>ApellidoUsuario</td>
										</tr>
										<tr>
											<td><strong>DNI</strong></td>
											<td>DNIUsuario</td>
										</tr>
										<tr>
											<td><strong>Email</strong></td>
											<td>EmailUsuario</td>
										</tr>
										<tr>
											<td><strong>Reputacion como Chofer</strong></td>
											<td>Porcentaje</td>
										</tr>
										<tr>
											<td><strong>Reputacion como Pasajero</strong></td>
											<td>Porcentaje</td>
										</tr>                     
									</tbody>
								</table>
								<a href="#" class="btn btn-primary">Mis Vehiculos</a>
							</div>
						</div>
					</div>            
				</div>
			</div>
		</div>
    </div>
</body>
</asp:Content>
