using System.ComponentModel.DataAnnotations.Schema;

namespace InheritCars.Models
{
    public class Car
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }
    }
}