using System;

namespace StudentMain
{
    class StudentMain
    {
        static void Main()
        {
            Student student = new Student("Ivan",22);

            student.PropertyChanged += (sender, args) =>
            {
                Console.WriteLine("Property changed : {0} (from {1} to {2})", args.Type, args.OldValue, args.NewValue);
            };

            student.Name = "Pesho";
            student.Name = "Ana";
            student.Age = 30;

            Console.WriteLine(student);
        }
    }
}
