using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class AutomovilController : ApiController
    {
        // GET api/automovil
        [Route("api/automovil/GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Automovil.GetAll();
            if(result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        // GET api/automovil/5
        [Route("api/automovil/{IdAutomovil}")]
        [HttpGet]
        public IHttpActionResult GetById(int IdAlumno)
        {
            ML.Result result = BL.Automovil.GetById(IdAlumno);
            if(result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        // POST api/automovil
        [Route("api/automovil/Add")]
        [HttpPost]
        public IHttpActionResult Add([FromBody]ML.Automovil alumno)
        {
            ML.Result result = BL.Automovil.Add(alumno);
            if(result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        // PUT api/automovil/5
        [Route("api/automovil/Update/")]
        [HttpPut]
        public IHttpActionResult Update([FromBody]ML.Automovil alumno)
        {
            ML.Result result = BL.Automovil.Update(alumno);
            if(result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        // DELETE api/automovil/5
        [Route("api/automovil/{IdAutomovil}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdAlumno)
        {
            ML.Result result = BL.Automovil.Delete(IdAlumno);
            if(result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
