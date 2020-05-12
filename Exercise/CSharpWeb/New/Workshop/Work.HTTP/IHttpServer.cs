using System.Threading.Tasks;

namespace Work.HTTP
{
    public interface IHttpServer
    {
        Task StartAsync();
        Task ResetAsync();
        void Stop();
    }
}
