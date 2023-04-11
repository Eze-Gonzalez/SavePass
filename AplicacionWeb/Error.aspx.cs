﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWeb
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Error"] != null && Session["ErrorCode"] != null)
            {
                lblErrorTitulo.Text = Session["ErrorCode"].ToString();
                lblError.Text = Session["Error"].ToString();
            }
            else
                Response.Redirect("Default.aspx", false);
            if (Session["ErrorCode"] != null && Session["ErrorCode"].ToString() == "Intentos excedidos")
                btnLogin.Text = "Cambiar Contraseña";
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "Cambiar Contraseña")
                Response.Redirect("Login.aspx?forget=" + true, false);
            else
                Response.Redirect("Login.aspx", false);
        }
    }
}