namespace SlusApp.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);
        void ChangePassword(string username, string newPassword);
        string GetUserId(string username, string password);
        int CountUsers();
    }
}