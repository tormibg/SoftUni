using System;
using System.Collections.Generic;
using System.Linq;

class StudentsByFLN
{
    static void Main()
    {
        List<ClassStudentCS.Student> studentList = ClassStudentCS.Student.AddStudent();

        var LinqQuery = from st in studentList
            where st.FirstName.CompareTo(st.LastName) < 0
            select st;
        foreach (var student in LinqQuery)
        {
            Console.WriteLine(student);
        }
    }
}