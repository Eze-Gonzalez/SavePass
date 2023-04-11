using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public ImagenPerfil ImagenPerfil { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int ServiciosTotales { get; set; }
    }
}
