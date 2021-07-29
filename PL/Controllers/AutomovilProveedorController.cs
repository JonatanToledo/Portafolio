using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AutomovilProveedorController : Controller
    {
        //
        // GET: /AutomovilProveedor/
        public ActionResult ProveedorGetAll()
        {
            ML.Result result = BL.Automovil.GetAll();
            ML.Automovil automovil = new ML.Automovil();
            automovil.Automoviles = result.Objects;
            return View(automovil);
        }
        public ActionResult GetAllProveedoresAsignadasById(int IdAutomovil)
        {
            ML.AutomovilProveedor automovilProveedorResult = new ML.AutomovilProveedor();
            ML.Result resultAutomovil = BL.Automovil.GetById(IdAutomovil);
            ML.Result resultProveedor = BL.AutomovilProveedor.GetProveedorByIdAutomovil(IdAutomovil);

            if (resultAutomovil.Object != null)
            {
                automovilProveedorResult.Automovil = ((ML.Automovil)resultAutomovil.Object);
                automovilProveedorResult.AutomovilProveedores = resultProveedor.Objects;
                return View(automovilProveedorResult);
            }
            else
            {
                ViewBag.Message = resultAutomovil.ErrorMessage;
                return PartialView("Modal");
            }

        }
        public ActionResult GetAllProveedoresNOAsignadasById(int IdAutomovil)
        {
            ML.AutomovilProveedor automovilProveedorResult = new ML.AutomovilProveedor();
            ML.Result resultAutomovil = BL.Automovil.GetById(IdAutomovil);
            ML.Result resultProveedor = BL.AutomovilProveedor.GetProveedorNOAsignadaByIdAutomovil(IdAutomovil);

            automovilProveedorResult.Automovil = ((ML.Automovil)resultAutomovil.Object);
            automovilProveedorResult.AutomovilProveedores = resultProveedor.Objects;
            return View(automovilProveedorResult);
        }

        public ActionResult AddProveedor(ML.AutomovilProveedor automovilProveedor)
        {
            if (automovilProveedor.AutomovilProveedores != null)
            {
                foreach (string IdProveedor in automovilProveedor.AutomovilProveedores)
                {
                    ML.AutomovilProveedor AutomovilProveedorItem = new ML.AutomovilProveedor();
                    AutomovilProveedorItem.Automovil = new ML.Automovil();
                    AutomovilProveedorItem.Automovil.IdAutomovil = automovilProveedor.Automovil.IdAutomovil;

                    AutomovilProveedorItem.Proveedor = new ML.Proveedor();
                    AutomovilProveedorItem.Proveedor.IdProveedor = int.Parse(IdProveedor);
                    ML.Result result = BL.AutomovilProveedor.AddProveedor(AutomovilProveedorItem);

                    ViewBag.Message = "Se agregaron correctamente el/los Proveedor(es).";
                }
            }
            else
            {
                ViewBag.Message = "No se pudo ingresar el/los Proveedor(es).";
            }
            return PartialView("Modal");
        }

        public ActionResult DeleteProveedor(int IdAutomovilProveedor)
        {
            ML.Result result = new ML.Result();
            ML.AutomovilProveedor automovilProveedorResult = new ML.AutomovilProveedor();
            if (IdAutomovilProveedor != 0)
            {
                result = BL.AutomovilProveedor.DeleteProveedor(IdAutomovilProveedor);
                ViewBag.Message = "Se elimino correctamente el Proveedor.";
            }
            else
            {
                ViewBag.Message = "No se pudieron añadir el/los Proveedor(es).";
            }
            return PartialView("Modal");
        }
	}
}