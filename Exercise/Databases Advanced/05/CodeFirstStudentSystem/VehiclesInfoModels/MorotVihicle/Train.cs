using System.Collections.Generic;
using VehiclesInfoModels.NonMotorVihicle;

namespace VehiclesInfoModels.MorotVihicle
{
    public class Train : MotorVehicle
    {
        public Train()
        {
            this.Carriages = new HashSet<Carriage>();
        }
        public virtual Locomotive Locomotive { get; set; }

        public int NumberOfCarriages { get; set; }

        public virtual ICollection<Carriage> Carriages { get; set; }
    }
}