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
    public class DeleteController : ApiController
    {
        [HttpPost]
        [Route("api/Delete/DeleteRecord")]
        public IHttpActionResult DeleteRecord(string ID)
        {
            Home objDB = new Home();
            int statyu = objDB.Delete(ID);
            return Content(HttpStatusCode.OK, statyu);
        }
    }
}
