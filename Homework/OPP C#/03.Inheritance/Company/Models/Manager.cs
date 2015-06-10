using System;
using System.Collections.Generic;
using Company.Interface;

namespace Company.Models
{
    class Manager : Employee, IManager
    {
        // private IList<Employee> emplList = new List<Employee>();

        public Manager(string id, string firsName, string lastName, decimal salary, Department department) : base(id, firsName, lastName, salary, department)
        {
            this.EmplList = new List<RegularEmployee>();
        }

        public IList<RegularEmployee> EmplList { get; set; }

        public void AddEmployees(List<RegularEmployee> empl)
        {
            foreach (var employee in empl)
            {
                this.EmplList.Add(employee);
            }
        }
        public override string ToString()
        {
            string retStr = String.Format("ID - {0}, Name - {1} {2}, Salary - {3}, Department - {4}"
                                        , this.Id, this.FirstName, this.LastName, this.Salary, this.Depart);
            return retStr;
        }
    }
}
