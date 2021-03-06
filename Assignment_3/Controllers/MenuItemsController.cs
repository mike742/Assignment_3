using Assignment_3.Data.Interfaces;
using Assignment_3.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private IMenuItemsRepo _repo;
        public MenuItemsController(IMenuItemsRepo repo)
        {
            _repo = repo;
        }
        // GET: api/<MenuItemsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_repo.GetAll());
        }

        // GET api/<MenuItemsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var mi = _repo.GetById(id);

            if (mi != null)
            {
                return Ok(mi);
            }

            return NotFound();
        }

        // POST api/<MenuItemsController>
        [HttpPost]
        public ActionResult Post(MenuItemCreateDto value)
        {
            _repo.Create(value);
            return Ok();
        }

        // PUT api/<MenuItemsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, MenuItemCreateDto value)
        {
            _repo.Update(id, value);
            return Ok();
        }

        // DELETE api/<MenuItemsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _repo.Delete(id);

            return Ok();
        }
    }
}
