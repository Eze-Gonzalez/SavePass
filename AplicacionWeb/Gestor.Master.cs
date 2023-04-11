using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validaciones;
using ModeloDominio;
using Helpers;
using Datos;
using System.Threading;

namespace AplicacionWeb
{
    public partial class Gestor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DatosValidacionEmail.eliminarCodigosCaducados();
                if (Page is Profile || Page is AddService || Page is MyServices)
                {
                    if (!Validar.sesion(Session["usuario"]))
                        Response.Redirect("Login.aspx");
                }
                if (Validar.sesion(Session["usuario"]))
                {
                    Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
                    lblPerfil.Text = usuario.Nombre;
                    imgPerfil.ImageUrl = DatosImagenPerfil.traerImagen(usuario.ImagenPerfil.Id);
                }
                if (Page is Default || Page is Profile)
                {
                    if (Session["acceso"] != null)
                    {
                        Session["acceso"] = null;
                    }
                }
                if (Session["Error"] != null && Session["ErrorCode"] != null)
                {
                    Session["Error"] = null;
                    Session["ErrorCode"] = null;
                }
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                Session.Add("ErrorCode", "Hubo un problema al cargar la página");
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("ErrorCode", "Hubo un problema al cargar la página");
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["acceso"] != null)
                    Session["acceso"] = null;
                Response.Redirect("AddService.aspx", false);
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                Session["ErrorCode"] = "Hubo un problema al cargar la página";
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}