<%@ Page Title="" Language="C#" MasterPageFile="~/Gestor.Master" AutoEventWireup="true" CodeBehind="MyServices.aspx.cs" Inherits="AplicacionWeb.MyServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="loaderBG" class="display-none">
                Cargando<span class="dot1">.</span><span class="dot2">.</span><span class="dot3">.</span><asp:Panel runat="server" ID="loader" ClientIDMode="Static" CssClass="display-none "></asp:Panel>
            </div>
            <div class="row row-cols-6 g-1">
                <asp:Repeater ID="repServicios" runat="server">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgAcceso" ImageUrl='<%#Eval("Servicio.Imagen") %>' AlternateText='<%#Eval("Id") %>' CssClass="imagen-ver" runat="server" OnClick="imgAcceso_Click" OnClientClick="loader(this)" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel ID="modalValidacion" CssClass="modalAbrir text-center" runat="server">
        <div class="card bg-black">
            <div class="card-body">
                <p class="form-label">Se le ha enviado un código de validación al email ingresado, ingreselo a continuación</p>
            </div>
            <div class="mb-3 center-row">
                <asp:TextBox ID="txtVerificar" ClientIDMode="Static" CssClass="form-control w-75" placeholder="Ingrese el código de validación" runat="server" onkeypress="return forzarMayus(event)"></asp:TextBox>
            </div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Label ID="lblErrorVerificar" CssClass="danger" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnValidar" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <div class="mb-3">
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="row center-row">
                        <div class="col mb-3">
                            <asp:Button ID="btnValidar" ClientIDMode="Static" CssClass="btn btn-outline-light btn-primary w-160" runat="server" Text="Validar Email" OnClick="btnValidar_Click" />
                        </div>
                        <div class="col mb-3">
                            <asp:Button ID="btnCancelar" ClientIDMode="Static" CssClass="btn btn-outline-light btn-danger w-160" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" OnClientClick="limpiar()" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>
    <asp:Button ID="btnMostrarModal" runat="server" Text="Button" Style="display: none" />
    <ajax:ModalPopupExtender runat="server" ID="ajxValidacion" OkControlID="btnCancelar" CancelControlID="btnCancelar"
        TargetControlID="btnMostrarModal" PopupControlID="modalValidacion" BackgroundCssClass="bg-black bg-opacity-75">
    </ajax:ModalPopupExtender>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <asp:Panel ID="modalAcceso" runat="server" CssClass="bg-black bg-opacity-75 modal-servicios" Visible="false">
                <div class="card bg-black modalNotificar" style="width: 18rem;">
                    <asp:Image ID="imgServicio" CssClass="card-img-top mb-3" AlternateText="" runat="server" />
                    <div class="card-body center-col p-0">
                        <asp:Label ID="lblNombre" runat="server" CssClass="h4" Text="Label"></asp:Label>
                        <p class="card-text center-col">Estas son sus credenciales para<asp:Label ID="lblServicio" ClientIDMode="Static" CssClass="card-text" runat="server" Text="Label"></asp:Label></p>
                        <div class="accordion w-100 smaller-700 mb-4" id="accordionPanelsStayOpenExample">
                            <div class="accordion-item bg-black text-bg-dark">
                                <h2 class="accordion-header" id="panelsStayOpen-headingOne">
                                    <button class="accordion-button bg-black text-bg-dark collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseOne" aria-expanded="false" aria-controls="panelsStayOpen-collapseOne">
                                        Mostrar Usuario
                                    </button>
                                </h2>
                                <div id="panelsStayOpen-collapseOne" class="accordion-collapse collapse" aria-labelledby="panelsStayOpen-headingOne">
                                    <div class="accordion-body">
                                        <asp:Label ID="lblUsuario" runat="server" CssClass="card-text" Text="Label"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="accordion-item bg-black text-bg-dark">
                                <h2 class="accordion-header" id="panelsStayOpen-headingTwo">
                                    <button class="accordion-button collapsed bg-black text-bg-dark" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseTwo" aria-expanded="false" aria-controls="panelsStayOpen-collapseTwo">
                                        Mostrar Contraseña
                                    </button>
                                </h2>
                                <div id="panelsStayOpen-collapseTwo" class="accordion-collapse collapse" aria-labelledby="panelsStayOpen-headingTwo">
                                    <div class="accordion-body">
                                        <asp:Label ID="lblPass" runat="server" CssClass="card-text" Text="Label"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-primary w-100 mb-2" Style="border-radius: 0;" OnClick="btnEditar_Click" />
                            <asp:Button ID="btnCambiar" runat="server" Text="Cambiar Contraseña" CssClass="btn btn-primary w-100 mb-2" Style="border-radius: 0;" OnClick="btnCambiar_Click" Visible="false" />
                            <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" CssClass="btn btn-primary w-100 mb-2" Style="border-radius: 0;" OnClick="btnCerrar_Click" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger w-100" Style="border-top-right-radius: 0; border-top-left-radius: 0;" OnClick="btnEliminar_Click" />
                        </div>
                    </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnAcceso" runat="server" Text="Button" Style="display: none" />
    <ajax:ModalPopupExtender runat="server" ID="ajxAcceso" OkControlID="btnCerrar" CancelControlID="btnCerrar"
        TargetControlID="btnAcceso" PopupControlID="modalAcceso" BackgroundCssClass="bg-black bg-opacity-75">
    </ajax:ModalPopupExtender>
    <%-- Modal confirmacion --%>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
            <asp:Panel ID="modalConfirmación" runat="server" Visible="false" CssClass="modal-servicios bg-black bg-opacity-75">
                <div class="m-content text-light text-center">
                    <div class="card-body center-col">
                        <div class="swal-icon swal-icon--warning">
                            <span class="swal-icon--warning__body">
                                <span class="swal-icon--warning__dot"></span>
                            </span>
                        </div>
                        <div class="row mb-3">
                            <p class="h4 mt-2">Confirmar Eliminación</p>
                        </div>
                        <div class="row">
                            <asp:Label ID="lblConfirmar" runat="server" Text="¿Está seguro que desea eliminar el servicio (servicio) vinculado a (email)? Esta acción no se puede revertir, ¿desea continuar?"></asp:Label>
                        </div>
                        <div class="card-footer center-row mt-4">
                            <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-outline-light btn-primary w-160" OnClick="btnConfirmar_Click" />
                            <asp:Button ID="btnCancelarEliminacion" runat="server" Text="Cancelar" CssClass="btn btn-outline-light btn-danger w-160 ms-3" OnClick="btnCancelarEliminacion_Click" />
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnConfirmacion" runat="server" Text="Button" Style="display: none" />
    <ajax:ModalPopupExtender runat="server" ID="ajxConfirmar" OkControlID="btnConfirmar" CancelControlID="btnCancelarEliminacion"
        TargetControlID="btnConfirmacion" PopupControlID="modalConfirmación" BackgroundCssClass="bg-black bg-opacity-75">
    </ajax:ModalPopupExtender>
</asp:Content>
