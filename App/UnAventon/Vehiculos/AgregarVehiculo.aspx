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
					    <h3><asp:Literal runat="server" id="liTitulo"/></h3> 
                        <p><asp:Literal runat="server" ID="liSubTitulo" /></p>
				    </div>
                    <br />  

                    <div  id="divMarca" class="form-group"> 
					    <asp:TextBox runat="server" ID="tbMarca" PlaceHolder="Marca" Cssclass="form-control " width="175"/>
                        <asp:CustomValidator ErrorMessage="errormessage" ControlToValidate="tbMarca" runat="server"  ID="cvMarca" OnServerValidate="cvMarca_ServerValidate" ValidationGroup="GroupRegistrarVehiculo" />
				    </div>                   

				    <div  class="form-group" > 
                        <asp:TextBox runat="server" ID="tbModelo" PlaceHolder="Modelo" Cssclass="form-control" width="175"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" ControlToValidate="tbModelo" runat="server" ID="cvModelo" OnServerValidate="cvModelo_ServerValidate" ValidationGroup="GroupRegistrarVehiculo" EnableClientScript="false" />
				    </div>

				    <div class="form-group" > 
					    <asp:TextBox runat="server" ID="tbPatente" PlaceHolder="Patente"  Cssclass="form-control" width="175"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" ControlToValidate="tbPatente" runat="server" ID="cvPatente" OnServerValidate="cvPatente_ServerValidate" ValidationGroup="GroupRegistrarVehiculo" EnableClientScript="false"/>
				    </div> 

				    <div class="form-group" >
					    <asp:TextBox runat="server" ID="tbColor" PlaceHolder="Color"  Cssclass="form-control" width="175"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" ControlToValidate="tbColor" runat="server" ID="cvColor" OnServerValidate="cvColor_ServerValidate" ValidationGroup="GroupRegistrarVehiculo" EnableClientScript="false"/>
				    </div>

				    <div class="form-group" > 
					    <asp:TextBox runat="server" ID="tbAsientos" PlaceHolder="Asientos Disponibles"  Cssclass="form-control" width="175"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" ControlToValidate="tbAsientos" runat="server" ID="cvAsientos" OnServerValidate="cvAsientos_ServerValidate" ValidationGroup="GroupRegistrarVehiculo" EnableClientScript="false"/>
				    </div>

                    <div class="form-group" >               
                        <asp:Button Text="Registrar" runat="server" ID="btnRegistrar" CssClass="boton_personalizado" OnClick="btnRegistrar_Click" />
                        <asp:Button Text="Modificar" runat="server" ID="btnModificar" CssClass="boton_personalizado" OnClick="btnModificar_Click" />
				    </div> 	                            
			    </div> 
		    </div>	   
		</section>		
	</article>
    </div>
</asp:Content>
