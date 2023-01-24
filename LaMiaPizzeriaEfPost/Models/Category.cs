using LaMiaPizzeriaEfPost.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LaMiaPizzeriaEfPost.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }

        public string categoria { get; set; }

        [JsonIgnore]
        public List<Pizza> Pizzas { get; set; }

        public Category()
        {

        }
    }
}
