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
                    <asp:CustomValidator ErrorMessage="errormessage" ControlToValidate="ddlProvinciaSalida" runat="server" />
                    <span class="has-warning"><%--aca va el mensaje de error--%></span>
                </div>

                <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
                    <label>Ciudad Salida</label>
                    <asp:DropDownList ID="ddlCiudadSalida" CssClass="form-control TexboxRounded" runat="server"></asp:DropDownList>
                </div>

                <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
                    <label>Provincia Destino</label>
                    <asp:DropDownList ID="ddlProvinciaDestino" OnSelectedIndexChanged="ddlProvinciaDestino_SelectedIndexChanged" CssClass="form-control TexboxRounded" runat="server"></asp:DropDownList>
                </div>

                <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
                    <label>Ciudad Destino</label>
                    <asp:DropDownList ID="ddlCiudadDestino" CssClass="form-control TexboxRounded" runat="server"></asp:DropDownList>
                </div>
           <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>
    <%--FIN ORIGEN/DESTINO--%>

    <div class="row">
        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Duracion</label>
            <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbDuracion" />
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Lugares Disponibles</label>
            <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbLugaresDisponibles" />
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Vehiculo</label>
            <asp:DropDownList ID="ddlVehiculo" CssClass="TexboxRounded" runat="server"></asp:DropDownList>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Fecha</label>
            <asp:Calendar runat="server" CssClass="TexboxRounded" ID="tbFecha"></asp:Calendar>
            <%--<asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbFecha" />--%>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Hora Salida</label>
            <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbHoraSalida" />
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Precio</label>
            <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbPrecio" />
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <label>Tipo de Viaje</label>
            <asp:DropDownList ID="ddlTipoViaje" CssClass="TexboxRounded" runat="server">
                <asp:ListItem Text="DIARIO" />
                <asp:ListItem Text="OCASIONAL" />
            </asp:DropDownList>
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

