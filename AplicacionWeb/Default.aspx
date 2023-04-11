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
                    Comenzemos!
                </button>
            </h2>
            <div id="flush-collapseTwo" class="accordion-collapse collapse" aria-labelledby="flush-headingTwo" data-bs-parent="#accordionFlushExample">
                <div class="accordion-body">Para comenzar, deberá iniciar sesión si tiene una cuenta registrada en esta web, una vez iniciada la sesión usted podrá Agregar un servicio, ver los servicios que usted tiene agregados, y allí podra modificar o eliminar un servicio. Ir a la pagina de perfil donde podrá modificar sus datos.</div>
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
                    Modificar o eliminar un servicio:
                </button>
            </h2>
            <div id="flush-collapseFour" class="accordion-collapse collapse" aria-labelledby="flush-headingFour" data-bs-parent="#accordionFlushExample">
                <div class="accordion-body">Si desea modificar o eliminar un servicio de su lista, debe hacer click en el boton "Ver servicios" allí le aparecerá un listado de servicios que usted tiene guardado, para modificarlo haga click en la imagen del servicio o en el boton modificar servicio, y para eliminarlo, haga click en el boton, eliminar servicio.</div>
            </div>
        </div>
        <div class="accordion-item bg-black text-bg-dark bg-opacity-75">
            <h2 class="accordion-header" id="flush-headingFive">
                <button class="accordion-button collapsed bg-black text-bg-dark" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseFive" aria-expanded="false" aria-controls="flush-collapseFive">
                    Acceso rapido:
                </button>
            </h2>
            <div id="flush-collapseFive" class="accordion-collapse collapse" aria-labelledby="flush-headingFive" data-bs-parent="#accordionFlushExample">
                <div class="accordion-body">Si usted hace click en el boton "Ver servicios" podra ver la lista de servicios que usted guardó, para acceder rapidamente a ellos sin tener que hacer click en el boton "Ver servicios", podrá hacer click en el icono de corazón, lo cual agregara el servicio en la parte superior de la pantalla, dandole la posibilidad de solicitar los datos de acceso de ese servicio añadido.</div>
            </div>
        </div>
        <div class="accordion-item bg-black text-bg-dark bg-opacity-75">
            <h2 class="accordion-header" id="flush-headingSix">
                <button class="accordion-button collapsed bg-black text-bg-dark" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseSix" aria-expanded="false" aria-controls="flush-collapseSix">
                    Ver usuario y contraseña de un servicio:
                </button>
            </h2>
            <div id="flush-collapseSix" class="accordion-collapse collapse" aria-labelledby="flush-headingSix" data-bs-parent="#accordionFlushExample">
                <div class="accordion-body">Ya sea en el acceso rapido o en el boton "Ver servicios" y seleccionando el servicio que desea, se abrirá una nueva ventana con los datos ocultos, para verlos deberá hacer click en "Solicitar acceso a usuario y contraseña", se le enviará un código al email registrado, deberá colocar el código que se le brindó y confirmar los datos para asegurarnos de que realmente es usted. Si todo salió bien, se le ofrecerá la opción de ver en la pagina o solicitar el envio de las credenciales por email, puede elegir ambas si así lo desea.</div>
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

