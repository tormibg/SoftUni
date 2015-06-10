using Company.Interface;

namespace Company.Models
{
    abstract class RegularEmployee : Employee, IRegularEmployee
    {
        protected RegularEmployee(string id, string firsName, string lastName, decimal salary, Department department) : base(id, firsName, lastName, salary, department)
        {
        }
    }
}
