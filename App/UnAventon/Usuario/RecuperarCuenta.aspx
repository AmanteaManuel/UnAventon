<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RecuperarCuenta.aspx.cs" Inherits="UnAventon.Usuario.RecuperarCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />

<div id="global" class="margin-general">   
	<div>
		<div> 
			<h3><strong><asp:Literal runat="server" Text="Recuperar Cuenta" /></strong></h3>
			<p><asp:Literal runat="server" Text="En esta pagina podrá recuperar una Cuenta que alla eliminado previamente"/></p>
			<%--<span class="required_notification">Datos requeridos</span> --%>
		</div>
        <br />   
        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-3" >	           
	            <div class="form-group help-block" >
                    <label class="label-default-subTitle">Email</label>
		            <asp:TextBox runat="server" ID="tbEmail" PlaceHolder="Ejemplo: JuanPerez@gmail.com"  Cssclass="form-control" width="200"/>
                    <asp:CustomValidator id="cvEmail" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvEmail_ServerValidate" CssClass="help-block"/>
	            </div>                           

                <div  id="divFechaNacimiento" class="form-group help-block" runat="server"> 
                    <label class="label-default-subTitle">Fecha Nacimiento</label>
		            <asp:TextBox runat="server" ID="tbFechaNacimiento" PlaceHolder="Ejemplo: dd/mm/aaaa" Cssclass="form-control" width="200"/>
                    <asp:CustomValidator  id="cvFechaNacimiento" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvFechaNacimiento_ServerValidate"/>
	            </div> 

                <div class="form-group help-block" > 
                    <label class="label-default-subTitle">Antigua Contraseña</label>
		            <asp:TextBox runat="server" ID="tbContraseniaVieja" type="password" PlaceHolder="Ejemplo: abc123"  CssClass ="form-control" width="200"/>
                    <asp:CustomValidator  id="cvContraseniaVieja" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvContraseniaVieja_ServerValidate" CssClass="help-block"/>
	            </div>

	            <div class="form-group help-block" > 
                    <label class="label-default-subTitle">Nueva Contraseña</label>
		            <asp:TextBox runat="server" ID="tbContrasenia" type="password" PlaceHolder="Ejemplo: abc123"  CssClass ="form-control" width="200"/>
                    <asp:CustomValidator  id="cvContraseniaNueva" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvContraseniaNueva_ServerValidate" CssClass="help-block"/>
	            </div>

                <div class="form-group help-block" > 
                    <label class="label-default-subTitle">Repita Contraseña</label>
		            <asp:TextBox runat="server" ID="tbRepitaContraseña" type="password" PlaceHolder="Ejemplo: abc123" Cssclass="form-control" width="200"/>
                    <asp:CustomValidator id="cvRepitaContraseña" runat="server" ValidationGroup="CrearUsuario" OnServerValidate="cvRepitaContraseña_ServerValidate" CssClass="help-block"/>
	            </div>  
                <div class="form-group help-block" >                        
                    <asp:Button Text="Recuperar" Visible="true" type="password" runat="server" ID="btnRegistrarse" CssClass="boton_personalizado" OnClick="btnRegistrarse_Click"  />
	            </div> 
           
        </div>
                            
	</div>		    	
</div>
</asp:Content>
