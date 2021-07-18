using System.Collections.Generic;
using Gregslist.Models;
using Gregslist.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gregslis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {
      private readonly HousesService _hs;
      public HousesController(HousesService hs)
      {
        _hs = hs;
      }
      [HttpGet]
        public List<House> GetHouses()
        {
            return _hs.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<House> GetHouse(int id)
        {
          try
          {
              var house = _hs.GetHouseById(id);
              if(house == null)
              {
                return BadRequest("Invalid ID");
              }
              return Ok(house);
          }
          catch (System.Exception e)
          {
             return Forbid(e.Message);
          }
        }
        [HttpPost]
        public ActionResult<House> CreateHouse([FromBody] House houseData)
        {
          try
          {
              var house = _hs.createHouse(houseData);
              return Created("api/houses/" + house.Id, house);
          }
          catch (System.Exception e)
          {
              return BadRequest(e.Message);
          }
        }
        [HttpPut("{id}")]
        public ActionResult<House> EditHouse([FromBody] House houseData, int id)
        {
          try
          {
             var house = _hs.updateHouse(houseData, id);
             return Ok(houseData);
          }
          catch (System.Exception e)
          {
              return BadRequest(e.Message);
          }
        }
        [HttpDelete("{id}")]
        public ActionResult<House> RemoveHouse(int id)
        {
          try
          {
              var house = _hs.removeHouse(id);
              return Ok(house);
          }
          catch (System.Exception e)
          {
              return BadRequest(e.Message);
          }
        }

    }
}