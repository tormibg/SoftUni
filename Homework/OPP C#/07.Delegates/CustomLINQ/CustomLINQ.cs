using System;
using System.Collections.Generic;

namespace CustomLINQ
{
    class CustomLINQ
    {
        static void Main()
        {
            List<int> nums = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var filterCol = nums.WhereNot1(x => x % 2 == 0);

            Console.WriteLine(String.Join(", ",filterCol));

            Console.WriteLine();

            var filterCol1 = nums.WhereNot1(x => x%2 == 0);

            Console.WriteLine(String.Join(", ", filterCol1));

            Console.WriteLine();
            var filterCol2 = nums.WhereNot2(x => x % 2 == 0);

            Console.WriteLine(String.Join(", ", filterCol2));

            Console.WriteLine();

            var students = new List<Student>
            {
                new Student("Pesho", 3),
                new Student("Ivan", 5),
                new Student("Asen", 10),
                new Student("Zamen", 2),
            };
            Console.WriteLine(students.Maxi(s => s.Grade));
        }
    }
}
