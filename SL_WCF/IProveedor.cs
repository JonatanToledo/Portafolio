using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProveedor" in both code and config file together.
    [ServiceContract]
    public interface IProveedor
    {
        [OperationContract]
        [ServiceKnownType(typeof(ML.Proveedor))]
        Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Proveedor))]
        Result GetById(int IdProveedor);

        [OperationContract]
        Result Add(ML.Proveedor proveedor);

        [OperationContract]
        Result Update(ML.Proveedor proveedor);

        [OperationContract]
        Result Delete(int IdProveedor);
    }
    [DataContract]
    public class Result
    {
        [DataMember]
        public bool Correct { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public Exception Ex { get; set; }
        [DataMember]
        public object Object { get; set; }
        [DataMember]
        public List<object> Objects { get; set; }
    }
}
