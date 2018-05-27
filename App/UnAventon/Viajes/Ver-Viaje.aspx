<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ver-Viaje.aspx.cs" Inherits="UnAventon.Viajes.Ver_Viaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
<div class="container">
		<div class="row">
			<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xs-offset-0 col-sm-offset-0 col-md-offset-3 col-lg-offset-3 toppad" >
				<div class="panel panel-info">
					<div class="panel-heading">
						<h3 class="panel-title">Detalles del viaje</h3>
					</div>
					<div class="panel-body">
						<div class="row">
							<div class="col-md-3 col-lg-3 " align="left"></div>
								<div class=" col-md-9 col-lg-9 "> 
									<table class="table table-user-information">
										<tbody>
											<tr>
												<td><strong>Ciudad Origen:</strong></td>
												<td>Ciudad-Origen</td>
											</tr>
											<tr>
												<td><strong>Ciudad Destino:</strong></td>
												<td>Ciuda-Destino</td>
											</tr>
											<tr>
												<td><strong>Duracion:</strong></td>
												<td>Duracion del viaje</td>
											</tr>
											<tr>
												<td><strong>Fecha:</strong></td>
												<td>SI, aca va la fecha</td>
											</tr>
											<tr>
												<td><strong>Hora:</strong></td>
												<td>La hora</td>
											</tr>
											<tr>
												<td><strong>Lugares Disponibles:</strong></td>
												<td>Aca los lugares</td>
											</tr>   
											<tr>
												<td><strong>Reputacion Chofer:</strong></td>
												<td>Aca va la reputacion</td>
											</tr>  
										</tbody>
									</table>
								</div>
							</div>
						</div>            
					</div>
				</div>
			</div>
		</div>
		<div class="col-md-6">
			  			<div class="form-group">
			  				<label><strong> Descripcion:</strong></label>
			  			 	<input class="form-control" id="inputSeleccionado" type="text" value="Aca va la descripcion del viaje...">
			  			</div>
        </div>
	</div>
</div>
</body>
</asp:Content>
