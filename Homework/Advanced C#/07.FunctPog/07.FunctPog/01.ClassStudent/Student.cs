using System.Collections.Generic;

namespace StudentCS
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int FacultyNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public int GroupNumber { get; set; }

        public Student(
            string firsName,
            string lastName,
            int age,
            int facultyNumber,
            string phone,
            string email,
            List<int> marks,
            int groupNumber)
        {
            this.FirstName = firsName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public List<Student> AddStudent()
        {
            var student = new List<Student>()
            {
                new Student("Dim", "Dimov", 19, 1, "+35926123456", "dim.dimov@abv.bg", new List<int>() {7, 3, 6, 6, 3}, 1),
                new Student("Dim", "Dimov", 19, 1, "+35926123456", "dim.dimov@abv.bg", new List<int>() {7, 3, 6, 6, 3}, 1),
                new Student("Dim", "Dimov", 19, 1, "+35926123456", "dim.dimov@abv.bg", new List<int>() {7, 3, 6, 6, 3}, 1),
                new Student("Dim", "Dimov", 19, 1, "+35926123456", "dim.dimov@abv.bg", new List<int>() {7, 3, 6, 6, 3}, 1),
                new Student("Dim", "Dimov", 19, 1, "+35926123456", "dim.dimov@abv.bg", new List<int>() {7, 3, 6, 6, 3}, 1),
                new Student("Dim", "Dimov", 19, 1, "+35926123456", "dim.dimov@abv.bg", new List<int>() {7, 3, 6, 6, 3}, 1),
                new Student("Dim", "Dimov", 19, 1, "+35926123456", "dim.dimov@abv.bg", new List<int>() {7, 3, 6, 6, 3}, 1),
                new Student("Dim", "Dimov", 19, 1, "+35926123456", "dim.dimov@abv.bg", new List<int>() {7, 3, 6, 6, 3}, 1),
                new Student("Dim", "Dimov", 19, 1, "+35926123456", "dim.dimov@abv.bg", new List<int>() {7, 3, 6, 6, 3}, 1),
                new Student("Dim", "Dimov", 19, 1, "+35926123456", "dim.dimov@abv.bg", new List<int>() {7, 3, 6, 6, 3}, 1),
            };
            return null;
        }
    }
}
