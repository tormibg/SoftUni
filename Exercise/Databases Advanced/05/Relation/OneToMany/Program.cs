using System.Linq;
using OneToMany.Models;

namespace OneToMany
{
    class Program
    {
        static void Main()
        {
            var context = new WorldContext();
            context.Database.Initialize(true);

            context.Students.Add(new Student() { Name = "Ilia", StudentAddress = new StudentAddress() { Address = "Niakade tam" } });

            context.Students.Add(new Student() { Name = "Ivan", StudentAddress = new StudentAddress() { Address = "Tuk Tam" } });

            var studentsAll = context.Students;
            context.Schools.Add(new School() { Name = "33 Sou" });
            foreach (var student in studentsAll)
            {
                context.Schools.First().Students.Add(student);
            }

            context.SaveChanges();
        }
    }
}
