﻿using Database;
using Microsoft.SqlServer.Server;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosUsuario
    {
        public int nuevoUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSP("Registro");
                //@email varchar(100),
                //@pass varchar(8),
                //@nombre varchar(50),
                //@apellido varchar(50),
                //@fecha datetime
                datos.parametros("@email", usuario.Email);
                datos.parametros("@pass", usuario.Pass);
                datos.parametros("@nombre", usuario.Nombre);
                datos.parametros("@apellido", usuario.Apellido);
                datos.parametros("@fecha", usuario.FechaNacimiento);
                return datos.ejecutarScalar();
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
        public void actualizarServiciosTotales(Usuario usuario, bool agregar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (agregar)
                    usuario.ServiciosTotales++;
                else
                    usuario.ServiciosTotales--;
                datos.consultaEmbebida("update Usuarios set ServiciosTotales = @ST where id = @id");
                datos.parametros("@ST", usuario.ServiciosTotales);
                datos.parametros("@id", usuario.Id);
                datos.ejecutar();
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

        public Usuario traerDatos(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                Usuario usuario = new Usuario();
                datos.consultaEmbebida("select IdImagen, Nombre from Usuarios where Email = @email");
                datos.parametros("@email", email);
                datos.lectura();
                if (datos.Lector.Read())
                {
                    usuario.ImagenPerfil = new ImagenPerfil();
                    usuario.ImagenPerfil.Id = (int)datos.Lector["IdImagen"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                }
                return usuario;
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

        public bool buscarUsuario(string email, string nombre, string apellido, string fecha)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSP("Forget");
                datos.parametros("@email", email);
                datos.parametros("@nombre", nombre);
                datos.parametros("@apellido", apellido);
                datos.parametros("@fecha", DateTime.Parse(fecha));
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

        public void passForget(string pass, string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSP("forgetPass");
                datos.parametros("@pass", pass);
                datos.parametros("@email", email);
                datos.ejecutar();
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

        public void eliminarCuenta(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaEmbebida("delete from Usuarios where id = @id");
                datos.parametros("@id", id);
                datos.ejecutar();
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

        public void actualizarDatos(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSP("ActualizarDatos");
                //@nombre varchar(50),
                //@apellido varchar(50),
                //@email varchar(100),
                //@pass varchar(50),
                //@idImagen int,
                //@id int
                datos.parametros("@nombre", usuario.Nombre);
                datos.parametros("@apellido", usuario.Apellido);
                datos.parametros("@email", usuario.Email);
                datos.parametros("@pass", usuario.Pass);
                datos.parametros("@idImagen", usuario.ImagenPerfil.Id);
                datos.parametros("@id", usuario.Id);
                datos.ejecutar();
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
