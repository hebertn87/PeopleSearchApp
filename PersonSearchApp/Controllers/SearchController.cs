using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonSearchApp.Controllers
{
    [RoutePrefix("api/Search")]
    public class SearchController : ApiController
    {

        //[HttpGet]  
        [Route("GetPeople")]
        public IHttpActionResult GetPeople()
        {
            using (PeopleDBEntities context = new PeopleDBEntities())
            {
                var personList = context.People.ToList();
                return Ok(personList);
            }
        }

        //[HttpPost]  
        [Route("PostAddPerson")]
        public IHttpActionResult PostAddPerson(Person newPerson)
        {
            using (PeopleDBEntities context = new PeopleDBEntities())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var personObj = context.People.FirstOrDefault(p => p.id == newPerson.id);
                if (personObj != null)
                {
                    personObj.fname = newPerson.fname;
                    personObj.lname = newPerson.lname;
                    personObj.age = newPerson.age;
                    personObj.addr = newPerson.addr;
                    personObj.interests = newPerson.interests;
                    personObj.picture = newPerson.picture;
                }
                else
                {
                    context.People.Add(newPerson);
                }

                context.SaveChanges();

                return Ok();
            }
        }
    }
}
