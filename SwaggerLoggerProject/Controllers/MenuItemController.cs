using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwaggerLoggerProject.Data;
using SwaggerLoggerProject.Models;
using SwaggerLoggerProject.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SwaggerLoggerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly AppDbContext _dbc = new AppDbContext();
        private readonly ILogger<MenuItemController> _logger;

        public MenuItemController(ILogger<MenuItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            return _dbc.MenuItems.ToList();
        }

        [HttpGet("{id}")]
        public MenuItem Get(int id)
        {
            return _dbc.MenuItems.Find(id);
        }

        [HttpPost]
        public void Post([FromBody] MenuItemViewModel value)
        {
            int id = _dbc.MenuItems.Last().Id + 1;

            MenuItem mi = new MenuItem { 
                Id = id,
                Name = value.Name,
                Price = value.Price,
                //Image = value.Image
            };

            _dbc.MenuItems.Add(mi);
            _dbc.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MenuItem value)
        {
            MenuItem mi = _dbc.MenuItems.Where(m => m.Id == id)
                                       .FirstOrDefault();

            if (mi != null)
            {
                mi.Name = value.Name;
                mi.Price = value.Price;

                _dbc.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MenuItem mi = _dbc.MenuItems.Find(id);
            _dbc.MenuItems.Remove(mi);
            _dbc.SaveChanges();
        }
    }
}
