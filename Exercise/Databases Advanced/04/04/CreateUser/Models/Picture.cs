namespace CreateUser.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }

        public string Path { get; set; }

        public virtual Album Album { get; set; }
    }
}