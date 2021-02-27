using ResturantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResturantApp.Controllers
{
    public class CustomerController : ApiController
    {
        // GET api/<controller>
        //public List<Customer> Get(string email, string password)
        //{
        //    Customer c = new Customer();
        //    List <Customer> cl= c.Read(email, password);
        //    return cl;
        //}
        public void Post(string email, List<Highlights> highlights)
        {
            Customer c = new Customer();
            c.SaveHighlightCustomer(email, highlights);
            //return businesses;
        }
        public void Post([FromBody] Customer cr)
        {
            cr.InsertC();
            //return businesses;
        }
        public Customer Get(string email, string password)
        {
            Customer c = new Customer();
            return c.Read(email, password);
            


        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}