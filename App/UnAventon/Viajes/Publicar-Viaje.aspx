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
        <div class="row wrapper">

            <%--ORIGEN/DESTINO--%>
            <%--<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upDestinos">--%>
                <ContentTemplate>
                    <div id="divProvinciaSalida" class="col-sm-3 form-group has-error help-block">
                        <asp:Literal Text="Provincia Salida" runat="server" />
                        <asp:DropDownList ID="ddlProvinciaSalida" CssClass="TexboxRounded" runat="server">
                        </asp:DropDownList>
                    </div>

                    <div id="divCiudadSalida" class="col-sm-3 form-group has-error help-block">
                        <%--class="form-group has-error help-block"--%>
                        <asp:Literal Text="Ciudad Salida" runat="server" />
                        <asp:DropDownList ID="ddlCiudadSalida" OnSelectedIndexChanged="ddlCiudadSalida_SelectedIndexChanged" CssClass="TexboxRounded" runat="server">
                        </asp:DropDownList>
                    </div>

                    <div id="divProvinciaDestino" class="col-sm-3 form-group has-error help-block">
                        <asp:Literal Text="Provincia Destino" runat="server" />
                        <asp:DropDownList ID="ddlProvinciaDestino" OnSelectedIndexChanged="ddlProvinciaDestino_SelectedIndexChanged" CssClass="TexboxRounded" runat="server">
                        </asp:DropDownList>
                    </div>

                    <div id="divCiudadDestino" class="col-sm-3 form-group has-error help-block">
                        <asp:DropDownList ID="ddlCiudadDestino" CssClass="TexboxRounded" runat="server">
                        </asp:DropDownList>
                    </div>
                </ContentTemplate>
           <%-- </asp:UpdatePanel>--%>
            <%--FIN ORIGEN/DESTINO--%>

            <div id="divDuracion" class="col-sm-3 form-group has-error help-block">
                <asp:Literal Text="Duracion" runat="server" />
                <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbDuracion" />
            </div>

            <div id="divLugaresDisponibles" class="col-sm-3 form-group has-error help-block">
                <asp:Literal Text="Lugares Disponibles" runat="server" />
                <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbLugaresDisponibles" />
            </div>

            <div id="divAuto" class="col-sm-3 form-group has-error help-block">
                <asp:Literal Text="Auto" runat="server" />
                <asp:DropDownList  CssClass="TexboxRounded" runat="server">
                    <asp:ListItem Text="auto1" />
                    <asp:ListItem Text="auto2" />
                </asp:DropDownList>
            </div>

            <div id="divFecha" class="col-sm-3">
                <asp:Literal Text="Fecha" runat="server" />
                <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbFecha" />
            </div>

            <div id="divHoraSalida" class="col-sm-3">
                <asp:Literal Text="Hora Salida" runat="server" />
                <asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbHoraSalida" />
            </div>

            <div id="divPrecio" class="col-sm-3">
                <asp:Literal Text="Precio" runat="server" />
                <asp:TextBox CssClass="TexboxRounded" runat="server" ID="Precio" />
            </div>

            <div id="divTipoViaje" class="col-sm-3 form-group has-error help-block" >
                <%--class="form-group has-error help-block"--%>
                <asp:Literal Text="Tipo Viaje" runat="server" />
                <asp:DropDownList ID="ddlTipoViaje" CssClass="TexboxRounded" runat="server">
                    <asp:ListItem Text="DIARIO" />
                    <asp:ListItem Text="OCASIONAL" />
                </asp:DropDownList>
            </div>
            <br />
            <div id="divDescripcion">
                &nbsp;&nbsp;&nbsp;
                <asp:Literal Text="Comentarios" runat="server" />
                &nbsp;<asp:TextBox CssClass="TexboxRounded" runat="server" ID="tbDescripcion" Width="700" Height="150" />
            &nbsp;&nbsp;
                <asp:Button Text="Publicar" runat="server" ID="btnPublicarViaje" CssClass="boton_personalizado" OnClick="btnPublicarViaje_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
        </div>
        <br />

        <div class="Container">
            <div class="center">
            </div>
        </div>
    </div>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
</asp:Content>

