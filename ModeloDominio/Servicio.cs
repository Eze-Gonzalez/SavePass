using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Servicio
    {
        public int Id { get; set; }
        public string NombreServicio { get; set; }
        public string Imagen { get; set; }
        public string UrlCambio { get; set; }

        public override string ToString()
        {
            return NombreServicio;
        }
    }
}
