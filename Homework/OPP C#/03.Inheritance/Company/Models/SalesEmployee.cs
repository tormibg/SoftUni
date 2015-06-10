using System;
using System.Collections.Generic;

namespace Company.Models
{
    class SalesEmployee : RegularEmployee
    {

        public SalesEmployee(string id, string firsName, string lastName, decimal salary, Department department) : base(id, firsName, lastName, salary, department)
        {
            this.Sales = new List<Sale>();
        }

        public IList<Sale> Sales { get; set; }

        public void AddSales(IList<Sale> sales)
        {
            foreach (Sale sale in sales)
            {
                this.Sales.Add(sale);
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
