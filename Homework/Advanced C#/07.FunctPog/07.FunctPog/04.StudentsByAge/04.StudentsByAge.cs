/*Write a LINQ query that finds the first name and last name of all students with age between 18 and 24. The query should return only the first name, last name and age.Write a LINQ query that finds the first name and last name of all students with age between 18 and 24. The query should return only the first name, last name and age.*/

using System;
using System.Collections.Generic;
using System.Linq;

internal class StudentsByAge
{
    private static void Main()
    {
        List<ClassStudentCS.Student> studentsList = ClassStudentCS.Student.AddStudent();

        var studentByAge = from st in studentsList
            where st.Age >= 18 && st.Age <= 24
            select new {st.FirstName, st.LastName, st.Age};

        foreach (var student in studentByAge)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName + " - " + student.Age);
        }
    }
}