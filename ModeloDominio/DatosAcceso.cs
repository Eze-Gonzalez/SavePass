using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class DatosAcceso
    {
        public int Id { get; set; }
        public Servicio Servicio { get; set; }
        public Usuario Usuario { get; set; }
        public string nUsuario { get; set; }
        public string Pass { get; set; }
        public string nombreServicio { get; set; }
        public bool validarOtro { get; set; }
    }
}
