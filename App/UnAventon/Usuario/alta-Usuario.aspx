<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="alta-Usuario.aspx.cs" Inherits="UnAventon.Usuario.alta_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="global">    
		    <div> 
			    <div>
				    <div> 
					    <h3><asp:Literal runat="server" id="liTitulo"/></h3>
					    <p><asp:Literal runat="server" ID="liSubTitulo" /></p>
					    <%--<span class="required_notification">Datos requeridos</span> --%>
				    </div>
                    <br />  

                    <div  id="divNombreusuario" class="form-group has-error help-block" runat="server"> 
                        <asp:Literal Text="Nombre de Usuario" runat="server" />
					    <asp:TextBox runat="server" ID="tbNombreUsuario" PlaceHolder="Nombre de Usuario" Cssclass="form-control has-error " width="175"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" id="cvNombreUsuario" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvNombreUsuario_ServerValidate"/>
				    </div>                   

				    <div  class="form-group" > 
                        <asp:Literal Text="Nombre" runat="server" />
                        <asp:TextBox runat="server" ID="tbNombre" PlaceHolder="Nombre" Cssclass="form-control" width="175"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" id="cvNombre" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvNombre_ServerValidate" CssClass="help-block" />
				    </div>

				    <div class="form-group" > 
                        <asp:Literal Text="Apellido" runat="server" />
					    <asp:TextBox runat="server" ID="tbApellido" PlaceHolder="Apellido"  Cssclass="form-control" width="175"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" id="cvApellido" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvApellido_ServerValidate" CssClass="help-block"/>
				    </div> 

				    <div class="form-group" >
                        <asp:Literal Text="Email" runat="server" />
					    <asp:TextBox runat="server" ID="tbEmail" PlaceHolder="Email"  Cssclass="form-control" width="175"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido"  id="cvEmail" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvEmail_ServerValidate" CssClass="help-block"/>
				    </div>
                    
                    <div  id="divDni" class="form-group has-error help-block" runat="server"> 
                        <asp:Literal Text="Dni" runat="server" />
					    <asp:TextBox runat="server" ID="tbDni" PlaceHolder="Dni" Cssclass="form-control has-error" width="175"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" id="cvDni" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvDni_ServerValidate"/>
				    </div> 

                    <div  id="divFechaNacimiento" class="form-group has-error help-block" runat="server"> 
					    <asp:TextBox runat="server" ID="tbFechaNacimiento" PlaceHolder="dd/mm/aaaa" Cssclass="form-control has-error" width="175"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" id="cvFechaNacimiento" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvFechaNacimiento_ServerValidate"/>
				    </div> 

				    <div class="form-group" > 
                        <asp:Literal Text="Contraseña" runat="server" />
					    <asp:TextBox runat="server" ID="tbContrasenia" PlaceHolder="Contraseña"  Cssclass="form-control" width="175"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" id="cvContrasenia" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvContrasenia_ServerValidate" CssClass="help-block"/>
				    </div>

                    <div class="form-group" > 
                        <asp:Literal Text="Repita Contraseña" runat="server" />
					    <asp:TextBox runat="server" ID="tbRepitaContraseña" PlaceHolder="Repita Contraseña" Cssclass="form-control" width="175"/>
                        <asp:CustomValidator ErrorMessage="Campo invalido" id="cvRepitaContraseña" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvRepitaContraseña_ServerValidate" CssClass="help-block"/>
				    </div>

                    <div class="form-group" >                        
                        <asp:Button Text="Registrarse" Visible="true" runat="server" ID="btnRegistrarse" CssClass="boton_personalizado" OnClick="btnAceptar_Click" />
                        <asp:Button Text="Modificar" Visible="true" runat="server" ID="btnModificar" CssClass="boton_personalizado" OnClick="btnModificar_Click" />
				    </div> 	
                            
			    </div> 
		    </div>	
</div>
</asp:Content>
<%--MENSAJE DE ERROR--%>
<%--    <div class="alert" visible ="false" runat="server" id="divMensajeError">
    <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
    <asp:Literal id="liMensajeError" runat="server" />
</div>--%>