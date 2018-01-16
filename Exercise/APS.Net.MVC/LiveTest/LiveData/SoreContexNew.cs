using LiveModels;

namespace LiveData
{
    using System.Data.Entity;

    public class SoreContexNew : DbContext
    {
        
        public SoreContexNew()
            : base("SoreContexNew")
        {
        }

        public IDbSet<Mouse> Mice { get; set; }
    }

}