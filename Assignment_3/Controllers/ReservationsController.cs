using Assignment_3.Data;
using Assignment_3.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly Mapper _mapper = new Mapper();

        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var reservations = _context
                .Reservations
                .Select(r => _mapper.Map(r))
                .ToList();
            var menuItems = _context
                .MenuItems
                .Select(mi => _mapper.Map(mi))
                .ToList();
            var reservationMenuItems = _context.ReservationMenuItems.ToList();

            foreach (var res in reservations)
            {
                List<MenuItemReadDto> menuItemsToAdd = new List<MenuItemReadDto>();

                foreach (var rmi in reservationMenuItems)
                {
                    if (rmi.ReservationId == res.Id)
                    {
                        var mi = _context.MenuItems
                            .FirstOrDefault(e => e.Id == rmi.MenuItemId);
                        if (mi != null)
                        {
                            menuItemsToAdd.Add(_mapper.Map(mi));
                        }
                    }
                }

                res.MenuItems = menuItemsToAdd;
            }

            return Ok(reservations);
        }
    }
}
