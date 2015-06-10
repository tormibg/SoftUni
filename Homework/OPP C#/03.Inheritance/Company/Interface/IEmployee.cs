using Company.Models;

namespace Company.Interface
{
    interface IEmployee
    {
        decimal Salary { get; set; }

        Department Depart { get; set; }

    }
}
