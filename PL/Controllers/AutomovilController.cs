using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;

namespace PL.Controllers
{
    public class AutomovilController : Controller
    {
        //
        // GET: /Automovil/
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Automovil automovil = new ML.Automovil();
            ML.Result resultAutomovil = new ML.Result();
            resultAutomovil.Objects = new List<Object>();

            var urlAPI = ConfigurationManager.AppSettings["URLapi"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);

                var responseTask = client.GetAsync("automovil/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Automovil resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Automovil>(resultItem.ToString());
                        resultAutomovil.Objects.Add(resultItemList);
                    }
                }
            }
            automovil.Automoviles = resultAutomovil.Objects;
            return View(automovil);      
        }

        [HttpGet]
        public ActionResult Form(int? IdAutomovil)
        {
            ML.Automovil automovil = new ML.Automovil();

            if(IdAutomovil == null)
            {
                return View(automovil);
            }
            else
            {
                ML.Result result = BL.Automovil.GetById(IdAutomovil.Value);
                if(result.Correct)
                {
                    automovil = ((ML.Automovil)result.Object);

                    return View(automovil);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }

        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            BinaryReader reader = new BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }

        [HttpPost]
        public ActionResult Form(ML.Automovil automovil)
        {
            HttpPostedFileBase file = Request.Files["ImagenData"];
            if (file.ContentLength > 0)
            {
                automovil.Imagen = ConvertToBytes(file);
            }

            var urlAPI = ConfigurationManager.AppSettings["URLapi"];

            if(automovil.IdAutomovil == 0) //Add
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Automovil>("automovil/Add", automovil);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "El automovil se registro correctamente.";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Message = "Favor de ingresar todos los datos.";
                        return PartialView("Modal");
                    }
                }

            }
            else if(automovil.IdAutomovil > 0) //Update
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);

                    //HTTP PUT
                    var postTask = client.PutAsJsonAsync<ML.Automovil>("automovil/Update/", automovil);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "El automovil se actualizó correctamente. ";
                    }
                }
            }
            else
            {
                ViewBag.Message = "El automovil no se pudo actualizar o agregar correctamente.";
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdAutomovil)
        {
            ML.Result resultListAutomovil = new ML.Result();
            var urlAPI = ConfigurationManager.AppSettings["URLapi"];

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);
                //HTTP DELETE
                var postTask = client.DeleteAsync("automovil/Delete/" + IdAutomovil);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    resultListAutomovil = BL.Automovil.GetAll();
                    ViewBag.Message = "El automovil se elimino correctamente.";
                }
                else
                {
                    ViewBag.Message = "El automovil no se pudo eliminar correctamente.";
                }
                resultListAutomovil = BL.Automovil.GetAll();

                return PartialView("Modal");
            }
        }
	}
}