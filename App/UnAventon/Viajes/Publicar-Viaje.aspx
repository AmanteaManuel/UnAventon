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
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upDestinos">
            <ContentTemplate>
                <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
                    <label>Provincia Salida</label>
                    <asp:DropDownList ID="ddlProvinciaSalida" CssClass="form-control" runat="server"></asp:DropDownList>
                    <span class="has-warning"><%--aca va el mensaje de error--%></span>
                </div>

                <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
                    <label>Ciudad Salida</label>
                    <asp:DropDownList ID="ddlProvinciaDestino" OnSelectedIndexChanged="ddlProvinciaDestino_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>

                <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
                    <label>Provincia Destino</label>
                    <asp:DropDownList ID="ddlCiudadSalida" OnSelectedIndexChanged="ddlCiudadSalida_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>

                <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
                    <label>Ciudad Destino</label>
                    <asp:DropDownList ID="ddlCiudadDestino" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%--FIN ORIGEN/DESTINO--%>
    
    <div class="row">
        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbDuracion" />
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbLugaresDisponibles" />
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
            <asp:DropDownList CssClass="TexboxRounded" runat="server">
                <asp:ListItem Text="auto1" />
                <asp:ListItem Text="auto2" />
            </asp:DropDownList>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group has-error">
             <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbFecha" />
        </div>
    </div>
        
        
                
       

        <div id="divDuracion" class="col-sm-3 form-group has-error help-block">
            <asp:Literal Text="Duracion" runat="server" />
            
        </div>

        <div id="divLugaresDisponibles" class="col-sm-3 form-group has-error help-block">
            <asp:Literal Text="Lugares Disponibles" runat="server" />
            
        </div>

        <div id="divAuto" class="col-sm-3 form-group has-error help-block">
            <asp:Literal Text="Auto" runat="server" />
            
        </div>

        <div id="divFecha" class="col-sm-3">
            <asp:Literal Text="Fecha" runat="server" />
           
        </div>

        <div id="divHoraSalida" class="col-sm-3">
            <asp:Literal Text="Hora Salida" runat="server" />
            <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbHoraSalida" />
        </div>

        <div id="divPrecio" class="col-sm-3">
            <asp:Literal Text="Precio" runat="server" />
            <asp:TextBox CssClass="TexboxRounded" runat="server" ID="Precio" />
        </div>

        <div id="divTipoViaje" class="col-sm-3 form-group has-error help-block">
            <%--class="form-group has-error help-block"--%>
            <asp:Literal Text="Tipo Viaje" runat="server" />
            <asp:DropDownList ID="ddlTipoViaje" CssClass="TexboxRounded" runat="server">
                <asp:ListItem Text="DIARIO" />
                <asp:ListItem Text="OCASIONAL" />
            </asp:DropDownList>
        </div>
        <br />
        <div id="divDescripcion">
            <asp:Literal Text="Comentarios" runat="server" />
            <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbDescripcion" Width="700" Height="150" />
            <asp:Button Text="Publicar" runat="server" ID="btnPublicarViaje" CssClass="boton_personalizado" OnClick="btnPublicarViaje_Click" />
        </div>
    </div>
    <br />

    <div class="Container">
        <div class="center">
        </div>
    </div>
    </div>

</asp:Content>

