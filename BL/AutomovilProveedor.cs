using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AutomovilProveedor
    {
        public static ML.Result GetProveedorByIdAutomovil(int IdAutomovil)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.PortafolioVentoEntities context = new DL_EF.PortafolioVentoEntities())
                {
                    var query = context.AutomovilProveedorAsignadaByAutomovilId(IdAutomovil).ToList();
                    result.Objects = new List<object>();
                    if(query != null)
                    {
                        foreach(var row in query)
                        {
                            ML.AutomovilProveedor automovilProveedorItem = new ML.AutomovilProveedor();
                            automovilProveedorItem.IdAutomovilProveedor = row.IdAutomovilProveedor;
                            automovilProveedorItem.Automovil = new ML.Automovil();
                            automovilProveedorItem.Automovil.IdAutomovil = row.IdAutomovil;
                            automovilProveedorItem.Proveedor = new ML.Proveedor();
                            automovilProveedorItem.Proveedor.IdProveedor = row.IdProveedor;
                            automovilProveedorItem.Proveedor.Nombre = row.Nombre;

                            result.Objects.Add(automovilProveedorItem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro registros del automovil.";
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
        public static ML.Result GetProveedorNOAsignadaByIdAutomovil(int IdProveedor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.PortafolioVentoEntities context = new DL_EF.PortafolioVentoEntities())
                {
                    var query = context.AutomovilProveedorNOAsignadaByAutomovilId(IdProveedor).ToList();
                    result.Objects = new List<object>();
                    if(query != null)
                    {
                        foreach(var row in query)
                        {
                            ML.AutomovilProveedor automovilProveedorItem = new ML.AutomovilProveedor();
                            automovilProveedorItem.Proveedor = new ML.Proveedor();
                            automovilProveedorItem.Proveedor.IdProveedor = row.IdProveedor;
                            automovilProveedorItem.Proveedor.Nombre = row.Nombre;

                            result.Objects.Add(automovilProveedorItem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = true;
                        result.ErrorMessage = "No hay Proveedores disponibles para este Automovil.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = true;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result AddProveedor(ML.AutomovilProveedor automovilProveedor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.PortafolioVentoEntities context = new DL_EF.PortafolioVentoEntities())
                {
                    var query = context.AutomovilProveedorAdd(automovilProveedor.Automovil.IdAutomovil, automovilProveedor.Proveedor.IdProveedor);
                    if(query != null)
                    {
                        result.Object = automovilProveedor;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo insertar el Proveedor.";
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
        public static ML.Result DeleteProveedor(int IdAutomovilProveedor) //IdAutomovilProveedor
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.PortafolioVentoEntities context = new DL_EF.PortafolioVentoEntities())
                {
                    var query = context.AutomovilProveedorDelete(IdAutomovilProveedor);
                    if(query != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar el proveedor.";
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
