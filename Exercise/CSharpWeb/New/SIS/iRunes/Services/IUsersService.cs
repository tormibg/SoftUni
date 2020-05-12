namespace iRunes.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);
        void Register(string username, string password, string email);
        bool UserNameExists(string username);
        bool EmailExists(string email);
        object GetUserNameById(string user);
    }
}