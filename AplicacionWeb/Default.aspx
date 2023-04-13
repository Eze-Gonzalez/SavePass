<%@ Page Title="" Language="C#" MasterPageFile="~/Gestor.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AplicacionWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="center-row">Hola!</h3>
    <div class="accordion accordion-flush" id="accordionFlushExample">
        <div class="accordion-item bg-black text-bg-dark bg-opacity-75">
            <h2 class="accordion-header" id="flush-headingOne">
                <button class="accordion-button collapsed bg-black text-bg-dark" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseOne" aria-expanded="false" aria-controls="flush-collapseOne">
                    Explicación General
                </button>
            </h2>
            <div id="flush-collapseOne" class="accordion-collapse collapse show" aria-labelledby="flush-headingOne" data-bs-parent="#accordionFlushExample">
                <div class="accordion-body">Aqui podrá almacenar el usuario/email y contraseña de algun servicio que quiera, para empezar, deberá iniciar sesión o si no esta registrado, podra hacerlo si así lo desea.</div>
                <div class="accordion-body">⚠️Se recomienda <b>NO</b> almacenar ninguna cuenta con datos sensibles (Bancos, tarjetas, entidades financieras, etc) ni los datos del mail, ya que para su seguridad, se enviará un codigo de verificación cuando solicite el inicio de sesón y el acceso a sus cuentas.</div>
            </div>
        </div>
        <div class="accordion-item bg-black text-bg-dark bg-opacity-75">
            <h2 class="accordion-header" id="flush-headingTwo">
                <button class="accordion-button collapsed bg-black text-bg-dark" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseTwo" aria-expanded="false" aria-controls="flush-collapseTwo">
                    Comencemos!
                </button>
            </h2>
            <div id="flush-collapseTwo" class="accordion-collapse collapse" aria-labelledby="flush-headingTwo" data-bs-parent="#accordionFlushExample">
                <div class="accordion-body">Para comenzar, deberá iniciar sesión si tiene una cuenta registrada en esta web, una vez iniciada la sesión usted podrá Agregar un servicio, ver los servicios que usted tiene agregados, y allí podra modificar o eliminar un servicio. A demás, podrá ir a la pagina de perfil donde podrá modificar sus datos.</div>
            </div>
        </div>
        <div class="accordion-item bg-black text-bg-dark bg-opacity-75">
            <h2 class="accordion-header" id="flush-headingThree">
                <button class="accordion-button collapsed bg-black text-bg-dark" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseThree" aria-expanded="false" aria-controls="flush-collapseThree">
                    Agregar un servicio:
                </button>
            </h2>
            <div id="flush-collapseThree" class="accordion-collapse collapse" aria-labelledby="flush-headingThree" data-bs-parent="#accordionFlushExample">
                <div class="accordion-body">Para agregar un servicio puede hacer click en el boton "Agregar un servicio", eso lo llevará hasta una nueva ventana, donde podrá rellenar los datos necesarios para agregar uno nuevo en su lista</div>
            </div>
        </div>
        <div class="accordion-item bg-black text-bg-dark bg-opacity-75">
            <h2 class="accordion-header" id="flush-headingFour">
                <button class="accordion-button collapsed bg-black text-bg-dark" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseFour" aria-expanded="false" aria-controls="flush-collapseFour">
                    Ver usuario y contraseña de un servicio:
                </button>
            </h2>
            <div id="flush-collapseFour" class="accordion-collapse collapse" aria-labelledby="flush-headingFour" data-bs-parent="#accordionFlushExample">
                <div class="accordion-body">Al hacer click en cualquier boton de ver servicios, será redirigido a la pagina donde mostrará, en caso de tener alguno, los servicios que usted tiene almacenados, al hacer click en algún servicio, se le enviará de manera automática un código de validación a su email registrado, una vez intoducido el código correctamente, podra ver los detalles del servicio requerido.</div>
            </div>
        </div>
        <div class="accordion-item bg-black text-bg-dark bg-opacity-75">
            <h2 class="accordion-header" id="flush-headingFive">
                <button class="accordion-button collapsed bg-black text-bg-dark" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseFive" aria-expanded="false" aria-controls="flush-collapseFive">
                    Modificar o eliminar un servicio:
                </button>
            </h2>
            <div id="flush-collapseFive" class="accordion-collapse collapse" aria-labelledby="flush-headingFive" data-bs-parent="#accordionFlushExample">
                <div class="accordion-body">Si desea modificar o eliminar un servicio de su lista, debe hacer click en el boton "Ver servicios", allí si usted almacenó algun servicio, verá una lista de los servicios almacenados, haga click en el servicio deseado y se le enviará un código de verificación a su email, una vez ingresado el codigo correctamente, podrá ver el servicio con los botones de modificar o eliminar el servicio.</div>
            </div>
        </div>
    </div>
    <div class="row mt-4">
        <%if (Validaciones.Validar.sesion(Session["usuario"]))
            { %>
        <div class="col center-row">
            <asp:LinkButton ID="lnkAdd" runat="server" CssClass="w-170 btn btn-outline-light btn-secondary" OnClick="lnkAdd_Click">Agregar un servicio</asp:LinkButton>
        </div>
        <div class="col center-row">
            <a href="MyServices.aspx" class="w-170 btn btn-outline-light btn-secondary">Ver servicios</a>
        </div>
        <div class="col center-row">
            <a href="Profile.aspx" class="w-170 btn btn-outline-light btn-secondary">Ir a Mi Perfil</a>
        </div>
        <%}  %>
    </div>
</asp:Content>

