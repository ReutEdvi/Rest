using ResturantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResturantApp.Controllers
{
    public class CampaignController : ApiController
    {
        public List<Campaign> Get()
        {
            Campaign c = new Campaign();
            return c.Read();

        }
        public void Post([FromBody] Campaign campaign)
        {
            //return campaign.Insert();
            campaign.Insert();
        }

        //public void Put([FromBody] Campaign cr)
        //{
        //    Campaign c = new Campaign();
        //    c.InsertAmount(cr);

        //}
        public Campaign Put([FromBody] Campaign cr)
        {
            return cr.Update();            

        }
        //public void Post([FromBody] Campaign campaign)
        //{
        //    //return campaign.Insert();
        //    campaign.Insert();
        //}
        //public Businesses Get(int id)
        //{
        //    Businesses ca = new Businesses();
        //    return ca.ReadCamp(id);

        //}
        // GET api/<controller>

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