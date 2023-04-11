using Database;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosDatosAcceso
    {
        public List<DatosAcceso> listar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<DatosAcceso> lista = new List<DatosAcceso>();
            try
            {
                datos.consultaSP("listarAcceso");
                datos.parametros("@id", id);
                datos.lectura();
                while (datos.Lector.Read())
                {
                    DatosAcceso acceso = new DatosAcceso();
                    acceso.Id = (int)datos.Lector["Id"];
                    acceso.Usuario = new Usuario();
                    acceso.Usuario.Id = (int)datos.Lector["IdUsuario"];
                    acceso.Servicio = new Servicio();
                    acceso.Servicio.Id = (int)datos.Lector["IdServicio"];
                    acceso.Servicio.Imagen = datos.Lector["imagen"] is DBNull ? "https://i.imgur.com/yzczBvI.png" : (string)datos.Lector["imagen"];
                    acceso.nUsuario = (string)datos.Lector["Usuario"];
                    acceso.Pass = (string)datos.Lector["Pass"];
                    acceso.nombreServicio = (string)datos.Lector["NombreServicio"];
                    acceso.validarOtro = (bool)datos.Lector["ValidarOtro"];
                    lista.Add(acceso);
                }
                return lista;
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
        public DatosAcceso traerAcceso(int idSeleccionado, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                DatosAcceso acceso = new DatosAcceso();
                datos.consultaSP("traerAcceso");
                datos.parametros("idSeleccionado", idSeleccionado);
                datos.parametros("idUsuario", idUsuario);
                datos.lectura();
                if (datos.Lector.Read())
                {
                    acceso.Id = (int)datos.Lector["Id"];
                    acceso.Usuario = new Usuario();
                    acceso.Usuario.Id = (int)datos.Lector["IdUsuario"];
                    acceso.Servicio = new Servicio();
                    acceso.Servicio.Id = (int)datos.Lector["IdServicio"];
                    acceso.Servicio.Imagen = datos.Lector["imagen"] is DBNull ? "https://i.imgur.com/yzczBvI.png" : (string)datos.Lector["imagen"];
                    acceso.Servicio.UrlCambio = datos.Lector["urlCambio"] is DBNull ? "" : (string)datos.Lector["urlCambio"];
                    acceso.nUsuario = (string)datos.Lector["Usuario"];
                    acceso.Pass = (string)datos.Lector["Pass"];
                    acceso.nombreServicio = (string)datos.Lector["NombreServicio"];
                    acceso.validarOtro = (bool)datos.Lector["ValidarOtro"];
                }
                return acceso;
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

        public void eliminarAcceso(DatosAcceso acceso)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaEmbebida("delete DatosAccesos where id = @id");
                datos.parametros("@id", acceso.Id);
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
        public void cargarAcceso(DatosAcceso acceso, ref string titulo, ref string mensaje)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSP("agregarAcceso");
                datos.parametros("@idServicio", acceso.Servicio.Id);
                datos.parametros("@idUsuario", acceso.Usuario.Id);
                datos.parametros("@usuario", acceso.nUsuario);
                datos.parametros("@pass", acceso.Pass);
                datos.parametros("@nombreServicio", acceso.nombreServicio);
                datos.parametros("@validarOtro", acceso.validarOtro);
                datos.ejecutar();
                titulo = "Servicio Agregado";
                mensaje = "El servicio " + acceso.nombreServicio + " fue agregado exitosamente!";
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

        public void modificarAcceso(DatosAcceso acceso, ref string titulo, ref string mensaje)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSP("modificarAcceso");
                datos.parametros("@idServicio", acceso.Servicio.Id);
                datos.parametros("@idUsuario", acceso.Usuario.Id);
                datos.parametros("@usuario", acceso.nUsuario);
                datos.parametros("@pass", acceso.Pass);
                datos.parametros("@nombreServicio", acceso.nombreServicio);
                datos.parametros("@validarOtro", acceso.validarOtro);
                datos.parametros("@id", acceso.Id);
                datos.ejecutar();
                titulo = "Servicio Actualizado";
                mensaje = "El servicio " + acceso.nombreServicio + " fue modificado exitosamente!";
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

        public void eliminarUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaEmbebida("delete DatosAccesos where IdUsuario = @id");
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
    }
}
