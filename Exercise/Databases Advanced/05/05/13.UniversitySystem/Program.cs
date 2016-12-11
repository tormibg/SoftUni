namespace _13.UniversitySystem
{
    class Program
    {
        static void Main()
        {
            //var tphContex = new TphContext();
            //tphContex.Database.Initialize(true);

            //var tptContex = new TptContext();
            //tptContex.Database.Initialize(true);

            var tpcContex = new TpcContext();
            tpcContex.Database.Initialize(true);
        }
    }
}
