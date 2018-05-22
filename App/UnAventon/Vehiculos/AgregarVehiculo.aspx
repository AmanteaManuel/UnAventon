<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarVehiculo.aspx.cs" Inherits="UnAventon.Vehiculos.AgregarVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="global">	
	<article>
		<section>				
		    <div> 
			    <div>
				    <div> 
					    <h3>Alta de vehiculo</h3>
					    <span class="required_notification">Datos requeridos</span> 
				    </div>
                    <br />  

                    <div  id="divMarca" class="form-group has-error help-block" runat="server"> 

					    <asp:TextBox runat="server" ID="tbMarca" PlaceHolder="Marca" Cssclass="form-control has-error" width="175"/>
                        <%--<asp:CustomValidator ErrorMessage="Campo invalido" id="cvMarca" runat="server" ValidationGroup="AgregarVehiculo" OnServerValidate="cvMarca_ServerValidate" Cssclass="help-block"/>--%>
				    </div>                   

				    <div  class="form-group" > 
                        <asp:TextBox runat="server" ID="tbModelo" PlaceHolder="Modelo" Cssclass="form-control" width="175"/>
                        <%--<asp:CustomValidator ErrorMessage="Campo invalido" id="cvModelo" runat="server" ValidationGroup="AgregarVehiculo" OnServerValidate="cvModelo_ServerValidate" Cssclass="help-block"/>--%>
				    </div>


				    <div class="form-group" > 
					    <asp:TextBox runat="server" ID="tbPatente" PlaceHolder="Patente"  Cssclass="form-control" width="175"/>
                        <%--<asp:CustomValidator ErrorMessage="Campo invalido" id="cvPatente" runat="server" ValidationGroup="AgregarVehiculo" OnServerValidate="cvPatente_ServerValidate" Cssclass="help-block"/>--%>
				    </div> 


				    <div class="form-group" >
					    <asp:TextBox runat="server" ID="tbColor" PlaceHolder="Color"  Cssclass="form-control" width="175"/>
                        <%--<asp:CustomValidator ErrorMessage="Campo invalido" id="cvColor" runat="server" ValidationGroup="AgregarVehiculo" OnServerValidate="cvColor_ServerValidate" Cssclass="help-block"/>--%>
				    </div>


				    <div class="form-group" > 
					    <asp:TextBox runat="server" ID="tbAsientos" PlaceHolder="Asientos Disponibles"  Cssclass="form-control" width="175"/>
                        <%--<asp:CustomValidator ErrorMessage="Campo invalido" id="cvAsientos" runat="server" ValidationGroup="AgregarVehiculo" OnServerValidate="cvAsientos_ServerValidate" Cssclass="help-block"/>--%>
				    </div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="tbDescripcion" rows="4" TextMode="multiline" PlaceHolder="Descripcion:" CssClass="form-control" Width="400" />
                        <%--<asp:CustomValidator ErrorMessage="Campo invalido" id="cvDescripcion" runat="server" ValidationGroup="AgregarVehiculo" OnServerValidate="cvDescripcion_ServerValidate" Cssclass="help-block"/>--%>
                    </div>

                    <div class="form-group" >
                        
                        <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" />
				    </div> 	
                            
			    </div> 
		    </div>	   
		</section>
		
	</article>
</div>
</asp:Content>
