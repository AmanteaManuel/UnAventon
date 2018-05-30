<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarVehiculo.aspx.cs" Inherits="UnAventon.Vehiculos.AgregarVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<div id="global">
    <div>
        <div>
            <div>
                <h3><asp:Literal runat="server" ID="liTitulo" /></h3>
                <p><asp:Literal runat="server" ID="liSubTitulo" /></p>
            </div>
            <br />

            <div class="form-group help-block" > 
                <label class="label-default-subTitle">Marca</label>
                <asp:TextBox runat="server" ID="tbMarca" PlaceHolder="Ejemplo: Ford" CssClass="form-control" Width="175" />
                <asp:CustomValidator runat="server" ID="cvMarca" OnServerValidate="cvMarca_ServerValidate" ValidationGroup="GroupRegistrarVehiculo" />
            </div>

            <div class="form-group help-block">
                <label class="label-default-subTitle">Modelo</label>
                <asp:TextBox runat="server" ID="tbModelo" PlaceHolder="Ejemplo: Focus" CssClass="form-control" Width="175" />
                <asp:CustomValidator runat="server" ID="cvModelo" OnServerValidate="cvModelo_ServerValidate" ValidationGroup="GroupRegistrarVehiculo" EnableClientScript="false" />
            </div>

            <div class="form-group help-block">
                <label class="label-default-subTitle">Patente</label>
                <asp:TextBox runat="server" ID="tbPatente" PlaceHolder="Ejemplo: ABC-123" CssClass="form-control" Width="175" />
                <asp:CustomValidator runat="server" ID="cvPatente" OnServerValidate="cvPatente_ServerValidate" ValidationGroup="GroupRegistrarVehiculo" EnableClientScript="false" />
            </div>

            <div class="form-group help-block">
                <label class="label-default-subTitle">Color</label>
                <asp:TextBox runat="server" ID="tbColor" PlaceHolder="Ejemplo: Negro" CssClass="form-control" Width="175" />
                <asp:CustomValidator runat="server" ID="cvColor" OnServerValidate="cvColor_ServerValidate" ValidationGroup="GroupRegistrarVehiculo" EnableClientScript="false" />
            </div>

            <div class="form-group help-block">
                <label class="label-default-subTitle">Asientos Disponibles</label>
                <asp:TextBox runat="server" ID="tbAsientos" PlaceHolder="Ejemplo: 4" CssClass="form-control" Width="175" />
                <asp:CustomValidator runat="server" ID="cvAsientos" OnServerValidate="cvAsientos_ServerValidate" ValidationGroup="GroupRegistrarVehiculo" EnableClientScript="false" />
            </div>

            <div class="form-group help-block">
                <asp:Button Text="Registrar" runat="server" ID="btnRegistrar" CssClass="boton_personalizado" OnClick="btnRegistrar_Click" />
                <asp:Button Text="Modificar" runat="server" ID="btnModificar" CssClass="boton_personalizado" OnClick="btnModificar_Click" />
            </div>
        </div>

    </div>
</div>
</asp:Content>
