using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Obligatorisk1._1;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obl1._4.Controllers
{
    [Route("api/bike")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        //data
        private static List<Bike> _data = new List<Bike>()
        {
            new Bike (1,"rød",200,30),
            new Bike (2,"Grøn",500,5),
            new Bike (3,"Grøn",10000,20)
        };
        // GET: api/<BikeController>
        [HttpGet]
        public IEnumerable<Bike> Get()
        {
            return _data;
        }

        // GET api/<BikeController>/5
        [HttpGet("{id}")]
        public Bike Get(int ID)
        {
            return _data.Find(i => i.ID == ID);
        }

        // POST api/<BikeController>
        [HttpPost]
        public void Post([FromBody] Bike value)
        {
            _data.Add(value);
        }

        // PUT api/<BikeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Bike value)
        {
            Bike bike = Get(id);
            if (bike != null)
            {
                bike.ID = value.ID;
                bike.Color = value.Color;
                bike.Price = value.Price;
                bike.Gear = value.Gear;
            }
        }


        // DELETE api/<BikeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Bike bike = Get(id);
            _data.Remove(bike);
        }
    }
}
