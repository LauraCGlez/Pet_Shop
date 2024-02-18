using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet_shop.Models
{
    public class Mascota
    {
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Edad { get; set; }

        public Mascota(string nombre, string raza, string edad)
        {
            Nombre = nombre;
            Raza = raza;
            Edad = edad;
        }

    }
}
