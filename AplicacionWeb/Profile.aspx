<%@ Page Title="" Language="C#" MasterPageFile="~/Gestor.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="AplicacionWeb.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row center-row">
                <asp:Image ID="imgProfile" runat="server" CssClass="imgperfil accordion-body" />
                <div class="card text-center bg-black bg-opacity-50 w-65 mt-5">
                    <div class="card-body mt-5">
                        <asp:Panel ID="panelPerfil" runat="server">
                            <div class="row">
                                <div class="col col-end">
                                    <div class="mb-3">
                                        <asp:Label ID="Label6" CssClass="form-label" runat="server" Text="Nombre:"></asp:Label>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="Label7" CssClass="form-label" runat="server" Text="Apellido:"></asp:Label>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="Label8" CssClass="form-label" runat="server" Text="Email:"></asp:Label>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="Label9" CssClass="form-label" runat="server" Text="Pass"></asp:Label>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="Label10" CssClass="form-label" runat="server" Text="Servicios Almacenados:"></asp:Label>
                                    </div>
                                </div>
                                <div class="col col-start">
                                    <div class="mb-3">
                                        <asp:Label ID="lblNombre" CssClass="form-label" runat="server" Text="usuario.Nombre"></asp:Label>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="lblApellido" CssClass="form-label" runat="server" Text="usuario.Nombre"></asp:Label>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="lblEmail" CssClass="form-label" runat="server" Text="usuario.Nombre"></asp:Label>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="lblPass" CssClass="form-label" runat="server" Text="usuario.Nombre"></asp:Label>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="lblServicios" CssClass="form-label" runat="server" Text="usuario.Nombre"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="panelValidacion" runat="server" Visible="false">
                            <div class="col">
                                <h3>Debido a que accederá a datos sensibles, necesitamos que introduzca su email y contraseña para validar su identidad</h3>
                                <div class="mb-3 center-col">
                                    <label class="form-label">Introduzca su email</label>
                                    <asp:TextBox ID="txtVEmail" CssClass="form-control w-50" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-3 center-col">
                                    <label class="form-label">Introduzca su contraseña</label>
                                    <asp:TextBox ID="txtVPass" TextMode="Password" CssClass="form-control w-50" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>
                        <%if (Status)
                            {


                        %>
                        <asp:LinkButton ID="lnkCambiarImagen" runat="server" CssClass="cambiar-imagen" OnClick="lnkCambiarImagen_Click"><i class="fa fa-sync-alt"></i></asp:LinkButton>
                        <div class="row">
                            <div class="col">
                                <div class="mb-3 center-col">
                                    <asp:Label ID="Label1" runat="server" Text="Nombre:" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control w-50"></asp:TextBox>
                                </div>
                                <div class="mb-3 center-col">
                                    <asp:Label ID="Label2" runat="server" Text="Apellido:" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control w-50"></asp:TextBox>
                                </div>
                                <%if (EditEmail)
                                    {

                                %>
                                <div class="mb-3 center-col">
                                    <asp:Label ID="Label3" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control w-50"></asp:TextBox>
                                </div>
                                <asp:Button ID="btnCancelarEditEmail" runat="server" Text="Cancelar" CssClass="btn btn-outline-light btn-primary w-50 mb-3" OnClick="btnCancelarEditEmail_Click" />
                                <%}
                                    else
                                    { %>
                                <div class="mb-3 center-col">
                                    <asp:Button ID="btnEditEmail" runat="server" Text="Editar Email" CssClass="btn btn-outline-light btn-primary w-50" OnClick="btnEditEmail_Click" />
                                </div>
                                <%}  %>
                                <%if (EditPass)
                                    {

                                %>
                                <div class="mb-3 center-col">
                                    <asp:Label ID="Label4" runat="server" Text="Contraseña:" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtPass" TextMode="Password" runat="server" CssClass="form-control w-50"></asp:TextBox>
                                </div>
                                <div class="mb-3 center-col">
                                    <asp:Label ID="Label11" runat="server" Text="Repetir Contraseña:" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtRepetir" TextMode="Password" runat="server" CssClass="form-control w-50"></asp:TextBox>
                                </div>
                                <asp:Button ID="btnCancelarEditPass" runat="server" Text="Cancelar" CssClass="btn btn-outline-light btn-primary w-50 mb-3" OnClick="btnCancelarEditPass_Click" />
                                <%}
                                    else
                                    {  %>
                                <div class="mb-3 center-col">
                                    <asp:Button ID="btnEditPass" runat="server" Text="Editar Contraseña" CssClass="btn btn-outline-light btn-primary w-50" OnClick="btnEditPass_Click" />
                                </div>
                                <%} %>
                            </div>
                        </div>
                        <%}%>
                    </div>
                    <div class="card-footer text-muted">
                        <asp:Panel runat="server" ID="loader" ClientIDMode="Static" CssClass="display-none"></asp:Panel>
                        <%if (!Status)
                            {

                        %>
                        <asp:Button ID="btnEditar" ClientIDMode="Static" runat="server" Text="✍️ Editar Perfil" CssClass="btn btn-outline-light btn-primary w-160" OnClick="btnEditar_Click" OnClientClick="disableButton(this)" />
                        <%if (btnEditar.Text == "✍️ Editar Perfil")
                            {

                        %>
                        <a href="AddService.aspx" class="btn btn-outline-light btn-primary ms-3 w-160">Añadir Servicio</a>
                        <a href="MyServices.aspx" class="btn btn-outline-light btn-primary ms-3 w-160">Ver Servicios</a>
                        <%}
                            else
                            { %>
                        <asp:Button ID="btnCancelarE" ClientIDMode="Static" runat="server" Text="Cancelar" CssClass="btn btn-outline-light btn-danger w-160 ms-3" OnClick="btnCancelarE_Click" />
                        <%}  %>
                        <%}
                            else
                            {


                        %>
                        <%if (!EliminarCuenta)
                            {  %>
                        <asp:Button ID="btnGuardar" runat="server" Text="💾 Guardar" CssClass="btn btn-outline-light btn-primary w-160" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnCancelarCambios" runat="server" Text="Cancelar" CssClass="btn btn-outline-light btn-danger ms-3 w-160" OnClick="btnCancelarCambios_Click" />
                        <asp:Button ID="btnEliminarCuenta" runat="server" Text="Eliminar Cuenta" CssClass="btn btn-outline-light btn-danger ms-3 w-160" OnClick="btnEliminarCuenta_Click" />
                        <%}
                            else
                            {%>
                        <asp:Label ID="Label5" runat="server" Text="Esta seguro que desea eliminar la cuenta? Esta accion no se puede revertir" CssClass="text-light"></asp:Label>
                        <div class="row center-row">
                            <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" CssClass="btn btn-success w-160" />
                            <asp:Button ID="btnCancelarEliminacion" runat="server" Text="Cancelar" OnClick="btnCancelarEliminacion_Click" CssClass="btn btn-danger w-160 ms-3" />
                        </div>
                        <%} %>
                        <%}   %>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <%-- ModalValidacion --%>
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
                            <asp:Button ID="btnValidar" ClientIDMode="Static" CssClass="btn btn-outline-light btn-primary w-160" runat="server" Text="Validar Email" OnClick="btnValidar_Click" OnClientClick="limpiarCodigo('txtVerificar')" />
                        </div>
                        <div class="col mb-3">
                            <asp:Button ID="btnCancelar" ClientIDMode="Static" CssClass="btn btn-outline-light btn-danger w-160" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
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
    <%-- Modal imagenes Perfil --%>
    <asp:Panel ID="modalImg" runat="server" CssClass="modalImg text-center">
        <div class="row center-row">
            <asp:Repeater ID="repImg" runat="server">
                <ItemTemplate>
                    <asp:ImageButton ID="imgPerfil" ImageUrl='<%#Eval("Url") %>' AlternateText='<%#Eval("Id") %>' runat="server" OnClick="imgPerfil_Click" Width="180px" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="row center-row h-25 align-content-center">
            <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" OnClick="btnCerrar_Click" CssClass="buttonCancelar w-160" Style="display: block" />
        </div>
    </asp:Panel>
    <asp:Button ID="btnImg" runat="server" Text="Button" Style="display: none" />
    <ajax:ModalPopupExtender runat="server" ID="ajxImg" OkControlID="imgPerfil" CancelControlID="btnCerrar"
        TargetControlID="btnImg" PopupControlID="modalImg" BackgroundCssClass="bg-black bg-opacity-50">
    </ajax:ModalPopupExtender>
</asp:Content>
