namespace VehiclesInfoModels.MorotVihicle
{
    public class Locomotive : MotorVehicle
    {
        public int Power { get; set; }
        public virtual Train Train { get; set; }
    }
}