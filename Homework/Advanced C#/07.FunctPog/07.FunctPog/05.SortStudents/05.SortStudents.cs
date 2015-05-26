/*Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order. Rewrite the same with LINQ query syntax.*/

using System;
using System.Collections.Generic;
using System.Linq;

class SortStudents
{
    static void Main()
    {
        List<ClassStudentCS.Student> studentsList = ClassStudentCS.Student.AddStudent();

        var sortStudents = from st in studentsList orderby st.FirstName descending , st.LastName descending select st;

        Console.WriteLine("LinQ syntax\n");
        foreach (var st in sortStudents)
        {
            Console.WriteLine(st);
        }

        var sortNewStudents = studentsList.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName).ToList();
        Console.WriteLine("\nMethod syntax\n");
        foreach (var student in sortNewStudents)
        {
            Console.WriteLine(student);
        }
    }
}