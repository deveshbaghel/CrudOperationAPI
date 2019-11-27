using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MvcApplication2.DataAccessLayer;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class GetController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetEmployeeDetails()
        {
            Home objDB = new Home();
            return Content(HttpStatusCode.OK, objDB.Getdata());
        }
      
    }
}
