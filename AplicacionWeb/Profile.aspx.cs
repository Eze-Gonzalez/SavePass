using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helpers;
using Validaciones;
using Servicios;
using Datos;
using System.Web.Services.Description;
using System.Threading;

namespace AplicacionWeb
{
    public partial class Profile : System.Web.UI.Page
    {
        private string codigo;
        private string titulo;
        private string mensaje;
        private bool status;
        private string script;
        private bool verificar;
        public bool Status { get; set; }
        public bool EliminarCuenta { get; set; }
        public bool EditEmail { get; set; }
        public bool EditPass { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Validar.sesion(Session["usuario"]))
                {
                    Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
                    lblNombre.Text = usuario.Nombre;
                    lblApellido.Text = usuario.Apellido;
                    string email = usuario.Email;
                    string pass = usuario.Pass;
                    Helper.codificar(ref email, ref pass);
                    lblEmail.Text = email;
                    lblPass.Text = pass;
                    lblServicios.Text = usuario.ServiciosTotales.ToString();
                    if (IsPostBack)
                    {
                        string imagen = imgProfile.ImageUrl;
                        imgProfile.ImageUrl = imagen;
                    }
                    else
                        imgProfile.ImageUrl = DatosImagenPerfil.traerImagen(usuario.ImagenPerfil.Id);
                }
                if (!IsPostBack)
                {
                    EditEmail = false;
                    EditPass = false;
                    repImg.DataSource = DatosImagenPerfil.listar();
                    repImg.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("ErrorCode", "Hubo un problema al cargar la página");
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

                if (btnEditar.Text == "✍️ Editar Perfil")
                {
                    panelPerfil.Visible = false;
                    panelValidacion.Visible = true;
                    btnEditar.Text = "Verificar";
                }
                else if (!Validar.campoEmail(txtVEmail.Text))
                {
                    titulo = "Email no válido";
                    mensaje = "El email ingresado no es válido o el campo esta vacío, por favor ingrese su email.";
                    script = string.Format("crearAlerta({0},'{1}','{2}');", false.ToString().ToLower(), titulo, mensaje);
                    ScriptManager.RegisterStartupScript(this, GetType(), "crearAlerta", script, true);
                }
                else if (!Validar.campoPass(txtVPass.Text))
                {
                    titulo = "Contraseña no válida";
                    mensaje = "La contraseña ingresada no es válida o el campo esta vacío, por favor ingrese su contraseña.";
                    script = string.Format("crearAlerta({0},'{1}','{2}');", false.ToString().ToLower(), titulo, mensaje);
                    ScriptManager.RegisterStartupScript(this, GetType(), "crearAlerta", script, true);
                }
                else
                {
                    Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
                    if (txtVEmail.Text == usuario.Email && txtVPass.Text == usuario.Pass)
                    {
                        DatosValidacionEmail.eliminarCodigo(usuario.Email);
                        codigo = Helper.generarCodigo();
                        DatosValidacionEmail.cargarCodigo(txtVEmail.Text, codigo);
                        ServicioEmail servicio = new ServicioEmail();
                        servicio.armarEmail(usuario.Email, "Codigo de validación", Helper.cargarCuerpo(usuario.Email, codigo), "validaciones@claves.com");
                        servicio.enviarEmail();
                        ajxValidacion.Show();
                    }
                    else
                    {
                        titulo = "Credenciales incorrectas";
                        mensaje = "Usuario o contraseña incorrectos, por favor ingrese sus credenciales de acceso.";
                        script = string.Format("crearAlerta({0},'{1}','{2}');", false.ToString().ToLower(), titulo, mensaje);
                        ScriptManager.RegisterStartupScript(this, GetType(), "crearAlerta", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                bool edit = Session["validacionEdit"] != null ? (bool)Session["validacionEdit"] : false;
                bool editP = Session["editpass"] != null ? (bool)Session["editpass"] : false;
                if (edit)
                {
                    string email = Session["email"] != null ? Session["email"].ToString().ToLower() : string.Empty;
                    Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;

                    if (!Validar.campo(txtVerificar.Text))
                    {
                        lblErrorVerificar.Visible = true;
                        lblErrorVerificar.Text = "El código ingresado no es valido, no debe contener espacios y debe tener 8 dígitos, intente nuevametne.";
                        Status = true;
                    }
                    else if (!Validar.codigo(txtVerificar.Text, email))
                    {
                        lblErrorVerificar.Visible = true;
                        lblErrorVerificar.Text = "El código ingresado no corresponde al enviado a su email, por favor, ingrese el código enviado a su email.";
                        Status = true;
                    }
                    else
                    {
                        if (Validar.camposRequeridos(txtNombre.Text, txtApellido.Text, ref titulo, ref mensaje, ref status))
                        {
                            if (status)
                            {
                                usuario.Email = email;
                                DatosUsuario datos = new DatosUsuario();
                                datos.actualizarDatos(usuario);
                                lblNombre.Text = usuario.Nombre;
                                lblApellido.Text = usuario.Apellido;
                                email = usuario.Email;
                                string pass = usuario.Pass;
                                Helper.codificar(ref email, ref pass);
                                lblEmail.Text = email;
                                lblPass.Text = pass;
                                imgProfile.ImageUrl = DatosImagenPerfil.traerImagen(usuario.ImagenPerfil.Id);
                                Image imgMaster = (Image)Master.FindControl("imgPerfil");
                                Label lblMaster = (Label)Master.FindControl("lblPerfil");
                                imgMaster.ImageUrl = imgProfile.ImageUrl + DateTime.Now.Ticks.ToString();
                                lblMaster.Text = usuario.Nombre;
                                Status = false;
                                panelPerfil.Visible = true;
                                btnEditar.Text = "✍️ Editar Perfil";
                                ajxValidacion.Hide();
                            }
                        }
                    }
                    script = string.Format("crearAlerta({0},'{1}','{2}');", status.ToString().ToLower(), titulo, mensaje);
                    ScriptManager.RegisterStartupScript(this, GetType(), "crearAlerta", script, true);
                }
                else
                {
                    if (!Validar.campo(txtVerificar.Text))
                    {
                        lblErrorVerificar.Visible = true;
                        lblErrorVerificar.Text = "El código ingresado no es valido, no debe contener espacios y debe tener 8 dígitos, intente nuevametne.";
                    }
                    else if (!Validar.codigo(txtVerificar.Text, txtVEmail.Text))
                    {
                        lblErrorVerificar.Visible = true;
                        lblErrorVerificar.Text = "El código ingresado no corresponde al enviado a su email, por favor, ingrese el código enviado a su email.";
                    }
                    else
                    {
                        Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
                        lblErrorVerificar.Visible = false;
                        panelValidacion.Visible = false;
                        Status = true;
                        ajxValidacion.Hide();
                        txtVerificar.Text = string.Empty;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;
                    }
                }
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "limpiar", "limpiar()", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["editemail"] != null)
                {
                    Status = true;
                    ajxValidacion.Hide();
                    modalValidacion.Visible = false;
                    txtVEmail.Text = string.Empty;
                }
                else
                {
                    ajxValidacion.Hide();
                    modalValidacion.Visible = false;
                    txtVEmail.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelarE_Click(object sender, EventArgs e)
        {
            try
            {
                txtVEmail.Text = "";
                panelPerfil.Visible = true;
                panelValidacion.Visible = false;
                btnEditar.Text = "✍️ Editar Perfil";
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                txtVEmail.Text = "";
                btnEditar.Text = "✍️ Editar Perfil";
                imgProfile.ImageUrl = DatosImagenPerfil.traerImagen(Session["usuario"] != null ? ((Usuario)Session["usuario"]).ImagenPerfil.Id : 0);
                panelPerfil.Visible = true;
                panelValidacion.Visible = false;
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                Status = true;
                EliminarCuenta = true;
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Session["usuario"] != null ? ((Usuario)Session["usuario"]).Id : 0;
                DatosDatosAcceso datosA = new DatosDatosAcceso();
                datosA.eliminarUsuario(id);
                DatosUsuario datos = new DatosUsuario();
                datos.eliminarCuenta(id);
                Session.Clear();
                Response.Redirect("Default.aspx");
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                Status = true;
                EliminarCuenta = false;
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EditEmail = Session["editemail"] != null ? (bool)Session["editemail"] : false;
                EditPass = Session["editpass"] != null ? (bool)Session["editpass"] : false;
                if (Validar.camposRequeridos(txtNombre.Text, txtApellido.Text, ref titulo, ref mensaje, ref status))
                {
                    Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
                    usuario.Nombre = txtNombre.Text;
                    usuario.Apellido = txtApellido.Text;
                    usuario.ImagenPerfil.Id = Session["id"] != null ? (int)Session["id"] : 1;
                    if (EditPass)
                    {
                        if (txtPass.Text != usuario.Pass)
                        {
                            if (Validar.campoPass(txtPass.Text))
                            {
                                if (txtRepetir.Text == txtPass.Text)
                                {
                                    usuario.Pass = txtPass.Text;
                                    status = true;
                                }
                                else
                                {
                                    titulo = "Las contraseñas no coinciden";
                                    mensaje = "Las contraseñas ingresadas no coinciden, revise el formulario e intente nuevamente, verfifque que las contraseñas sean iguales.";
                                    status = false;
                                }
                            }
                            else
                            {
                                titulo = "Contraseña no válida";
                                mensaje = "La contraseña no es válida, por favor ingrese una contraseña de 6 a 20 caracteres, con al menos una mayúscula, una minúscula, un número y un símbolo.";
                                status = false;
                            }
                        }
                        else
                        {
                            titulo = "Contraseña en uso";
                            mensaje = "La contraseña ingresada, es la misma que esta usando actualmente, por favor, cambie la contraseña.";
                            status = false;
                        }
                    }
                    if (EditEmail)
                    {
                        if (txtEmail.Text != usuario.Email)
                        {
                            if (!Validar.emailRegistrado(txtEmail.Text))
                            {
                                DatosValidacionEmail.eliminarCodigo(txtEmail.Text);
                                codigo = Helper.generarCodigo();
                                DatosValidacionEmail.cargarCodigo(txtEmail.Text, codigo);
                                ServicioEmail servicio = new ServicioEmail();
                                servicio.armarEmail(txtEmail.Text, "Código de validación", Helper.cargarCuerpo(txtEmail.Text, codigo), "validaciones@claves.com");
                                servicio.enviarEmail();
                                ajxValidacion.Show();
                                Session["validacionEdit"] = true;
                                Session["email"] = txtEmail.Text;
                                Status = true;
                                status = true;
                            }
                            else
                            {
                                titulo = "Email registrado";
                                mensaje = "El email ingresado ya se encuentra registrado, por favor, verifique el email e intente nuevamente.";
                                status = false;
                            }
                        }
                        else
                        {
                            titulo = "Email en uso";
                            mensaje = "El email ingresado, es el que esta usando actualmente, por favor, ingrese otro email.";
                            status = false;
                        }
                    }
                    if (status)
                    {
                        if (!EditEmail)
                        {
                            DatosUsuario datos = new DatosUsuario();
                            datos.actualizarDatos(usuario);
                            lblNombre.Text = usuario.Nombre;
                            lblApellido.Text = usuario.Apellido;
                            string email = usuario.Email;
                            string pass = usuario.Pass;
                            Helper.codificar(ref email, ref pass);
                            lblPass.Text = pass;
                            imgProfile.ImageUrl = DatosImagenPerfil.traerImagen(usuario.ImagenPerfil.Id);
                            Image imgMaster = (Image)Master.FindControl("imgPerfil");
                            Label lblMaster = (Label)Master.FindControl("lblPerfil");
                            imgMaster.ImageUrl = DatosImagenPerfil.traerImagen(usuario.ImagenPerfil.Id);
                            lblMaster.Text = usuario.Nombre;
                            Status = false;
                            panelPerfil.Visible = true;
                            btnEditar.Text = "✍️ Editar Perfil";
                        }
                        Session["usuario"] = usuario;
                    }
                    else
                        Status = true;
                }
                if (!EditEmail || !status)
                {
                    script = string.Format("crearAlerta({0},'{1}','{2}');", status.ToString().ToLower(), titulo, mensaje);
                    ScriptManager.RegisterStartupScript(this, GetType(), "crearAlerta", script, true);
                }
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void lnkCambiarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["editpass"] != null)
                    EditPass = true;
                if (Session["editemail"] != null)
                    EditEmail = true;
                txtPass.Attributes.Add("value", txtPass.Text);
                txtRepetir.Attributes.Add("value", txtRepetir.Text);
                Status = true;
                ajxImg.Show();
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                Status = true;
                ajxImg.Hide();
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void imgPerfil_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Session["editpass"] != null)
                    EditPass = true;
                if (Session["editemail"] != null)
                    EditEmail = true;
                txtPass.Attributes.Add("value", txtPass.Text);
                txtRepetir.Attributes.Add("value", txtRepetir.Text);
                Status = true;
                RepeaterItem item = (RepeaterItem)((ImageButton)sender).NamingContainer;
                ImageButton img = (ImageButton)item.FindControl("imgPerfil");
                int id = int.Parse(img.AlternateText);
                Session["id"] = id;
                imgProfile.ImageUrl = DatosImagenPerfil.traerImagen(id);
                ajxImg.Hide();
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEditPass_Click(object sender, EventArgs e)
        {
            try
            {
                Status = true;
                EditPass = true;
                Session["editpass"] = EditPass;
                if (Session["editemail"] != null)
                    EditEmail = true;
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEditEmail_Click(object sender, EventArgs e)
        {
            try
            {
                Status = true;
                EditEmail = true;
                Session["editemail"] = EditEmail;
                if (Session["editpass"] != null)
                    EditPass = true;
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelarEditEmail_Click(object sender, EventArgs e)
        {
            try
            {
                Status = true;
                Session["editemail"] = null;
                EditEmail = false;
                if (Session["editpass"] != null)
                    EditPass = true;
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelarEditPass_Click(object sender, EventArgs e)
        {
            try
            {
                Status = true;
                Session["editpass"] = null;
                EditPass = false;
                if (Session["editemail"] != null)
                    EditEmail = true;
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}