using System;

namespace BookShop
{
    class BookShop
    {
        static void Main()
        {
            //Book book = new Book("Pod Igoto", "Ivan Vazov", 15.90M);
            //Console.WriteLine(book);
            GoldenEditionBook gBook = new GoldenEditionBook("Tutun", "Dimitar Dimov", 22.90M);
            Console.WriteLine(gBook);
        }
    }
}
