using System;
using System.Collections.Generic;
using Gregslist.Data;
using Gregslist.Models;

namespace Gregslist.Services
{
   public class HousesService
   {
     public List<House> GetAll()
     {
       return FakeDb.Houses;
     }
     public House GetHouseById(int id)
        {
            return FakeDb.Houses.Find(h => h.Id == id);
        }
        public House createHouse(House houseData)
        {
          var r = new Random();
        houseData.Id = r.Next(100, 9999999);
        FakeDb.Houses.Add(houseData);
        return houseData;
        }
         public House removeHouse(int id)
      {
        var house = FakeDb.Houses.Find(h => h.Id == id);
        if(house == null)
        {
          throw new Exception("Invalid ID");
        }
        FakeDb.Houses.Remove(house);
        return house;
      }
      public House updateHouse(House houseData, int id)
      {
        House original = FakeDb.Houses.Find(h => h.Id == id);
        original.Bedrooms = houseData.Bedrooms;
        original.Bathrooms = houseData.Bathrooms;
        original.Year = houseData.Year;
        original.Price = houseData.Price;

        return original;
      }
   } 
}