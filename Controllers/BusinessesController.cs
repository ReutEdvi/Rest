using ResturantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResturantApp.Controllers
{
    public class BusinessesController : ApiController
    {
        // GET api/<controller>
        public List<Businesses> Get(string category)
        {
            Businesses b = new Businesses();
            return b.Read(category);
            //Businesses businesses = new Businesses();
            //List<Businesses> fList = businesses.Read();
            //return fList;
        }
        public Businesses Get(int id)
        {
            Businesses ca = new Businesses();
            return ca.ReadCamp(id);

        }
        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

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