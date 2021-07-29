using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Proveedor
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.PortafolioVentoEntities context = new DL_EF.PortafolioVentoEntities())
                {
                    var query = context.ProveedorGetAll().ToList();
                    result.Objects = new List<object>();
                    
                    if(query != null)
                    {
                        foreach(var row in query)
                        {
                            ML.Proveedor proveedor = new ML.Proveedor();
                            proveedor.IdProveedor = row.IdProveedor;
                            proveedor.Nombre = row.Nombre;
                            proveedor.Costo = row.Costo.Value;

                            result.Objects.Add(proveedor);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo consultar los registros.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetByIdEF(int IdProveedor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.PortafolioVentoEntities context = new DL_EF.PortafolioVentoEntities())
                {
                    var query = context.ProveedorGetById(IdProveedor).FirstOrDefault();
                    if(query != null)
                    {
                        ML.Proveedor proveedorItem = new ML.Proveedor();
                        proveedorItem.IdProveedor = query.IdProveedor;
                        proveedorItem.Nombre = query.Nombre;
                        proveedorItem.Costo = query.Costo.Value;

                        result.Object = proveedorItem;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo consultar el registro.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result AddEF(ML.Proveedor proveedor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.PortafolioVentoEntities context = new DL_EF.PortafolioVentoEntities())
                {
                    var query = context.ProveedorAdd(proveedor.Nombre, proveedor.Costo);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar el registro.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Proveedor proveedor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.PortafolioVentoEntities context = new DL_EF.PortafolioVentoEntities())
                {
                    var query = context.ProveedorUpdate(proveedor.IdProveedor, proveedor.Nombre, proveedor.Costo);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el registro.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result DeleteEF(int IdProveedor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.PortafolioVentoEntities context = new DL_EF.PortafolioVentoEntities())
                {
                    var query = context.ProveedorDelete(IdProveedor);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eleminiar el registro.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
