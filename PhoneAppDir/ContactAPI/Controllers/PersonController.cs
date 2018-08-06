using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using PhoneContactLibrary;

namespace ContactAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class PersonController : ApiController
    {
        
        //READ
        [HttpGet]
       // public IEnumerable<Person> Get()
        // {

            //return person;
        // }
        //ADD Person
        [HttpPost]
        public IHttpActionResult Post(Person p)
        {
            if (p != null)
            {
                // Make a call to CRUD Method to insert in to DB
                return Ok();
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
