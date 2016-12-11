using System.Collections.Generic;

namespace MassDefect.Models
{
    public class Anomalie
    {
        public Anomalie()
        {
            this.Persons = new HashSet<Person>();
        }
        public int Id { get; set; }

        public int? OriginPlanetId { get; set; }

        public int? TeleportPlanetId { get; set; }

        public virtual Planet OriginPlanet  { get; set; }

        public virtual Planet TeleportPlanet { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}