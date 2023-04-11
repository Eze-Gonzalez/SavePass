using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Threading;
using Servicios;
using Helpers;
using Validaciones;

namespace AplicacionWeb
{
    public partial class MyServices : System.Web.UI.Page
    {
        private string codigo;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int id = Session["usuario"] != null ? ((Usuario)Session["usuario"]).Id : 0;
                    DatosDatosAcceso datos = new DatosDatosAcceso();
                    repServicios.DataSource = datos.listar(id);
                    repServicios.DataBind();
                }
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void imgAcceso_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
                int idSeleccionado = int.Parse(((ImageButton)sender).AlternateText);
                DatosDatosAcceso datos = new DatosDatosAcceso();
                DatosAcceso acceso = datos.traerAcceso(idSeleccionado, usuario.Id);
                Session["acceso"] = acceso;
                ServicioEmail email = new ServicioEmail();
                DatosValidacionEmail.eliminarCodigo(usuario.Email);
                codigo = Helper.generarCodigo();
                DatosValidacionEmail.cargarCodigo(usuario.Email, codigo);
                email.armarEmail(usuario.Email, "Código de validación", Helper.cargarCuerpo(usuario.Email, codigo), "validaciones@claves.com");
                email.enviarEmail();
                ajxValidacion.Show();
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                ajxValidacion.Hide();
                txtVerificar.Text = string.Empty;
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
                if (Validar.campo(txtVerificar.Text))
                {
                    Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
                    if (Validar.codigo(txtVerificar.Text, usuario.Email))
                    {
                        lblErrorVerificar.Visible = false;
                        ajxValidacion.Hide();
                        string clases = modalAcceso.CssClass;
                        modalAcceso.CssClass = clases + " modalNotificar";
                        modalAcceso.Visible = true;
                        DatosAcceso acceso = Session["acceso"] != null ? (DatosAcceso)Session["acceso"] : null;
                        imgServicio.ImageUrl = acceso.Servicio.Imagen;
                        imgServicio.AlternateText = acceso.nombreServicio;
                        lblNombre.Text = usuario.Nombre + " " + usuario.Apellido;
                        lblServicio.Text = " " + acceso.nombreServicio;
                        lblUsuario.Text = acceso.nUsuario;
                        lblPass.Text = acceso.Pass;
                        if(acceso.validarOtro)
                            btnCambiar.Visible = false;
                        else
                            btnCambiar.Visible = true;
                        ajxAcceso.Show();
                        ScriptManager.RegisterStartupScript(this, GetType(), "limpar", "limpiar()", true);
                    }
                    else
                    {
                        lblErrorVerificar.Text = "El código ingresado es incorrecto, intente nuevamente";
                        lblErrorVerificar.Visible = true;
                    }
                }
                else
                {
                    lblErrorVerificar.Text = "El código ingresado no es válido o el campo esta vacío, intente nuevamente";
                    lblErrorVerificar.Visible = true;
                }
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
                modalAcceso.Visible = false;
                ajxAcceso.Hide();
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Session["acceso"] != null ? ((DatosAcceso)Session["acceso"]).Id : 0;
                    Response.Redirect("AddService.aspx?id=" + id, false);
                modalAcceso.Visible = false;
                ajxAcceso.Hide();
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["acceso"] != null)
                {
                    DatosAcceso acceso = (DatosAcceso)Session["acceso"];
                    string url = acceso.Servicio.UrlCambio;
                    string script = "window.open('" + url + "', '_blank');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "OpenWindow", script, true);
                }
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string servicio = Session["acceso"] != null ? ((DatosAcceso)Session["acceso"]).nombreServicio : "";
                lblConfirmar.Text = "¿Está seguro que desea eliminar el servicio " + servicio + "? Esta acción no se puede revertir, ¿desea continuar?";
                modalAcceso.Visible = false;
                ajxAcceso.Hide();
                modalConfirmación.Visible = true;
                ajxConfirmar.Show();
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
                DatosAcceso acceso = Session["acceso"] != null ? (DatosAcceso)Session["acceso"] : null;
                DatosDatosAcceso datos = new DatosDatosAcceso();
                datos.eliminarAcceso(acceso);
                DatosUsuario datosU = new DatosUsuario();
                Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
                datosU.actualizarServiciosTotales(usuario, false);
                Response.Redirect("MyServices.aspx");
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
                DatosAcceso acceso = Session["acceso"] != null ? (DatosAcceso)Session["acceso"] : null;
                Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
                string clases = modalAcceso.CssClass;
                modalAcceso.CssClass = clases + " modalNotificar";
                modalAcceso.Visible = true;
                imgServicio.ImageUrl = acceso.Servicio.Imagen;
                imgServicio.AlternateText = acceso.nombreServicio;
                lblNombre.Text = usuario.Nombre + " " + usuario.Apellido;
                lblServicio.Text = " " + acceso.nombreServicio;
                lblUsuario.Text = acceso.nUsuario;
                lblPass.Text = acceso.Pass;
                modalConfirmación.Visible = false;
                ajxConfirmar.Hide();
                modalAcceso.Visible = true;
                ajxAcceso.Show();
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