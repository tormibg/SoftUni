/*Problem 8.	Excellent Students
Print all students that have at least one mark Excellent (6). Using LINQ first select them into a new anonymous class that holds { FullName + Marks}.*/

using System;
using System.Collections.Generic;
using System.Linq;

class ExcellentStudents
{
    static void Main()
    {
        List<ClassStudentCS.Student> studentsList = ClassStudentCS.Student.AddStudent();

        var exellSt = from st in studentsList where st.Marks.Contains(6) select new {FullName = string.Join(" ",st.FirstName,st.LastName), Marks = string.Join(", ",st.Marks)};

        foreach (var student in exellSt)
        {
            Console.WriteLine(student.FullName + " - {" + student.Marks + "}");
        }

    }
}