using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public int Costo { get; set; }
        public List<object> Proveedores { get; set; }
        public bool Selected { get; set; }
    }
}
