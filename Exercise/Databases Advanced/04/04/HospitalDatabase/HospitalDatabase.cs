namespace HospitalDatabase
{
    class HospitalDatabase
    {
        static void Main()
        {
            var context = new HospitalContext();
            context.Database.Initialize(true);
        }
    }
}
