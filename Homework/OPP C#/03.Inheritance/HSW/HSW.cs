using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace HSW
{
    class HSW
    {
        static void Main()
        {
            List<Student> listStudents = new List<Student>()
            {
                new Student("Ivan", "Ivanov", "543253dsda"),
                new Student("Pet", "Ninja", "7645dsad"),
                new Student("Gal", "Kene", "897640gnf"),
                new Student("Pop", "Popov", "56342hgfd"),
                new Student("Ger", "Garo", "7634hjgf"),
                new Student("Ivan", "Nikon", "34287hd"),
                new Student("Tot", "Totev", "432432hgf"),
                new Student("Nik", "Niko", "54237kgju"),
                new Student("Lil", "Lilov", "54235hjgf"),
                new Student("Tit", "Titov", "4235234ghd"),
            };

            // Linq method
            var ordSt = from element in listStudents orderby element.FacNum select element;

            //test sort
            //foreach (var student in ordSt)
            //{
            //    Console.WriteLine(student.FacNum);
            //}

            // OrderBy method
           // ordSt = listStudents.OrderBy(student => student.FacNum, StringComparer.InvariantCulture);

            IList<Worker> listWorkers = new List<Worker>()
            {
                new Worker("Ingo", "Ingov", 12.5f, 8),
                new Worker("Asen", "Asenov", 15f, 9),
                new Worker("Mit", "Mitov", 11f, 8),
                new Worker("Wer", "Wergov", 12.5f, 7),
                new Worker("Det", "Detov", 10f, 8),
                new Worker("Cec", "Cecov", 13f, 6),
                new Worker("Val", "Valev", 12.5f, 6),
                new Worker("Bob", "Bobev", 20f, 8),
                new Worker("Xor", "Xorov", 15f, 7),
                new Worker("Koko", "Kokov", 11.5f, 8),
            };

            // test before sort
            //foreach (var val in listWorkers)
            //{
            //    Console.WriteLine(val.MoneyPerHour());
            //}
            //Console.WriteLine();

            //Linq sort
            var ordWr = from element in listWorkers orderby element.MoneyPerHour() select element;

            //test after sort
            //foreach (var val in ordWr)
            //{
            //    Console.WriteLine(val.MoneyPerHour());
            //}

            var allHuman =
                (from studen in ordSt select new {FirstName = studen.FirstName, LastName = studen.LastName}).Union(
                    from worker in ordWr select new {FirstName = worker.FirstName, LastName = worker.LastName})
                    .OrderBy(x => x.FirstName+x.LastName)
                    .ToList();

            // test after merge and sort
            foreach (var hum in allHuman)
            {
                Console.WriteLine(hum.FirstName + " "+ hum.LastName);
            }
        }
    }
}
