namespace OneToMany.Models
{
    public class StudentAddress
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public virtual Student Student { get; set; }
    }
}