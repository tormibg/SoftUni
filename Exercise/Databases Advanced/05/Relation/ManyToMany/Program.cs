using System.Linq;
using ManyToMany.Models;

namespace ManyToMany
{
    class Program
    {
        static void Main(string[] args)
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

            context.Subjects.Add(new Subject() {Name = "Math"});
            context.Subjects.Add(new Subject() {Name = "History"});

            context.SaveChanges();

            var studetns = context.Students;
            foreach (var studetn in studetns)
            {
                context.Subjects.First(subject => subject.Name == "Math").Students.Add(studetn);
                context.Subjects.First(subject => subject.Name == "History").Students.Add(studetn);
            }

            context.SaveChanges();
        }
    }
}
