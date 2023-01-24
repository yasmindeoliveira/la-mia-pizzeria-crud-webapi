using LaMiaPizzeriaEfPost.Database;
using LaMiaPizzeriaEfPost.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeriaEfPost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaAPIController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using(PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizzaApi = db.Pizzas.Include(pizzaApi => pizzaApi.Ingredients).ToList();

                return Ok(pizzaApi);
            }
        }
    }
}
