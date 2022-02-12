using Assignment_3.Models;
using Assignment_3.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Data.Interfaces
{
    public interface IMenuItemsRepo
    {
        public IEnumerable<MenuItemReadDto> GetAll();
        public MenuItemReadDto GetById(int id);
        public void Create(MenuItemCreateDto input);
        public void Update(int id, MenuItemCreateDto input);
        public void Delete(int id);
    }
}
