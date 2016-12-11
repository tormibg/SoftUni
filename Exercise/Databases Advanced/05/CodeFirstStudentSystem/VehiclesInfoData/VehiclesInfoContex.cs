using VehiclesInfoModels;
using VehiclesInfoModels.MorotVihicle;

namespace VehiclesInfoData
{
    using System.Data.Entity;

    public class VehiclesInfoContex : DbContext
    {
        public VehiclesInfoContex()
            : base("name=VehiclesInfoContex")
        {
        }

        public IDbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Train>().HasOptional(t => t.Locomotive).WithRequired(l => l.Train);
            base.OnModelCreating(modelBuilder);
        }
    }

}