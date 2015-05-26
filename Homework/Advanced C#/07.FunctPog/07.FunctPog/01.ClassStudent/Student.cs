using System.Collections.Generic;
using Microsoft.SqlServer.Server;

namespace ClassStudentCS
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
        public static List<Student> AddStudent()
        {
            var student = new List<Student>()
            {
                new Student("Dim", "Aimov", 19, 1234143, "+35926123456", "dim.dimov@abv.bg", new List<int>() {3,3,6,6,3}, 1),
                new Student("Tod", "Fodov", 20, 12322, "+25928738524", "tod.todov@fghj.bg", new List<int>() {5,6,4,5,6}, 1),
                new Student("Nik", "Bikov", 21, 5435432, "02 9747965", "jgddf@afgfhg.bg", new List<int>() {5,3,3,4,4}, 2),
                new Student("Kat", "Tatev", 26, 4543543, "+359 25555555", "lmghnjfdv@hg.bg", new List<int>() {3,2,5,4,5}, 2),
                new Student("Vak", "Pakev", 19, 5545144, "+25926666666", "hgfdf@hgrf.bg", new List<int>() {3,4,2,2,3}, 2),
                new Student("Dim", "Nikov", 32, 4324, "+33427777777", "bdf65@fdsfs.com", new List<int>() {6,6,6,6,6}, 4),
                new Student("Pet", "Dimov", 22, 432004, "+359 2 8975653", "nfhd@nenen.bg", new List<int>() {6,3,6,5,4}, 5),
                new Student("Abv", "Seven", 18, 5432143, "+35999087548", "hue@fgkfds.bg", new List<int>() {4,4,4,5,4}, 5),
                new Student("Dira", "Tirova", 11, 432432, "02 28426789", "gfds@gfs.bg", new List<int>() {4,5,6,6,5}, 7),
                new Student("Asen", "Agov", 112, 4331423, "2 5924554763", "hgdf89787v@gmail.com", new List<int>() {6,2,3,4,5}, 1),
            };
            return student;
        }

        public override string ToString()
        {
            return string.Format(
                "{0} {1}",
                this.FirstName,
                this.LastName);
        }
    }
}
