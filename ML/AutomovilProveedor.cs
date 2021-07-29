using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class AutomovilProveedor
    {
        public int IdAutomovilProveedor { get; set; }
        public ML.Automovil Automovil { get; set; }
        public ML.Proveedor Proveedor { get; set; }
        public List<object> AutomovilProveedores { get; set; }
    }
}
