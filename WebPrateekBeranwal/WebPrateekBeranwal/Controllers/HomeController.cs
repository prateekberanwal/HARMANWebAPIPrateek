using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebPrateekBeranwal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SavePerson(PersonModel person)
        {                      
            string baseUri = Convert.ToString(ConfigurationManager.AppSettings["APIBaseUri"]); 
            int Personid = 0;  
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(baseUri);
               
                    //WebAPI Authentication
                    client.DefaultRequestHeaders.Add("Authorization", "Basic + UserName : Pwd ");
                    
                    HttpResponseMessage response = await client.PostAsXmlAsync<PersonModel>("Values/CreatePerson/", person);
                    ////  client.PostAsync()
                    if (response.IsSuccessStatusCode)
                    {
                        Personid =await response.Content.ReadAsAsync<int>();                       
                    }
                    else
                    {
                        throw new Exception(Convert.ToString(response.StatusCode));
                    }
                }
                catch (AggregateException)
                {
                    throw;
                }
            }
            return Json(Personid + " Created Successfully");
        }
        [HttpGet]
        public async Task <ActionResult> GetPerson( int PersonId=0)
        {
            PersonModel  p = new PersonModel();
            string baseUri = Convert.ToString(ConfigurationManager.AppSettings["APIBaseUri"]);
            try
            {
                if (PersonId != 0)
                {

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(baseUri);
                        
                        //WebAPI Authentication
                        client.DefaultRequestHeaders.Add("Authorization", "Basic + UserName : Pwd ");
                        HttpResponseMessage response = await client.GetAsync("Values/GetPerson?id=" + PersonId);

                        if (response.IsSuccessStatusCode)
                        {
                            p = await response.Content.ReadAsAsync<PersonModel>();
                        }
                    }
                }
              
                return View(p);
            }
            catch (Exception)
            {
                throw;
            }         
        }
    }
}