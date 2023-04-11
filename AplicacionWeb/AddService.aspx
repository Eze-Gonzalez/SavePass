<%@ Page Title="" Language="C#" MasterPageFile="~/Gestor.Master" AutoEventWireup="true" CodeBehind="AddService.aspx.cs" Inherits="AplicacionWeb.AddService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col">
                    <div class="mb-3">
                        <label class="form-label">Servicio</label>
                        <asp:DropDownList ID="ddlServicios" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlServicios_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <asp:Panel ID="panelOtros" runat="server" Visible="false">
                        <div class="mb-3">
                            <label class="form-label">Nombre de Servicio:</label>
                            <asp:TextBox ID="txtNServicio" ClientIDMode="Static" CssClass="form-control" runat="server" placeholder="Ingrese el nombre del servicio"></asp:TextBox>
                        </div>
                    </asp:Panel>
                    <div class="mb-3">
                        <asp:Label ID="lblUsuario" CssClass="form-label" runat="server" Text="Usuario o email de"></asp:Label>
                        <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server" placeholder="Ingrese el nombre de usuario o email del servicio"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblPass" CssClass="form-label" runat="server" Text="Contraseña de"></asp:Label>
                        <div class="row">
                            <asp:TextBox ID="txtPass" ClientIDMode="Static" CssClass="form-control me-2 ml-11px w-85" TextMode="Password" runat="server" placeholder="Ingrese la contraseña del servicio"></asp:TextBox>
                            <button id="mostrar" onclick="mostrarPass('txtPass', 'icono')" type="button" class="btn btn-light w-10"><i id="icono" class="fa fa-eye-slash"></i></button>
                        </div>
                    </div>
                </div>
                <div class="col center-col">
                    <div class="mb-3">
                        <asp:Image ID="imgServicio" CssClass="imagen-Servicio" runat="server" />
                    </div>
                </div>
                <div class="row mt-3 space-evenly">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Servicio" CssClass="btn btn-outline-light btn-primary w-160" OnClick="btnAgregar_Click" />
                    <a href="Profile.aspx" class="btn btn-outline-light btn-danger w-160">Cancelar</a>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAgregar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
