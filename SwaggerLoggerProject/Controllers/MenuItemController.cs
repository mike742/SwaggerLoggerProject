using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwaggerLoggerProject.Data;
using SwaggerLoggerProject.Models;
using SwaggerLoggerProject.ViewModels;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<MenuItemController>
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
           /*
            _logger.LogInformation("The Get MenuItem was invoked!");
            _logger.LogWarning("This is Warning!");
            _logger.LogError("This is Error");
            _logger.LogCritical("This is something critical!!!");
           */
            return _dbc.MenuItems.ToList();
        }

        // GET api/<MenuItemController>/5
        [HttpGet("{id}")]
        public MenuItem Get(int id)
        {
            return _dbc.MenuItems.Find(id);
        }

        // POST api/<MenuItemController>
        [HttpPost]
        public void Post([FromBody] MenuItemViewModel value)
        {
            int id = _dbc.MenuItems.Last().Id + 1;

            MenuItem mi = new MenuItem { 
                Id = id,
                Name = value.Name,
                Price = value.Price
            };

            _dbc.MenuItems.Add(mi);
            _dbc.SaveChanges();
        }

        // PUT api/<MenuItemController>/5
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

        // DELETE api/<MenuItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MenuItem mi = _dbc.MenuItems.Find(id);
            _dbc.MenuItems.Remove(mi);
            _dbc.SaveChanges();
        }
    }
}
