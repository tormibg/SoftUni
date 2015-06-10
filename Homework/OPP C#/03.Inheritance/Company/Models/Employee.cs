using Company.Interface;

namespace Company.Models
{
    class Employee : Person, IEmployee
    {
        //private decimal salary;

        public Employee(string id, string firsName, string lastName, decimal salary, Department department) : base(id, firsName, lastName)
        {
            this.Salary = salary;
            this.Depart = department;
        }

        public decimal Salary { get; set; }
        public Department Depart { get; set; }
    }
}
