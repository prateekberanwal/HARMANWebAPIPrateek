using BAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [BasicAuthAttribute]
    [APICustomHandleError]
    public class ValuesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetPerson(int id)
        {
            PersonBAL BAL = new PersonBAL();
            PersonModel p = BAL.GetPersonDetail(id);
            return Ok(p);
            //return new HttpResponseMessage(HttpStatusCode.OK)
            //{
            //    Content = new ObjectContent<Person>(p, new XmlMediaTypeFormatter(), new MediaTypeWithQualityHeaderValue("application/xml"))
            //};

        }

        [HttpPost]
        public HttpResponseMessage CreatePerson(PersonModel person)
        {
            int id = 0;
            PersonBAL BAL = new PersonBAL();
            id = BAL.SavePerson(person);
            return new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new ObjectContent<int>(id, new XmlMediaTypeFormatter(), new MediaTypeWithQualityHeaderValue("application/xml"))
            };
        }


    }
}
