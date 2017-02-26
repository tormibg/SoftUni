using System.Data.SqlTypes;

namespace SharpStoreDB.Models
{
    public class Knive
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SqlMoney Price { get; set; }
        public string ImageUrl { get; set; }
    }
} 