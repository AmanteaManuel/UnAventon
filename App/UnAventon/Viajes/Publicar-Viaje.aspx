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
        <div class="col-xs-12 col-md-2 col-lg-2 form-group">
            <label>Provincia Salida</label>
            <asp:DropDownList ID="ddlProvinciaSalida" OnSelectedIndexChanged="ddlProvinciaSalida_SelectedIndexChanged" CssClass="form-control " runat="server" AutoPostBack="true"></asp:DropDownList>
            <asp:CustomValidator ErrorMessage="*" runat="server" ID="cvProvSalida" OnServerValidate="cvProvSalida_ServerValidate" ValidationGroup="PublicarViaje" />
            <span class="has-warning"><%--aca va el mensaje de error--%></span>
        </div>
        <div class="col-xs-12 col-md-2 col-lg-2 form-group">
            <label>Ciudad Salida</label>
            <asp:DropDownList ID="ddlCiudadSalida" CssClass="form-control " runat="server" AutoPostBack="true"></asp:DropDownList>
            <asp:CustomValidator ErrorMessage="*" runat="server" ID="cvCiduadSalida" OnServerValidate="cvCiduadSalida_ServerValidate" ValidationGroup="PublicarViaje" />
        </div>
        <div class="col-xs-12 col-md-2 col-lg-2 form-group ">
            <label>Provincia Destino</label>
            <asp:DropDownList ID="ddlProvinciaDestino" OnSelectedIndexChanged="ddlProvinciaDestino_SelectedIndexChanged" CssClass="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
            <asp:CustomValidator ErrorMessage="*" runat="server" ID="cvProvDestino" OnServerValidate="cvProvDestino_ServerValidate" ValidationGroup="PublicarViaje" />
        </div>
        <div class="col-xs-12 col-md-2 col-lg-2 form-group">
            <label>Ciudad Destino</label>
            <asp:DropDownList ID="ddlCiudadDestino" CssClass="form-control " runat="server" AutoPostBack="true"></asp:DropDownList>
            <asp:CustomValidator ErrorMessage="*" runat="server" ID="cvCiudadDestino" OnServerValidate="cvCiudadDestino_ServerValidate" ValidationGroup="PublicarViaje" />
        </div>
    </div>
    <%--FIN ORIGEN/DESTINO--%>

    <div class="row">
        <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
            <label>Duracion</label>
            <asp:TextBox CssClass="form-control " runat="server" ID="tbDuracion"  />
            <asp:CustomValidator ErrorMessage="*" runat="server" id="cvDuracion" OnServerValidate="cvDuracion_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
            <label>Lugares Disponibles</label>
            <asp:TextBox CssClass="form-control " runat="server" ID="tbLugaresDisponibles" />
            <asp:CustomValidator ErrorMessage="*"  runat="server" id="cvLugaresDisponibles" OnServerValidate="cvLugaresDisponibles_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
            <label>Vehiculo</label>
            <asp:DropDownList ID="ddlVehiculo" CssClass="form-control " runat="server"></asp:DropDownList>
            <asp:CustomValidator ErrorMessage="*"  runat="server" id="cvVehiulo" OnServerValidate="cvVehiulo_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-3 form-group" visible="false" runat="server" id="divFecha">
            <label>Fecha</label>
            <asp:Calendar runat="server" CssClass="" ID="tbFecha"></asp:Calendar>
            <asp:CustomValidator ErrorMessage="*"  ID="cvFecha" runat="server" OnServerValidate="cvFecha_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
            <label>Hora Salida</label>
            <asp:TextBox CssClass="form-control " runat="server" ID="tbHoraSalida" />
            <asp:CustomValidator ErrorMessage="*"  ID="cvHoraSalida" runat="server" OnServerValidate="cvHoraSalida_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
            <label>Precio</label>
            <asp:TextBox CssClass="form-control " runat="server" ID="tbPrecio" />
            <asp:CustomValidator ErrorMessage="*"  ID="cvPrecio" runat="server" OnServerValidate="cvPrecio_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
            <label>Tipo de Viaje</label>
            <asp:DropDownList ID="ddlTipoViaje" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlTipoViaje_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Seleccione..." Value="0"/>
                <asp:ListItem Text="Ocacional" Value="1"/>
                <asp:ListItem Text="Frecuente" Value="2"/>                
            </asp:DropDownList>
            <asp:CustomValidator ErrorMessage="*" ID="cvTipoViaje" runat="server" OnServerValidate="cvTipoViaje_ServerValidate" ValidationGroup="PublicarViaje"/>           
        </div>
    </div>
    <div class="col-xs-12 col-md-2 col-lg-2 form-group ">
        <label>Comentario</label>
        <asp:TextBox CssClass="form-control" runat="server" ID="tbDescripcion" Width="700" Height="150" TextMode="MultiLine" />
        <asp:Button Text="Publicar" runat="server" ID="btnPublicarViaje" CssClass="boton_personalizado" OnClick="btnPublicarViaje_Click" />
    </div>
    <div class="col-xs-12 col-md-2 col-lg-2 form-group ">
        <label>Comentario</label>
        
    </div>



    <div class="Container">        
    </div>
</div>

</asp:Content>

