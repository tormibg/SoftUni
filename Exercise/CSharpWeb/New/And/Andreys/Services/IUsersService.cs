using Andreys.App.ViewModels.Products;

namespace Andreys.App.Services
{
    public interface IUsersService
    {
        string GetUserNameById(string userId);
        string GetUserIdByNameAndPassword(string inputUsername, string inputPassword);
        bool IsUserExists(string inputUsername);
        bool IsEmailExist(string inputEmail);
        void Register(string inputUsername, string inputPassword, string inputEmail);
    }
}