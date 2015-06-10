using System;
using System.Collections.Generic;
using Company.Interfaces;

namespace Company.Models
{
    class Developer : RegularEmployee, IDeveloper
    {
        public Developer(string id, string firsName, string lastName, decimal salary, Department department) : base(id, firsName, lastName, salary, department)
        {
            this.Projects = new List<Project>();
        }

        public IList<Project> Projects { get; set; }

        public void AddProjects(IList<Project> projects)
        {
            foreach (Project project in projects)
            {
                this.Projects.Add(project);
            }
        }

        public override string ToString()
        {
            string retStr = String.Format("ID - {0}, Name - {1} {2}, Salary - {3}, Department - {4}"
                                        ,this.Id, this.FirstName, this.LastName, this.Salary, this.Depart);
            return retStr;
        }
    }
}
