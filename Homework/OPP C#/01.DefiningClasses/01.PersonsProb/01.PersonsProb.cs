using System;

namespace PersonsProb
{
    class Program
    {
        static void Main()
        {
            try
            {
                Person newP = new Person("Ivan", 100, "afds@fds.bg");
               // newP.Email = "adsa@abv.bg";
                Console.WriteLine(newP);
           
                Person nnn = new Person("Pep", 1, "dir@bg");
                Console.WriteLine(nnn);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("{0}",ex);
            }
        }
    }
}
