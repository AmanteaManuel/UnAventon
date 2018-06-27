<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="alta-Usuario.aspx.cs" Inherits="UnAventon.Usuario.alta_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<div id="global" class="margin-general">   
	<div>
		<div> 
			<h3><strong><asp:Literal runat="server" id="liTitulo"/></strong></h3>
			<p><asp:Literal runat="server" ID="liSubTitulo" /></p>
			<%--<span class="required_notification">Datos requeridos</span> --%>
		</div>
        <br />   
        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-3" >
	            <div  class="form-group help-block" > 
                    <label class="label-default-subTitle">Nombre</label>
                    <asp:TextBox runat="server" ID="tbNombre" PlaceHolder="Ejemplo: Juan" Cssclass="form-control" width="200"/>
                    <asp:CustomValidator id="cvNombre" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvNombre_ServerValidate" CssClass="help-block" />
	            </div>

	            <div class="form-group help-block" > 
                    <label class="label-default-subTitle">Apellido</label>
		            <asp:TextBox runat="server" ID="tbApellido" PlaceHolder="Ejemplo: Perez"  Cssclass="form-control" width="200"/>
                    <asp:CustomValidator id="cvApellido" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvApellido_ServerValidate" CssClass="help-block"/>
	            </div> 

	            <div class="form-group help-block" >
                    <label class="label-default-subTitle">Email</label>
		            <asp:TextBox runat="server" ID="tbEmail" PlaceHolder="Ejemplo: JuanPerez@gmail.com"  Cssclass="form-control" width="200"/>
                    <asp:CustomValidator id="cvEmail" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvEmail_ServerValidate" CssClass="help-block"/>
	            </div>
                    
                <div  id="divDni" class="form-group help-block" runat="server"> 
                    <label class="label-default-subTitle">Dni</label>
		            <asp:TextBox runat="server" ID="tbDni" PlaceHolder="Ejemplo: 37426581" Cssclass="form-control" width="200"/>
                    <asp:CustomValidator id="cvDni" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvDni_ServerValidate"/>
	            </div>                 
            </div>
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-3" >

                <div  id="divFechaNacimiento" class="form-group help-block" runat="server"> 
                    <label class="label-default-subTitle">Fecha Nacimiento</label>
		            <asp:TextBox runat="server" ID="tbFechaNacimiento" PlaceHolder="Ejemplo: dd/mm/aaaa" Cssclass="form-control" width="200"/>
                    <asp:CustomValidator  id="cvFechaNacimiento" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvFechaNacimiento_ServerValidate"/>
	            </div> 

	            <div class="form-group help-block" > 
                    <label class="label-default-subTitle">Nueva Contraseña</label>
		            <asp:TextBox runat="server" ID="tbContrasenia" type="password" PlaceHolder="Ejemplo: abc123"  CssClass ="form-control" width="200"/>
                    <asp:CustomValidator  id="cvContrasenia" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvContrasenia_ServerValidate" CssClass="help-block"/>
	            </div>

                <div class="form-group help-block" > 
                    <label class="label-default-subTitle">Repita Contraseña</label>
		            <asp:TextBox runat="server" ID="tbRepitaContraseña" type="password" PlaceHolder="Ejemplo: abc123" Cssclass="form-control" width="200"/>
                    <asp:CustomValidator id="cvRepitaContraseña" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvRepitaContraseña_ServerValidate" CssClass="help-block"/>
	            </div>  
                <div class="form-group help-block" >                        
                    <asp:Button Text="Registrarse" Visible="true" type="password" runat="server" ID="btnRegistrarse" CssClass="boton_personalizado" OnClick="btnAceptar_Click" />
                    <asp:Button Text="Modificar" Visible="true" runat="server" ID="btnModificar" CssClass="boton_personalizado" OnClick="btnModificar_Click" />
	            </div> 
            </div>

            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-3" >
                 <div class="form-group help-block" id="divFotoPerfil" >
                    <label class="label-default-subTitle">Foto de Perfil</label>
                    <strong><asp:FileUpload runat="server" id="fuFotoPerfil"/></strong>
                     <asp:LinkButton runat="server" ToolTip="Cambiar Foto de Perfil" id="lbFotoPerfil" OnClick="lbFotoPerfil_Click"><img src="../img/Change-Pick.png" height="20" width="25" /></asp:LinkButton>                   
                </div>  
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