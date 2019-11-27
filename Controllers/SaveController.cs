using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApplication2.DataAccessLayer;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class SaveController : ApiController
    {
       
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok("");
        }

        [HttpPost]
        [Route("api/Save/SaveCustomer")]
        public IHttpActionResult SaveCustomer(Employee ObjEmp)
        {
            Home objDB = new Home();
            //Employee ObjEmp = new Employee();
            string result = objDB.InsertData(ObjEmp);
            return Content(HttpStatusCode.OK, result);
        }
     
      
    }
}
