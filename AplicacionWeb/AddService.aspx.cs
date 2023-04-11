using AjaxControlToolkit.Design;
using Datos;
using Helpers;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validaciones;

namespace AplicacionWeb
{
    public partial class AddService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Title = "Añadir Servicio";
                if (!IsPostBack)
                {
                    lblUsuario.Text = "Usuario o email de Disney+ y Star+";
                    lblPass.Text = "Contraseña de Disney+ y Star+";
                    DatosServicios datos = new DatosServicios();
                    ddlServicios.DataSource = datos.listar();
                    ddlServicios.DataValueField = "Id";
                    ddlServicios.DataTextField = "NombreServicio";
                    ddlServicios.DataBind();
                    txtNServicio.Text = ddlServicios.SelectedItem.ToString();
                    imgServicio.ImageUrl = Helper.cargarImagen(int.Parse(ddlServicios.SelectedValue));
                }
                if (!IsPostBack && Session["acceso"] != null)
                {
                    btnAgregar.Text = "Modificar servicio";
                    Title = "Modificar servicio";
                    DatosAcceso acceso = Session["acceso"] != null ? (DatosAcceso)Session["acceso"] : null;
                    Title = "Modificar " + acceso.nombreServicio;
                    ddlServicios.SelectedValue = acceso.Servicio.Id.ToString();
                    imgServicio.ImageUrl = acceso.Servicio.Imagen;
                    txtNServicio.Text = acceso.nombreServicio;
                    if (ddlServicios.SelectedItem.ToString() == "Otro")
                        panelOtros.Visible = true;
                    txtUsuario.Text = acceso.nUsuario;
                    txtPass.Attributes.Add("value", acceso.Pass);
                }
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                imgServicio.ImageUrl = Helper.cargarImagen(int.Parse(ddlServicios.SelectedValue));
                if (ddlServicios.SelectedItem.ToString() == "Otro")
                {
                    lblUsuario.Text = "Usuario o email del servicio";
                    lblPass.Text = "Contraseña del servicio";
                    panelOtros.Visible = true;
                    txtNServicio.Text = "";
                }
                else
                {
                    lblUsuario.Text = "Usuario o email de " + ddlServicios.SelectedItem.ToString();
                    lblPass.Text = "Contraseña de " + ddlServicios.SelectedItem.ToString();
                    panelOtros.Visible = false;
                    txtNServicio.Text = ddlServicios.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string titulo = "";
            string mensaje = "";
            bool status = false;
            try
            {
                if (Validar.camposRequeridos(txtNServicio.Text, txtUsuario.Text, txtPass.Text, ref titulo, ref mensaje, ref status))
                {
                    DatosAcceso acceso = new DatosAcceso();
                    if (ddlServicios.SelectedItem.ToString() == "Otro")
                        acceso.validarOtro = true;
                    else
                        acceso.validarOtro = false;
                    acceso.Servicio = new Servicio();
                    acceso.Usuario = new Usuario();
                    acceso.Servicio.Id = int.Parse(ddlServicios.SelectedValue);
                    acceso.Usuario.Id = Session["usuario"] != null ? ((Usuario)Session["usuario"]).Id : 0;
                    acceso.nUsuario = txtUsuario.Text;
                    acceso.Pass = txtPass.Text;
                    acceso.nombreServicio = txtNServicio.Text;
                    if (!Validar.usuarioExistente(txtNServicio.Text, txtUsuario.Text, acceso.Usuario.Id))
                    {
                        DatosDatosAcceso datos = new DatosDatosAcceso();
                        if (Request.QueryString["id"] != null)
                        {
                            acceso.Id = int.Parse(Request.QueryString["id"]);
                            datos.modificarAcceso(acceso, ref titulo, ref mensaje);
                        }
                        else
                        {
                            Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
                            datos.cargarAcceso(acceso, ref titulo, ref mensaje);
                            DatosUsuario datosU = new DatosUsuario();
                            datosU.actualizarServiciosTotales(usuario, true);
                        }
                    }
                    else
                    {
                        status = false;
                        titulo = "Usuario ya almacenado";
                        mensaje = "El usuario ingresado para el servicio " + txtNServicio.Text + ", ya se encuentra almacenado en su cuenta.";
                    }

                }
                crearAlerta(titulo, mensaje, status);
            }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        private void crearAlerta(string titulo, string mensaje, bool status)
        {
            try
            {
                string script;
                script = string.Format("crearAlerta({0},'{1}','{2}');", status.ToString().ToLower(), titulo, mensaje);
                ScriptManager.RegisterStartupScript(this, GetType(), "crearAlerta", script, true);
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