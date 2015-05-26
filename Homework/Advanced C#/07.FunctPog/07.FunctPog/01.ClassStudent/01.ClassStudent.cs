using System;
using System.Collections.Generic;


namespace ClassStudentCS
{
    public class ClassStudent
    {
        private static void Main()
        {
            List<Student> studentsList = Student.AddStudent();
            foreach (var student in studentsList)
            {
                Console.WriteLine(student);
            }
        }
    }
}