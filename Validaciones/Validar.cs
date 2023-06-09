﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;
using Database;
using System.Text.RegularExpressions;
using System.Diagnostics.SymbolStore;

namespace Validaciones
{
    public static class Validar
    {
        public static bool sesion(object usuario)
        {
            try
            {
                if (usuario != null && ((Usuario)usuario).Id != 0)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool inicioSesion(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSP("IniciarSesion");
                datos.parametros("@email", usuario.Email);
                datos.parametros("@pass", usuario.Pass);
                datos.lectura();
                if (datos.Lector.Read())
                {
                    //Id, Email, Pass, Nombre, Apellido, IdImagen, FechaNacimiento, ServiciosTotales 
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Email = (string)datos.Lector["Email"];
                    usuario.Pass = (string)datos.Lector["Pass"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    usuario.ImagenPerfil = new ImagenPerfil();
                    usuario.ImagenPerfil.Id = (int)datos.Lector["IdImagen"];
                    usuario.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    usuario.ServiciosTotales = datos.Lector["ServiciosTotales"] is DBNull ? 0 : (int)datos.Lector["ServiciosTotales"];
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public static bool emailRegistrado(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaEmbebida("select id from Usuarios where Email = @email");
                datos.parametros("@email", email);
                datos.lectura();
                if (datos.Lector.Read())
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public static bool contraseña(string pass)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaEmbebida("select id from Usuarios where PassTemporal COLLATE Latin1_General_CS_AS = @pass");
                datos.parametros("@pass", pass);
                datos.lectura();
                if (datos.Lector.Read())
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public static bool campoEmail(string email)
        {
            try
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                bool validar = regex.IsMatch(email);
                return validar;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static bool campoPass(string pass)
        {
            try
            {
                Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^\\w\\s]).{6,20}$");
                bool validar = regex.IsMatch(pass);
                return validar;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool codigo(string codigo, string email)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.consultaEmbebida("Select Id from Validacion where EmailUsuario = @email and Codigo COLLATE Latin1_General_CS_AS = @codigo");
                    datos.parametros("@email", email);
                    datos.parametros("@codigo", codigo);
                    datos.lectura();
                    if (datos.Lector.Read())
                        return true;
                    return false;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool campo(string campo)
        {
            try
            {
                if (string.IsNullOrEmpty(campo) || campo.Length != 8 || campo.Contains(" "))
                    return false;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool camposRequeridos(string servicio, string usuario, string pass, ref string titulo, ref string mensaje, ref bool status)
        {
            try
            {
                if (string.IsNullOrEmpty(servicio) || servicio == " ")
                {
                    titulo = "Servicio no válido";
                    mensaje = "El campo Nombre de servicio esta vacío, ingrese un nombre para continuar.";
                    return status;
                }
                else if (servicio.Length > 50)
                {
                    titulo = "Servicio no válido";
                    mensaje = "El nombre del servicio excede los 50 caracteres, por favor, introduzca un nombre mas corto para el servicio.";
                    return status;
                }
                if(string.IsNullOrEmpty(usuario) || usuario == " ")
                {
                    titulo = "Usuario no válido";
                    mensaje = "El campo Usuario, esta vacío, por favor, ingrese un nombre de usuario para continuar.";
                    return status;
                }
                else if(usuario.Length > 100)
                {
                    titulo = "Usuario no válido";
                    mensaje = "El usuario ingresado excede los 100 caracteres, por favor, ingrese un nombre de usuario mas corto.";
                    return status;
                }
                if(string.IsNullOrEmpty(pass) || pass == " ")
                {
                    titulo = "Contraseña no válida";
                    mensaje = "El campo Contraseña, esta vacío, por favor, ingrese una contraseña para continuar.";
                    return status;
                }
                else if(pass.Length > 20)
                {
                    titulo = "Contraseña no válida";
                    mensaje = "La contraseña ingresada excede los 20 caracteres, por favor, introduzca una contraseña mas corta.";
                    return status;
                }
                return status = true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool camposRequeridos(string nombre, string apellido, ref string titulo, ref string mensaje, ref bool status)
        {
            try
            {
                status = false;
                if (!string.IsNullOrEmpty(nombre) || nombre != " ")
                {
                    if(!string.IsNullOrEmpty(apellido) || apellido != " ")
                    {
                        titulo = "Datos Actualizados";
                        mensaje = "Los cambios fueron guardados exitosamente!";
                        return status = true;
                    }
                    else
                    {
                        titulo = "Apellido vacío";
                        mensaje = "El campo apellido esta vacío, por favor revise el campo y vuelva a intentarlo.";
                        return status;
                    }
                }
                else
                {
                    titulo = "Nombre vacío";
                    mensaje = "El campo nombre esta vacío, por favor revise el campo y vuelva a intentarlo.";
                    return status;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool camposRequeridos(string email, string pass, string repetir, ref string titulo, ref string mensaje, ref bool status, bool editEmail = false, bool editPass = false)
        {
            try
            {
                status = false;
                if (editEmail)
                {
                    if (campoEmail(email))
                    {
                        titulo = "Datos Actualizados";
                        mensaje = "Los cambios fueron guardados exitosamente";
                        status = true;
                    }
                    else
                    {
                        titulo = "Email no válido";
                        mensaje = "El email ingresado no es válido, por favor, revise el campo e intente nuevamente.";
                        status = false;
                    }
                }
                if (editPass)
                {
                    if (campoPass(pass))
                    {
                        titulo = "Datos Actualizados";
                        mensaje = "Los cambios fueron guardados exitosamente";
                        status = true;
                    }
                    else
                    {
                        titulo = "Contraseña no válida";
                        mensaje = "La contraseña ingresada no es válida, por favor, revise el campo e intente nuevamente.";
                        status = false;
                    }
                }
                return status;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool usuarioExistente(string nombreServicio, string nombreUsuario, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSP("usuarioExistente");
                datos.parametros("@nServicio", nombreServicio);
                datos.parametros("@nUsuario", nombreUsuario);
                datos.parametros("@idUsuario", idUsuario);
                datos.lectura();
                if (datos.Lector.Read())
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public static bool passActual(string pass, string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaEmbebida("Select Id from usuarios where email = @email and pass = @pass");
                datos.parametros("@email", email);
                datos.parametros("@pass", pass);
                datos.lectura();
                if(datos.Lector.Read())
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
