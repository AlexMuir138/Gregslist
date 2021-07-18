using Gregslist.Models;
using Gregslist.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
      private readonly CarsService _cs;
      public CarsController(CarsService cs)
      {
        _cs = cs;
      }
      [HttpGet]
        public List<Car> GetCars()
        {
            return _cs.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
          try
          {
            var car = _cs.GetCarById(id);
            if(car == null)
            {
              return BadRequest("Invalid ID");
            }
            return Ok(car);
          }catch (System.Exception e)
          {
            return Forbid(e.Message);
          }
        }
        [HttpPost]
        public ActionResult<Car> CreateCar([FromBody] Car carData)
        {
            try
            {
                var car = _cs.createCar(carData);
                return Created("api/cars/" + car.Id, car);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Car> EditCar([FromBody] Car carData, int id)
        {
          try
          {
            Car car = _cs.updateCar(carData, id);
              return Ok(carData);
          }
          catch (System.Exception e)
          {
              return BadRequest(e.Message);
          }
        }

        [HttpDelete("{id}")]
        public ActionResult<Car> RemoveCar(int id)
        {
          try
          {
              var car = _cs.removeCar(id);
              return Ok(car);
          }
          catch (System.Exception e)
          {
              return BadRequest(e.Message);
          }
        }

      
    }
}