using LaMiaPizzeriaEfPost.Database;
using LaMiaPizzeriaEfPost.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeriaEfPost.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PizzaAPIController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            using(PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizzaApi= new List<Pizza>();

                if(search == null || search == "")
                {
                    pizzaApi = db.Pizzas.Include(pizzaApi => pizzaApi.Ingredients).ToList();
                }
                else
                {
                    search = search.ToLower();

                    pizzaApi = db.Pizzas.Where(pizzaApi => pizzaApi.nome.ToLower().Contains(search)).Include(pizzaApi => pizzaApi.Ingredients).ToList();
                }

                return Ok(pizzaApi);
            }
        }
        
        [HttpGet("{nome}")]
        public IActionResult GetDetails(string? nome)
        {

            using(PizzaContext db = new PizzaContext())
            {
                Pizza pizzaApi = db.Pizzas.Where(pizzaApi => pizzaApi.nome == nome).FirstOrDefault();

                if(pizzaApi == null)
                {
                    return NotFound("La pizza non è stata trovata");
                }

                return Ok(pizzaApi);
            }

        }
        
    }
}
