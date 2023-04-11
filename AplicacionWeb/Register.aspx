<%@ Page Title="" Language="C#" MasterPageFile="~/Gestor.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AplicacionWeb.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="form-box">
                    <div class="form-value">
                        <form action=".">
                            <h2>Registrese</h2>
                            <%if (!StatusV || !StatusP)
                                {  %>
                            <div class="imputbox">
                                <ion-icon name="mail-outline"></ion-icon>
                                <asp:TextBox ID="txtEmail" CssClass="input" runat="server"></asp:TextBox>
                                <label for="">Email</label>
                            </div>
                            <%if (StatusV)
                                {
                            %>
                            <div class="imputbox">
                                <asp:TextBox ID="txtPass" ClientIDMode="Static" CssClass="input" TextMode="Password" runat="server" Visible="false"></asp:TextBox>
                                <label for="">Contraseña</label>
                                <button id="mostrar" onclick="mostrarPass('txtPass', 'icono')" type="button" class="boton-mostrar"><i id="icono" class="fa fa-eye-slash"></i></button>
                            </div>
                            <div class="imputbox">
                                <asp:TextBox ID="txtRepetir" ClientIDMode="Static" TextMode="Password" CssClass="input" runat="server" Visible="false"></asp:TextBox>
                                <label for="">Contraseña</label>
                                <button id="mostrarR" onclick="mostrarPass('txtRepetir', 'iconoR')" type="button" class="boton-mostrar"><i id="iconoR" class="fa fa-eye-slash"></i></button>
                            </div>
                            <%}                                    %>
                            <%} %>
                            <%if (StatusP)
                                { %>
                            <div class="imputbox">
                                <asp:TextBox ID="txtNombre" CssClass="input" runat="server"></asp:TextBox>
                                <label for="">Nombre</label>
                            </div>
                            <asp:Label ID="lblErrorNombre" runat="server" Text="" Visible="false" CssClass="danger"></asp:Label>
                            <div class="imputbox">
                                <asp:TextBox ID="txtApellido" CssClass="input" runat="server"></asp:TextBox>
                                <label for="">Apellido</label>
                            </div>
                            <asp:Label ID="lblErrorApellido" runat="server" Text="input" Visible="false" CssClass="danger"></asp:Label>
                            <div class="imputbox">
                                <asp:TextBox ID="txtFecha" TextMode="Date" CssClass="input" runat="server"></asp:TextBox>
                                <label for="">Fecha de nacimiento</label>
                            </div>
                            <asp:Label ID="lblErrorFecha" runat="server" Text="" Visible="false" CssClass="danger"></asp:Label>
                            <%} %>
                            <div class="row">
                                <div class="loader-container">
                                    <span id="loader"></span>
                                </div>
                                <%if (!Status || !StatusV || !StatusP)
                                    {

                                %>
                                <div class="col flex-end me-3">
                                    <asp:Button ID="btnSiguiente" ClientIDMode="Static" CssClass="button" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click" OnClientClick="disableButtonR(this)" />
                                </div>
                                <%}
                                    else if (Status && StatusV && StatusP)
                                    {  %>
                                <div class="col flex-end me-3">
                                    <asp:Button ID="btnRegistrarse" CssClass="button" runat="server" Text="Registrarse" OnClick="btnRegistrarse_Click" />
                                </div>
                                <%} %>
                                <div class="col flex-start">
                                    <a href="Default.aspx" class="buttonCancelar">Cancelar</a>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
    <asp:Panel ID="modalValidacion" CssClass="modalAbrir text-center" runat="server">
        <div class="card bg-black">
            <div class="card-body">
                <p class="form-label">Se le ha enviado un código de validación al email ingresado, ingreselo a continuación</p>
            </div>
            <div class="mb-3 center-row">
                <asp:TextBox ID="txtVerificar" CssClass="form-control w-75" placeholder="Ingrese el código de validación" runat="server" onkeypress="return forzarMayus(event)"></asp:TextBox>
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
</asp:Content>
