﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Publicar-Viaje.aspx.cs" Inherits="UnAventon.Viajes.Publicar_Viaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .boton_personalizado {
            margin-bottom: 0px;
        }
        
        .trasnparent-background{
            background: rgba(192,192,192,0.2);
            color: #fff !important;
        }
        .center {
            margin: auto;
            width: 50%;            
            border: 3px solid black;
            padding: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<br/>
<div id="divGlobal" class="margin-general">
    <div> 
        <h3><strong><asp:Literal runat="server" ID="liTitulo" /></strong></h3>
        <p><asp:Literal runat="server" ID="liSubtitulo" /></p>
    </div>

   

    <div class="row">
        <div class="col-xs-12 col-md-2 col-lg-9 form-group">
            <%--ORIGEN/DESTINO--%>
                <div class="row">
                    <div class="col-xs-12 col-md-2 col-lg-3 form-group">
                        <label class="label-default-subTitle">Provincia Salida</label>
                        <asp:DropDownList ID="ddlProvinciaSalida" OnSelectedIndexChanged="ddlProvinciaSalida_SelectedIndexChanged" CssClass="form-control " runat="server" AutoPostBack="true"></asp:DropDownList>
                        <asp:CustomValidator ErrorMessage="" runat="server" ID="cvProvSalida" OnServerValidate="cvProvSalida_ServerValidate" ValidationGroup="PublicarViaje" />
                        <%--<span class="has-warning"></span>--%>
                    </div>
                    <div class="col-xs-12 col-md-2 col-lg-3 form-group">
                        <label class="label-default-subTitle">Ciudad Salida</label>
                        <asp:DropDownList ID="ddlCiudadSalida" CssClass="form-control " runat="server" AutoPostBack="true"></asp:DropDownList>
                        <asp:CustomValidator ErrorMessage="" runat="server" ID="cvCiduadSalida" OnServerValidate="cvCiduadSalida_ServerValidate" ValidationGroup="PublicarViaje" />
                    </div>
                    <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
                        <label class="label-default-subTitle">Provincia Destino</label>
                        <asp:DropDownList ID="ddlProvinciaDestino" OnSelectedIndexChanged="ddlProvinciaDestino_SelectedIndexChanged" CssClass="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
                        <asp:CustomValidator ErrorMessage="" runat="server" ID="cvProvDestino" OnServerValidate="cvProvDestino_ServerValidate" ValidationGroup="PublicarViaje" />
                    </div>
                    <div class="col-xs-12 col-md-2 col-lg-3 form-group">
                        <label class="label-default-subTitle">Ciudad Destino</label>
                        <asp:DropDownList ID="ddlCiudadDestino" CssClass="form-control " runat="server" AutoPostBack="true"></asp:DropDownList>
                        <asp:CustomValidator ErrorMessage="" runat="server" ID="cvCiudadDestino" OnServerValidate="cvCiudadDestino_ServerValidate" ValidationGroup="PublicarViaje" />
                    </div>
                </div>
            <%--FIN ORIGEN/DESTINO--%>
            <br />
            <%--DURACION TIPO VEHICULO--%>
                <div class="row">
                    <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
                        <label class="label-default-subTitle">Duracion en horas</label>
                        <asp:TextBox CssClass="form-control " runat="server" ID="tbDuracion"  placeholder ="Ejemplo: 1"/>
                        <asp:CustomValidator ErrorMessage=""  runat="server" id="cvDuracion" OnServerValidate="cvDuracion_ServerValidate" ValidationGroup="PublicarViaje"/>
                    </div>

                    <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
                        <label class="label-default-subTitle">Tipo de Viaje</label>
                        <asp:DropDownList ID="ddlTipoViaje" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlTipoViaje_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Seleccione..." Value="0"/>
                            <asp:ListItem Text="Ocasional" Value="1"/>
                            <asp:ListItem Text="Frecuente" Value="2"/>
                            <asp:ListItem Text="Periodico" Value="3"/>
                        </asp:DropDownList>
                        <asp:CustomValidator ErrorMessage="*" ID="cvTipoViaje" runat="server" OnServerValidate="cvTipoViaje_ServerValidate" ValidationGroup="PublicarViaje"/>           
                    </div>

                    <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
                        <label class="label-default-subTitle">Vehiculo</label>
                        <asp:DropDownList ID="ddlVehiculo" CssClass="form-control " runat="server"></asp:DropDownList>
                        <asp:CustomValidator ErrorMessage="" runat="server" id="cvVehiulo" OnServerValidate="cvVehiulo_ServerValidate" ValidationGroup="PublicarViaje"/>
                    </div>        
                </div>
            <%--FIN DURACION TIPO VEHICULO--%>
            <br />
            <%--HORA SALIDA PRECIO LUGARES--%>
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

                <div class="col-xs-12 col-md-2 col-lg-3 form-group ">
                    <label class="label-default-subTitle">Lugares Disponibles</label>
                    <asp:TextBox CssClass="form-control " runat="server" ID="tbLugaresDisponibles" placeholder ="Ejemplo: 4"/>
                    <asp:CustomValidator ErrorMessage=""   runat="server" id="cvLugaresDisponibles" OnServerValidate="cvLugaresDisponibles_ServerValidate" ValidationGroup="PublicarViaje"/>
                </div>
        
                <div class="col-xs-12 col-md-2 col-lg-2 form-group ">
                    <asp:Button Text="Agregar Viaje" runat="server" ID="btnAgregarViaje" CssClass="boton_personalizado" visible="false" OnClick="btnAgregarViaje_Click" />
                </div>
            </div>
            <%--FIN HORA SALIDA PRECIO LUGARES--%>
            <br />
        </div>

        <%--CALENDARIO Desde--%>
        <div class="col-xs-12 col-md-2 col-lg-3 form-group" runat="server" id="divFecha">
            <asp:Label CssClass="label-default-subTitle" id="lbFecha" runat="server"/>            
            <asp:Calendar runat="server" CssClass="nomargin trasnparent-background" ID="tbFecha"></asp:Calendar>
            <asp:CustomValidator ErrorMessage=""  ID="cvFecha" runat="server" OnServerValidate="cvFecha_ServerValidate" ValidationGroup="PublicarViaje"/>
        </div>
        <%--CALENDARIO Desde--%>
    </div>

    <div class="row">
        <div class="col-xs-12 col-md-2 col-lg-9 form-group ">

            <div class="row">
                <div class="col-xs-12 col-md-2 col-lg-5 form-group ">
                    <label class="label-default-subTitle">Comentario</label>
                    <asp:TextBox CssClass="form-control" runat="server" placeholder="Ejemplo: Comentario..." ID="tbDescripcion" TextMode="MultiLine" />        
                </div>
                <%--VIAJES FRECUENTES--%>
                <div class="col-xs-12 col-md-2 col-lg-5 form-group" id="divViajesAgregados" visible="false" runat="server">
                    <div class="table-responsive">
                        <table class="table table-hover">
                            <asp:Repeater runat="server" ID="rptViajesAgregados">
                                <HeaderTemplate>
                                    <%--<thead class="silver-background">&nbsp<hr width="55%">--%>
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
                                            <td>
                                                <asp:Literal Text='<%# Eval("Origen.Descripcion") %>' runat="server" /></td>
                                            <td>
                                                <asp:Literal Text='<%# Eval("Destino.Descripcion") %>' runat="server" /></td>
                                            <td>
                                                <asp:Literal Text='<%# Eval("Precio") %>' runat="server" /></td>
                                            <td>
                                                <asp:Literal Text='<%# Eval("FechaSalida") %>' runat="server" /></td>
                                            <td>
                                                <asp:Literal Text='<%# Eval("HoraSalida") %>' runat="server" /></td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
                <%--VIAJES DIARIOS--%>
                <div class="col-xs-12 col-md-2 col-lg-5 form-group center trasnparent-background" id="divViajesDiarios" visible="false" runat="server">
                    <asp:Panel runat="server" ID="panelDias">
                        <asp:CheckBox Text="Lunes" runat="server" ID="cbklunes" />
                        <asp:CheckBox Text="Martes" runat="server" ID="cbkmartes" />
                        <asp:CheckBox Text="Miércoles" runat="server" ID="cbkmiercoles" />
                        <asp:CheckBox Text="Jueves" runat="server" ID="cbkjueves" />
                        <asp:CheckBox Text="Viernes" runat="server" ID="cbkviernes" />
                        <asp:CheckBox Text="Sabado" runat="server" ID="cbksabado" />
                        <asp:CheckBox Text="Domingo" runat="server" ID="cbkdomingo" />
                    </asp:Panel>
                    <asp:CustomValidator ErrorMessage="Seleccione al menos un día. " OnServerValidate="ViajesDiarios_ServerValidate" ID="ViajesDiarios" runat="server" ValidationGroup="DiasCheck" />
                </div>
            </div>

            <div class="row" >
                <div class="col-xs-12 col-md-2 col-lg-5 form-group ">          
                    <asp:Button Text="Publicar" runat="server" ID="btnPublicarViaje" CssClass="boton_personalizado" OnClick="btnPublicarViaje_Click"/>
                    <asp:Button Text="Modificar" runat="server" ID="btnModificar" CssClass="boton_personalizado" OnClick="btnModificar_Click"/>
                </div>
            </div>
        </div>
        <%--CALENDARIO HASTA--%>
        <div class="col-xs-12 col-md-2 col-lg-3 form-group" runat="server" id="divFechaHasta">
            <asp:Label CssClass="label-default-subTitle" Text="Fecha Hasta" runat="server" />
            <asp:Calendar runat="server" CssClass="nomargin trasnparent-background" ID="clFechaHasta"></asp:Calendar>
            <asp:CustomValidator ErrorMessage=""  ID="cvFechaHasta" runat="server" OnServerValidate="cvFechaHasta_ServerValidate" ValidationGroup="ViajePeriodico"/>
        </div>
        <%--FIN CALENDARIO HASTA--%>
    </div>
    
    <div class="Container">        
    </div>
</div>

</asp:Content>

