/*Problem 6.	Filter Students by Email Domain
Print all students that have email @abv.bg. Use LINQ.*/

using System;
using System.Collections.Generic;
using System.Linq;

class FilterStudentsEmailDomain
{
    static void Main()
    {
        List<ClassStudentCS.Student> studentsList = ClassStudentCS.Student.AddStudent();

        var sortED = from st in studentsList where st.Email.Substring(st.Email.IndexOf("@")) == "@abv.bg" select st;

        foreach (var st in sortED)
        {
            Console.WriteLine(st + " - " + st.Email);
        }
    }
}