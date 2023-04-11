using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using System.ComponentModel.Design;

namespace Datos
{
    public static class DatosImagenPerfil
    {
		public static List<ImagenPerfil> listar()
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				List<ImagenPerfil> lista = new List<ImagenPerfil>();
				datos.consultaEmbebida("select Id, Imagen from Imagenes");
				datos.lectura();
				while (datos.Lector.Read())
				{
					ImagenPerfil imagen = new ImagenPerfil();
					imagen.Id = (int)datos.Lector["Id"];
					imagen.Url = (string)datos.Lector["Imagen"];
					lista.Add(imagen);
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
		public static string traerImagen(int id)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.consultaEmbebida("Select Imagen from Imagenes where Id = @id");
				datos.parametros("@id", id);
				datos.lectura();
				if (datos.Lector.Read())
					return (string)datos.Lector["Imagen"];
				else
					return "https://i.imgur.com/9jtQAyi.png";

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
