using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CykelLib.model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CykelRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CyklerController : ControllerBase
    {
        // statisk liste til data
        private readonly static List<Cykel> Cykler = new List<Cykel>()
        {
            new Cykel(1, "rød", 3400, 10),
            new Cykel(2, "sort", 2800, 3),
            new Cykel(3, "sort", 4300, 12),
            new Cykel(4, "blå", 2700, 5),
            new Cykel(5, "lyseblå", 3600, 5),
            new Cykel(6, "rød", 13400, 18),

        };


        // GET: api/<CyklerController>
        [HttpGet]
        public IEnumerable<Cykel> Get()
        {
            return Cykler;
        }

        // GET api/<CyklerController>/5
        [HttpGet]
        [Route("{id}")]
        public Cykel Get(int id)
        {
            return Cykler.Find(c => c.Id == id);
        }

        // POST api/<CyklerController>
        [HttpPost]
        public void Post([FromBody] Cykel value)
        {
            value.Id = Cykler.Max(c => c.Id) + 1;
            Cykler.Add(value);
        }

        // PUT api/<CyklerController>/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] Cykel value)
        {
            Cykel c = Get(id);
            if (c == null)
                return; // ingen cykel med id

            c.Farve = value.Farve;
            c.Pris = value.Pris;
            c.Gear = value.Gear;
        }

        // DELETE api/<CyklerController>/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Cykel c = Get(id);
            if (c == null)
                return; // ingen cykel med id

            Cykler.Remove(c);
        }
    }
}
