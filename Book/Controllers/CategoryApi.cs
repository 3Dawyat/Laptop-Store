using Book.Models;
using Book.Bl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApi : ControllerBase
    {
        ICategoryServes categoryServes;
        public CategoryApi(ICategoryServes serves)
        {
            categoryServes = serves;
        }
        // GET: api/CategoryApi
        [HttpGet]
        public IEnumerable<TbCategory> Get()
        {
            return categoryServes.GetAll();
        }
        // GET api/<CategoryApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<CategoryApi>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        // PUT api/<CategoryApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // DELETE api/<CategoryApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
