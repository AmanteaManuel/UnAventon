<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Publicar-Viaje.aspx.cs" Inherits="UnAventon.Viajes.Publicar_Viaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .boton_personalizado {
            margin-bottom: 0px;
        }
        
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<br/>
<div id="divGlobal" class="margin-general">
    <div> 
        <h3><strong><label>Publicar Viaje</label></strong></h3>
        <p><label>En esta página podrá publicar nuevos viajes.</label></p>
    </div>
    <%--ORIGEN/DESTINO--%>
    <div class="row">
        <div class="col-xs-12 col-md-2 col-lg-2 form-group">
            <label class="label-default-subTitle">Provincia Salida</label>
            <asp:DropDownList ID="ddlProvinciaSalida" OnSelectedIndexChanged="ddlProvinciaSalida_SelectedIndexChanged" CssClass="form-control " runat="server" AutoPostBack="true"></asp:DropDownList>
            <asp:CustomValidator ErrorMessage="" runat="server" ID="cvProvSalida" OnServerValidate="cvProvSalida_ServerValidate" ValidationGroup="PublicarViaje" />
            <span class="has-warning"><%--aca va el mensaje de error--%></span>
        </div>
        <div class="col-xs-12 col-md-2 col-lg-2 form-group">
            <label class="label-default-subTitle">Ciudad Salida</label>
            <asp:DropDownList ID="ddlCiudadSalida" CssClass="form-control " runat="server" AutoPostBack="true"></asp:DropDownList>
            <asp:CustomValidator ErrorMessage="" runat="server" ID="cvCiduadSalida" OnServerValidate="cvCiduadSalida_ServerValidate" ValidationGroup="PublicarViaje" />
        </div>
        <div class="col-xs-12 col-md-2 col-lg-2 form-group ">
            <label class="label-default-subTitle">Provincia Destino</label>
            <asp:DropDownList ID="ddlProvinciaDestino" OnSelectedIndexChanged="ddlProvinciaDestino_SelectedIndexChanged" CssClass="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
            <asp:CustomValidator ErrorMessage="" runat="server" ID="cvProvDestino" OnServerValidate="cvProvDestino_ServerValidate" ValidationGroup="PublicarViaje" />
        </div>
        <div class="col-xs-12 col-md-2 col-lg-2 form-group">
            <label class="label-default-subTitle">Ciudad Destino</label>
            <asp:DropDownList ID="ddlCiudadDestino" CssClass="form-control " runat="server" AutoPostBack="true"></asp:DropDownList>
            <asp:CustomValidator ErrorMessage="" runat="server" ID="cvCiudadDestino" OnServerValidate="cvCiudadDestino_ServerValidate" ValidationGroup="PublicarViaje" />
        </div>
    </div>
    <%--FIN ORIGEN/DESTINO--%>

    <div class="row">
        <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
            <label class="label-default-subTitle">Duracion en horas</label>
            <asp:TextBox CssClass="form-control " runat="server" ID="tbDuracion"  placeholder ="Ejemplo: 1"/>
            <asp:CustomValidator ErrorMessage=""  runat="server" id="cvDuracion" OnServerValidate="cvDuracion_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
            <label class="label-default-subTitle">Lugares Disponibles</label>
            <asp:TextBox CssClass="form-control " runat="server" ID="tbLugaresDisponibles" placeholder ="Ejemplo: 4"/>
            <asp:CustomValidator ErrorMessage=""   runat="server" id="cvLugaresDisponibles" OnServerValidate="cvLugaresDisponibles_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
            <label class="label-default-subTitle">Vehiculo</label>
            <asp:DropDownList ID="ddlVehiculo" CssClass="form-control " runat="server"></asp:DropDownList>
            <asp:CustomValidator ErrorMessage="" runat="server" id="cvVehiulo" OnServerValidate="cvVehiulo_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-3 form-group" runat="server" id="divFecha">
            <label class="label-default-subTitle">Fecha</label>
            <asp:Calendar runat="server" CssClass="nomargin" ID="tbFecha"></asp:Calendar>
            <asp:CustomValidator ErrorMessage=""  ID="cvFecha" runat="server" OnServerValidate="cvFecha_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
            <label class="label-default-subTitle">Hora Salida</label>
            <asp:TextBox CssClass="form-control " runat="server" ID="tbHoraSalida" placeholder ="Ejemplo: 12:00"/>
            <asp:CustomValidator ErrorMessage=""  ID="cvHoraSalida" runat="server" OnServerValidate="cvHoraSalida_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
            <label class="label-default-subTitle">Precio Total</label>
            <asp:TextBox CssClass="form-control " runat="server" ID="tbPrecio" placeholder ="Ejemplo: 500"/>
            <asp:CustomValidator ErrorMessage=""  ID="cvPrecio" runat="server" OnServerValidate="cvPrecio_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>

        <div class="col-xs-12 col-md-2 col-lg-2 form-group ">
            <label class="label-default-subTitle">Tipo de Viaje</label>
            <asp:DropDownList ID="ddlTipoViaje" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlTipoViaje_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Seleccione..." Value="0"/>
                <asp:ListItem Text="Ocacional" Value="1"/>
                <asp:ListItem Text="Frecuente" Value="2"/>                
            </asp:DropDownList>
            <asp:CustomValidator ErrorMessage="*" ID="cvTipoViaje" runat="server" OnServerValidate="cvTipoViaje_ServerValidate" ValidationGroup="PublicarViaje"/>           
        </div>
        <div class="col-xs-12 col-md-2 col-lg-2 form-group ">
            <asp:Button Text="Agregar Viaje" runat="server" ID="btnAgregarViaje" CssClass="boton_personalizado" visible="false" OnClick="btnAgregarViaje_Click" />
        </div>
    </div>
    <div class="row">    
        <div class="col-xs-12 col-md-2 col-lg-5 form-group ">
            <label class="label-default-subTitle">Comentario</label>
            <asp:TextBox CssClass="form-control" runat="server" placeholder="Ejemplo: Comentario..." ID="tbDescripcion" TextMode="MultiLine" />
            <br />
            <asp:Button Text="Publicar" runat="server" ID="btnPublicarViaje" CssClass="boton_personalizado" OnClick="btnPublicarViaje_Click" />
        </div>
        <div class="col-xs-12 col-md-2 col-lg-5 form-group" id="divViajesAgregados" visible="false" runat="server">
            <div class="table-responsive">
                <table class="table table-hover">
                <asp:Repeater runat="server" ID="rptViajesAgregados">
                    <HeaderTemplate >
                        <thead class="silver-background">&nbsp<hr width="55%">
                            <tr>
                                <th>Origen</th>
                                <th>Destino</th>
                                <th>Precio</th>
                                <th>Fecha</th>
                                <th>Hora</th>
                            </tr>
                        </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td><asp:Literal Text='<%# Eval("Origen.Descripcion") %>' runat="server"/></td>
                                <td><asp:Literal Text='<%# Eval("Destino.Descripcion") %>' runat="server"/></td>
                                <td><asp:Literal Text='<%# Eval("Precio") %>' runat="server"/></td>
                                <td><asp:Literal Text='<%# Eval("FechaSalida") %>' runat="server"/></td>
                                <td><asp:Literal Text='<%# Eval("HoraSalida") %>' runat="server"/></td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class="Container">        
    </div>
</div>

</asp:Content>

