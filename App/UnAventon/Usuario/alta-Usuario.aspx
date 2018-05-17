<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="alta-Usuario.aspx.cs" Inherits="UnAventon.Usuario.alta_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div id="global">	
	<article>
		<section>				
		    <div> 
			    <div>
				    <div> 
					    <h3>Alta de usuario</h3>
					    <p>Información de la persona</p>
					    <span class="required_notification">Datos requeridos</span> 
				    </div>
                    <br />  

                    <div  id="divNombreusuario" class="form-group has-error has-feedback" runat="server"> 
					    <asp:TextBox runat="server" ID="tbNombreUsuario" PlaceHolder="Nombre de Usuario" Cssclass="form-control has-error"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" id="cvNombreUsuario" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvNombreUsuario_ServerValidate" Cssclass="help-block"/>
				    </div>                   

				    <div  class="form-group" > 
                        <asp:TextBox runat="server" ID="tbNombre" PlaceHolder="Nombre"  Cssclass="form-control"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" id="cvNombre" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvNombre_ServerValidate" />
				    </div>


				    <div class="form-group" > 
					    <asp:TextBox runat="server" ID="tbApellido" PlaceHolder="Apellido"  Cssclass="form-control" />
                        <asp:CustomValidator ErrorMessage="Campo invalido" id="cvApellido" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvApellido_ServerValidate"/>
				    </div> 


				    <div class="form-group" >
					    <asp:TextBox runat="server" ID="tbEmail" PlaceHolder="Email"  Cssclass="form-control"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido"  id="cvEmail" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvEmail_ServerValidate"/>
				    </div>


				    <div class="form-group" > 
					    <asp:TextBox runat="server" ID="tbContrasenia" PlaceHolder="Contraseña"  Cssclass="form-control"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" id="cvContrasenia" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvContrasenia_ServerValidate"/>
				    </div>


                    <div class="form-group" > 
					    <asp:TextBox runat="server" ID="tbRepitaContraseña" PlaceHolder="Repita Contraseña"   Cssclass="control-label"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" id="cvRepitaContraseña" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvRepitaContraseña_ServerValidate"/>
				    </div>

                    <div class="form-group"   Cssclass="form-control">
                        <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" />
				    </div> 	
                            
			    </div> 
		    </div>	   
		</section>
		
	</article>
</div>

</asp:Content>
