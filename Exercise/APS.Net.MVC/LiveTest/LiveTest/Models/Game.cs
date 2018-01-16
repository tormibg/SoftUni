using System.Collections.Generic;

namespace LiveTest.Models
{
    public class Game
    {
        public Game()
        {
            this.Owners = new HashSet<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public virtual ICollection<User> Owners { get; set; }
    }
}