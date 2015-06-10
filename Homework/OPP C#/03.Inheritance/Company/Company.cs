using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Company.Models;

namespace Company
{
    class Company
    {
        static void Main()
        {
            Manager manager1 = new Manager("00001","Ivan", "Ivanov",123m, Department.Sales);
            Manager manager2 = new Manager("00002", "Pesho", "Peshev", 150m, Department.Marketing);

            Developer dev1 = new Developer("00003", "Galia", "Galeva", 12m, Department.Sales);
            Developer dev2 = new Developer("00004", "Georg", "Ganev", 34m, Department.Sales);

            SalesEmployee sal1 = new SalesEmployee("00005", "Fet", "Fetev", 20m, Department.Sales);
            SalesEmployee sal2 = new SalesEmployee("00006", "Azi", "Azinov", 45m, Department.Marketing);

            Sale salH = new Sale("Computers",DateTime.Today, 230m);
            Sale salMac = new Sale("MacPro", DateTime.Now,400m );

            sal1.AddSales(new List<Sale>() { salH,salMac });
            sal2.AddSales(new List<Sale>() { salH, salMac });

            Project prjMan = new Project("Manhatan", DateTime.ParseExact("01-12-2015", "dd-MM-yyyy", CultureInfo.InvariantCulture), "Atom bonb", State.Open);
            Project prjApolo = new Project("Apolo", DateTime.ParseExact("01-12-1977","dd-MM-yyyy", CultureInfo.InvariantCulture), "Moon", State.Open);

            dev1.AddProjects(new List<Project>() { prjMan, prjApolo });
            dev2.AddProjects(new List<Project>() { prjMan, prjApolo });

            prjApolo.CloseProject();

            manager1.AddEmployees(new List<RegularEmployee>(){dev1,dev2});
            manager2.AddEmployees(new List<RegularEmployee>() {dev2, sal2});

            Customer cust1 = new Customer("00007", "Hiro", "Nakamura", 200m);
            Customer cust2 = new Customer("00008", "Seven", "Senov", 240m);
            
            IList<Person> perList = new List<Person>()
            {
                manager1, manager2, dev1, dev2, sal1, sal2, cust1, cust2
            };
            foreach (Person person in perList)
            {
                Console.WriteLine(person);
            }
        }
    }
}
