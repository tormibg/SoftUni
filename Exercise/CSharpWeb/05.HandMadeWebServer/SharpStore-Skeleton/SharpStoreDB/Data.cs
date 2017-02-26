namespace SharpStoreDB
{
    public class Data
    {
        private static SharpStoreContext _context;

        public static SharpStoreContext Context => _context ?? new SharpStoreContext();
    }
}