using System.Security.Cryptography;

namespace SuperRpgGame.Interfaces
{
    public interface IRenderer
    {
        void WriteLine(string message, params object[] parameters);

        void Clear();
    }
}