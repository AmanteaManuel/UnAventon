<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Publicar-Viaje.aspx.cs" Inherits="UnAventon.Viajes.Publicar_Viaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .boton_personalizado {
            margin-bottom: 0px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="divGlobal">

    <%--ORIGEN/DESTINO--%>
    <div class="row">
        <%--<asp:UpdatePanel runat="server" UpdateMode="Always" ID="upDestinos">
            <ContentTemplate>--%>
                <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
                    <label>Provincia Salida</label>
                    <asp:DropDownList ID="ddlProvinciaSalida" OnSelectedIndexChanged="ddlProvinciaSalida_SelectedIndexChanged" CssClass="form-control TexboxRounded" runat="server"></asp:DropDownList>
                    <asp:CustomValidator ErrorMessage="*" ControlToValidate="ddlProvinciaSalida" runat="server" ID="cvProvSalida" OnServerValidate="cvProvSalida_ServerValidate" ValidationGroup="PublicarViaje"/>
                    <span class="has-warning"><%--aca va el mensaje de error--%></span>
                </div>

                <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
                    <label>Ciudad Salida</label>
                    <asp:DropDownList ID="ddlCiudadSalida" CssClass="form-control TexboxRounded" runat="server"></asp:DropDownList>
                    <asp:CustomValidator ErrorMessage="*" ControlToValidate="ddlCiudadSalida" runat="server" ID="cvCiduadSalida" OnServerValidate="cvCiduadSalida_ServerValidate" ValidationGroup="PublicarViaje" />
                </div>

                <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
                    <label>Provincia Destino</label>
                    <asp:DropDownList ID="ddlProvinciaDestino" OnSelectedIndexChanged="ddlProvinciaDestino_SelectedIndexChanged" CssClass="form-control TexboxRounded" runat="server"></asp:DropDownList>
                    <asp:CustomValidator ErrorMessage="*" ControlToValidate="ddlProvinciaDestino" runat="server" ID="cvProvDestino" OnServerValidate="cvProvDestino_ServerValidate" ValidationGroup="PublicarViaje" />
                </div>

                <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
                    <label>Ciudad Destino</label>
                    <asp:DropDownList ID="ddlCiudadDestino" CssClass="form-control TexboxRounded" runat="server"></asp:DropDownList>
                    <asp:CustomValidator ErrorMessage="*" ControlToValidate="ddlCiudadDestino" runat="server" ID="cvCiudadDestino" OnServerValidate="cvCiudadDestino_ServerValidate" ValidationGroup="PublicarViaje" />
                </div>
           <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>
    <%--FIN ORIGEN/DESTINO--%>

    <div class="row">
        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Duracion</label>
            <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbDuracion" />
            <asp:CustomValidator ErrorMessage="*" ControlToValidate="tbDuracion" runat="server" id="cvDuracion" OnServerValidate="cvDuracion_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Lugares Disponibles</label>
            <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbLugaresDisponibles" />
            <asp:CustomValidator ErrorMessage="*" ControlToValidate="tbLugaresDisponibles" runat="server" id="cvLugaresDisponibles" OnServerValidate="cvLugaresDisponibles_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Vehiculo</label>
            <asp:DropDownList ID="ddlVehiculo" CssClass="TexboxRounded" runat="server"></asp:DropDownList>
            <asp:CustomValidator ErrorMessage="*" ControlToValidate="ddlVehiculo" runat="server" id="cvVehiulo" OnServerValidate="cvVehiulo_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Fecha</label>
            <asp:Calendar runat="server" CssClass="TexboxRounded" ID="tbFecha"></asp:Calendar>
<%--            <asp:CustomValidator ErrorMessage="*" ControlToValidate="tbFecha" ID="cvFecha" runat="server" OnServerValidate="cvFecha_ServerValidate" ValidationGroup="PublicarViaje"/>--%>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Hora Salida</label>
            <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbHoraSalida" />
            <asp:CustomValidator ErrorMessage="*" ControlToValidate="tbHoraSalida" ID="cvHoraSalida" runat="server" OnServerValidate="cvHoraSalida_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Precio</label>
            <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbPrecio" />
            <asp:CustomValidator ErrorMessage="*" ControlToValidate="tbPrecio" ID="cvPrecio" runat="server" OnServerValidate="cvPrecio_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Tipo de Viaje</label>
            <asp:DropDownList ID="ddlTipoViaje" CssClass="TexboxRounded" runat="server">
                <asp:ListItem Text="Ocacional" />
                <asp:ListItem Text="Frecuente" />                
            </asp:DropDownList>
            <asp:CustomValidator ErrorMessage="*" ControlToValidate="ddlTipoViaje" ID="cvTipoViaje" runat="server" OnServerValidate="cvTipoViaje_ServerValidate" ValidationGroup="PublicarViaje"/>

        </div>
    </div>
    <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
        <label>Comentario</label>
        <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbDescripcion" Width="700" Height="150" />
        <asp:Button Text="Publicar" runat="server" ID="btnPublicarViaje" CssClass="boton_personalizado" OnClick="btnPublicarViaje_Click" />
    </div>



    <div class="Container">        
    </div>
</div>

</asp:Content>

