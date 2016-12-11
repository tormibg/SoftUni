namespace OneToMany.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual StudentAddress StudentAddress { get; set; }

        public virtual School School { get; set; }
    }
}