using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LaMiaPizzeriaEfPost.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<Pizza> Pizzas { get; set; }

        public Ingredient ()
        {

        }
    }
}
