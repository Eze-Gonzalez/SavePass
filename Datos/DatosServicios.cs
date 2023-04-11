using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;
using Database;

namespace Datos
{
    public class DatosServicios
    {
        public List<Servicio> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaEmbebida("select Id, Servicio, Imagen, UrlCambio from Servicios");
                datos.lectura();
                List<Servicio> lista = new List<Servicio>();
                while (datos.Lector.Read())
                {
                    Servicio servicio = new Servicio();
                    servicio.Id = (int)datos.Lector["Id"];
                    servicio.NombreServicio = (string)datos.Lector["Servicio"];
                    servicio.UrlCambio = datos.Lector["UrlCambio"] is DBNull ? string.Empty : (string)datos.Lector["UrlCambio"];
                    if (!(datos.Lector["Imagen"] is DBNull))
                        servicio.Imagen = (string)datos.Lector["Imagen"];
                    else
                        servicio.Imagen = "";
                    lista.Add(servicio);
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
        public Servicio traerServicio(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaEmbebida("select Id, Servicio, Imagen, UrlCambio from Servicios where id = @id");
                datos.parametros("@id", id);
                datos.lectura();
                Servicio servicio = new Servicio();
                if (datos.Lector.Read())
                {
                    servicio.Id = (int)datos.Lector["Id"];
                    servicio.NombreServicio = (string)datos.Lector["Servicio"];
                    servicio.UrlCambio = (string)datos.Lector["UrlCambio"];
                    if (!(datos.Lector["Imagen"] is DBNull))
                        servicio.Imagen = (string)datos.Lector["Imagen"];
                    else
                        servicio.Imagen = "";
                }
                return servicio;
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
