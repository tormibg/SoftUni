using System;
using System.Linq;
using StudentSystemData;

namespace CodeFirstStudentSystem
{
    class Client
    {
        static void Main()
        {
            var context = new StudentSystemContext();
            //context.Database.Initialize(true);
            //GetAllStudentAndHomework(context);
            //GetAllCourses(context);
            //GetCoursesByResourse(context, 2);
            //GetActiveCourses(context, DateTime.Now);
            //GetStudentCoursesPrice(context);
        }

        private static void GetStudentCoursesPrice(StudentSystemContext context)
        {
            var students = context.Students.OrderByDescending(s => s.Courses.Sum(c => c.Price))
                .ThenByDescending(s => s.Courses.Count)
                .ThenBy(s => s.Names);
            foreach (var student in students)
            {
                Console.WriteLine($"- {student.Names} : {student.Courses.Count} : {student.Courses.Sum(x => x.Price)} : {student.Courses.Average(s => s.Price)}");
            }
        }

        private static void GetActiveCourses(StudentSystemContext context, DateTime now)
        {
            var courses = context.Courses.Where(c => c.EndDate >= now && c.StartDate <= now);
            foreach (var course in courses)
            {
                Console.WriteLine($"- {course.Name} : {course.Students.Count}");
            }
        }

        private static void GetCoursesByResourse(StudentSystemContext context, int i)
        {
            var courses =
                context.Courses.Where(x => x.Resources.Count > i)
                    .OrderByDescending(x => x.Resources.Count)
                    .ThenByDescending(x => x.StartDate);

            foreach (var course in courses)
            {
                Console.WriteLine($"- {course.Name} : {course.Resources.Count}");
            }
        }

        private static void GetAllCourses(StudentSystemContext context)
        {
            var courses = context.Courses.OrderBy(c => c.StartDate).OrderByDescending(c => c.EndDate);
            foreach (var course in courses)
            {
                Console.WriteLine($"- {course.Name} : {course.Description}");
                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"---- {resource.Name}, {resource.Url}, {resource.ResourceType}");
                }
            }
        }

        private static void GetAllStudentAndHomework(StudentSystemContext context)
        {
            var students = context.Students;
            foreach (var student in students)
            {
                Console.WriteLine($"-{student.Names}");
                foreach (var homework in student.Homeworks)
                {
                    Console.WriteLine($"---- {homework.Content} : {homework.ContentType}");
                }
            }
        }
    }
}
