using UniversitySystemData;

namespace UniversitySystemClient
{
    class Program
    {
        static void Main()
        {
            var context = new UniversitySystemContextTph();
            context.Database.Initialize(true);
        }
    }
}
