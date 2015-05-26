/*Problem 9.	Weak Students
Write a similar program to the previous one to extract the students with exactly two marks "2". Use extension methods.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

class WeakStudents
{
    private static void Main()
    {
        List<ClassStudentCS.Student> studentsList = ClassStudentCS.Student.AddStudent();

        var weakStudents = from st in studentsList where st.Marks.FindAll(x => x.Equals(2)).Count == 2 select st;

        foreach (var student in weakStudents)
        {
            Console.WriteLine("{0} {1} match {2} - {{{3}}}",student.FirstName, student.LastName, student.Marks.FindAll(x => x.Equals(2)).Count,string.Join(", ",student.Marks));
        }
    }
}