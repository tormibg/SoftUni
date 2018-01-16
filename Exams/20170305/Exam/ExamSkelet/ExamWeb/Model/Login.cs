namespace SoftUniStore.App.Model
{
    public class Login
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public string SessionId { get; set; }

        public bool IsActive { get; set; }
    }
}
