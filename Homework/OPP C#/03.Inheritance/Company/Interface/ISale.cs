using System;

namespace Company.Interface
{
    interface ISale
    {
        string ProdName { get; set; }
        DateTime DateSale { get; set; }
        decimal Price { get; set; }
    }
}
