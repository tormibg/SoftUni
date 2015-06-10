using BookStore.UI;

namespace BookStore
{
    using Engine;

    public class BookStoreMain
    {
        public static void Main()
        {
            BookStoreEngine engine = new BookStoreEngine(new ConsoleRenderer(), new ConsoleUserInterface());

            engine.Run();
        }
    }
}
