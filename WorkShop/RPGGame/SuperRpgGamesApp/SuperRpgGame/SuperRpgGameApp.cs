using SuperRpgGame.Engine;
using SuperRpgGame.Interfaces;
using SuperRpgGame.UI;

namespace SuperRpgGame
{
    class SuperRpgGameApp
    {
        static void Main()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputReader reader = new ConsoleInputReader();

            SuperEngine engine = new SuperEngine(reader, renderer);
            engine.Run();
        }
    }
}
