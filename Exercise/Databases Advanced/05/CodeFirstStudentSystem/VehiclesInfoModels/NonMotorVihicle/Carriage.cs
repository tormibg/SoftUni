using VehiclesInfoModels.MorotVihicle;

namespace VehiclesInfoModels.NonMotorVihicle
{
    public class Carriage : NonMotorVehicle
    {
        public int PassengersCapacity { get; set; }

        public virtual Train Train { get; set; }
    }
}