/*Problem 10.	Students Enrolled in 2014
Extract and print the Marks of the students that enrolled in 2014 (the students from 2014 have 14 as their 5-th and 6-th digit in the FacultyNumber).*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class StudentsEnrolled2014
{
    static void Main()
    {
        List<ClassStudentCS.Student> studentsList = ClassStudentCS.Student.AddStudent();

        string pattern = @"(?<=\d{4})14";
        var rx = new Regex(pattern);

        var stud2004 = from st in studentsList where rx.IsMatch(st.FacultyNumber.ToString()) select st;

        foreach (var student in stud2004)
        {
            Console.WriteLine("{0} - {1}",student,student.FacultyNumber);
        }
    }
}