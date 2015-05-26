using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class FilterStudentsPhone
{
    static void Main()
    {
        List<ClassStudentCS.Student> studentsList = ClassStudentCS.Student.AddStudent();

        string pattern = @"^\+359\s?2?|^02";
        var rx = new Regex(pattern);

        var studPhone = from st in studentsList where rx.IsMatch(st.Phone) select st;

        foreach (var student in studPhone)
        {
            Console.WriteLine(student + " - " + student.Phone);
        }
    }
}