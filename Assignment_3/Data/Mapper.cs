using Assignment_3.Models;
using Assignment_3.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Data
{
    public class Mapper
    {
        public ReservationReadDto Map(Reservation reservation)
        {
            return new ReservationReadDto { 
                Id = reservation.Id,
                Date = reservation.Date,
                Name = reservation.Name
            };
        }
        public MenuItem Map(MenuItemCreateDto input)
        {
            return new MenuItem
            {
                Name = input.Name,
                Price = input.Price
            };
        }
        //public MenuItemCreateDto Map(MenuItem input)
        //{
        //    return new MenuItemCreateDto
        //    {
        //        Name = input.Name,
        //        Price = input.Price
        //    };
        //}


        public MenuItem Map(MenuItemReadDto input)
        {
            return new MenuItem { 
                Id = input.Id,
                Name = input.Name,
                Price = input.Price
            };
        }

        public MenuItemReadDto Map(MenuItem input)
        {
            return new MenuItemReadDto
            {
                Id = input.Id,
                Name = input.Name,
                Price = input.Price
            };
        }
    }
}
