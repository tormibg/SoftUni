using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MassDefect.Models
{
    public class Planet
    {
        public Planet()
        {
            this.Persons = new HashSet<Person>();
            this.OriginAnomalies = new HashSet<Anomalie>();
            this.TeleportAnomalies = new HashSet<Anomalie>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? SunId { get; set; }

        public virtual Star Sun { get; set; }

        public int? SolarSystemId { get; set; }

        public virtual SolarSystem SolarSystem { get; set; }

        public virtual ICollection<Person> Persons { get; set; }

        public virtual ICollection<Anomalie> OriginAnomalies { get; set; }

        public virtual ICollection<Anomalie> TeleportAnomalies { get; set; }
    }
}