using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProveedorController : Controller
    {
        //
        // GET: /Proveedor/
        [HttpGet]
        public ActionResult GetAll()
        {
            ServiceReferenceProveedor.ProveedorClient servProveedor = new ServiceReferenceProveedor.ProveedorClient();
            var result = servProveedor.GetAll();

            ML.Proveedor proveedor = new ML.Proveedor();
            proveedor.Proveedores = new List<object>();

            foreach(ML.Proveedor proveedorItem in result.Objects)
            {
                proveedor.Proveedores.Add(proveedorItem);
            }
            return View(proveedor);
        }

        [HttpGet]
        public ActionResult Form(int? IdProveedor)
        {
            ServiceReferenceProveedor.ProveedorClient servProveedor = new ServiceReferenceProveedor.ProveedorClient();
            ML.Proveedor proveedor = new ML.Proveedor();
            if(IdProveedor == null)
            {
                return View(proveedor);
            }
            else
            {

                var result = servProveedor.GetById(IdProveedor.Value);
                if(result.Correct)
                {
                    proveedor = ((ML.Proveedor)result.Object);
                    return View(proveedor);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Proveedor proveedor)
        {
            ServiceReferenceProveedor.ProveedorClient servProveedor = new ServiceReferenceProveedor.ProveedorClient();
            if (proveedor.IdProveedor == 0)
            {
                if(proveedor.Costo != 0)
                {
                    var result = servProveedor.Add(proveedor);
                    ViewBag.Message = "La proveedor se registro correctamente.";
                }
                else
                {
                    ViewBag.Message = "Ingrese un costo mayor a cero por favor.";
                }
            }
            else
            {
                var result = servProveedor.Update(proveedor);
                ViewBag.Message = "La proveedor se actualizo correctamente.";
            }

            if (proveedor == null)
            {
                ViewBag.Message = "La proveedoror no se pudo actualizar o agregar correctamente.";
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdProveedor)
        {
            ServiceReferenceProveedor.ProveedorClient servProveedor = new ServiceReferenceProveedor.ProveedorClient();
            var result = servProveedor.Delete(IdProveedor);
            return RedirectToAction("GetAll");
        }
	}
}