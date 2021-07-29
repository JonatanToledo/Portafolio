using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Proveedor" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Proveedor.svc or Proveedor.svc.cs at the Solution Explorer and start debugging.
    public class Proveedor : IProveedor
    {
        public Result GetAll()
        {
            ML.Result result = BL.Proveedor.GetAllEF();
            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Objects = result.Objects };
        }
        public Result GetById(int IdProveedor)
        {
            ML.Result result = BL.Proveedor.GetByIdEF(IdProveedor);
            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object };
        }
        public Result Add(ML.Proveedor proveedor)
        {
            ML.Result result = BL.Proveedor.AddEF(proveedor);
            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }
        public Result Update(ML.Proveedor proveedor)
        {
            ML.Result result = BL.Proveedor.UpdateEF(proveedor);
            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }
        public Result Delete(int IdProveedor)
        {
            ML.Result result = BL.Proveedor.DeleteEF(IdProveedor);
            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }
    }
}
