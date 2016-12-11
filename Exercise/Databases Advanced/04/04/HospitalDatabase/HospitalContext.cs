using HospitalDatabase.Models;

namespace HospitalDatabase
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
            : base("name=HospitalContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<HospitalContext>());
            //this.Database.Initialize(true);
        }

        public IDbSet<Diagnose> Diagnoses { get; set; }
        public IDbSet<Medicament> Medicaments { get; set; }
        public IDbSet<Visitation> Visitations { get; set; }
        public IDbSet<Patient> Patients { get; set; }

        public IDbSet<Doctor> Doctors { get; set; }
    }

}