using System;
using System.Collections.Generic;
using System.Linq;

    class StudentsByGroup
    {
        static void Main()
        {
            List<ClassStudentCS.Student> studentsList = ClassStudentCS.Student.AddStudent();
            var LinqQuery = from student in studentsList
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            foreach (var st in LinqQuery)
            {
                Console.WriteLine(st +" "+st.GroupNumber);
            }
        }
    }