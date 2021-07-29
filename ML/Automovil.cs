using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Automovil
    {
        public int IdAutomovil { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public byte[] Imagen { get; set; }
        public List<object> Automoviles { get; set; }
    }
}
