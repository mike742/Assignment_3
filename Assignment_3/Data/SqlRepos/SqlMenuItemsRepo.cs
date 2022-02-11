using Assignment_3.Data.Interfaces;
using Assignment_3.Models;
using Assignment_3.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Data.SqlRepos
{
    public class SqlMenuItemsRepo : IMenuItemsRepo
    {
        private readonly AppDbContext _context;
        private readonly Mapper _mapper = new Mapper();

        public SqlMenuItemsRepo(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<MenuItemReadDto> GetAll()
        {
            return _context.MenuItems.Select(mi => _mapper.Map(mi));
        }

        public MenuItemReadDto GetById(int id)
        {
            var menuItemInDb = _context.MenuItems.FirstOrDefault(mi => mi.Id == id);

            if (menuItemInDb != null)
            {
                return _mapper.Map(menuItemInDb);
            }

            return null;
        }
    }
}
