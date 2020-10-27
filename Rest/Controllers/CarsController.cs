using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lib;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rest.Controllers
{
    [Route("api/localCars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static readonly List<Car> Cars = new List<Car>
        {
            new Car {Id=1, Model = "Amazon", Vendor = "Volvo", Price = 12345},
            new Car {Id=2, Model = "A8", Vendor = "Audi", Price = 2222222},
            new Car {Id=3, Model = "Punto", Vendor = "Fiat", Price = 102022}
        };

        private static int _nextId = 4;
        // GET: api/<CarsController>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return Cars;
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return Cars.Find(p=> p.Id == id);
        }

        // POST api/<CarsController>
        [HttpPost]
        public int Post([FromBody] Car value)
        {
            value.Id = _nextId++;
            Cars.Add(value);
            return value.Id;
        }

        [HttpPut("{id}")]
        public ActionResult<Car> Put(int id, [FromBody] Car car)
        {
            Car c = Cars.FirstOrDefault(c1 => c1.Id == id);
            if (c == null) { return NoContent(); }
            c.Vendor = car.Vendor;
            c.Model = car.Model;
            c.Price = car.Price;
            return c;
        }
        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Car p = Get(id);
            if (p != null)
            {
                Cars.Remove(p);
            }
        }

        [HttpGet]
        [Route("Vendor/{substring}")]
        public IEnumerable<Car> GetFromVendor(string substring)
        {
            var list = Cars.FindAll(i => i.Vendor.ToLower().Contains(substring.ToLower()));
            return list;

        }
    }
}
