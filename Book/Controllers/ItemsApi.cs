using Book.Bl;
using Book.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsApi : ControllerBase
    {
        IItemServes itemServes;
        StoreWebSite2Context ctx;
        public  ItemsApi(IItemServes serves, StoreWebSite2Context context)
        {
            ctx = context;
            itemServes = serves;
        }
        // GET: /api/ItemsApi
        [HttpGet]
        public IEnumerable<VwItemCategories> Get()
        { 
            var items =itemServes.GetAllItem();
            return items;
        } 
        // GET api/<ItemsApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<ItemsApi>
        [HttpPost]
        public string Post([FromBody] TbItem item)
        {
            ctx.Add(item);
            ctx.SaveChanges();
            return "Succes";
        }
        // PUT api/<ItemsApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // DELETE api/<ItemsApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
