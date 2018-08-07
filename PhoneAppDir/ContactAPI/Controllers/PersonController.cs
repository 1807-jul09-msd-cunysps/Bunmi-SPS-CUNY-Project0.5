using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using PhoneContactLibrary;
using SQLConnectionDAL;

namespace ContactAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class PersonController : ApiController
    {
        ConnectToSQL crud = new ConnectToSQL();
        //READ
        [HttpGet]
        public IHttpActionResult Get()
        {
            var person = crud.GET();
            return Json(person);
        }

        //ADD Person
        [HttpPost]
        public IHttpActionResult Post(Person p)
        {
            if (p != null)
            {
                crud.POST(p);
                return Ok("Person Added Successfully!!");
            }
            else
            {
                return BadRequest();
            }
        }
        // to do  Put

        // to do Delete

    }

}
