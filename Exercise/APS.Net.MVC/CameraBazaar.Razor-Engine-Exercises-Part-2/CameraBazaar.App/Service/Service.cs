using CameraBazzar.Data;

namespace CameraBazaar.App.Service
{
    public class Service
    {
        protected CameraBazaarContext Context { get; }

        protected Service()
        {
            this.Context = new CameraBazaarContext();    
        }
    }
}