using System;
using System.Linq;

namespace EntityFM
{
    class Program
    {
        static void Main()
        {
            //var context = new SoftuniContext();

            //GetEmployeesMaximumSalaries(context);

            var context = new Gringotts();

            //DepositsSumForOllivanderFamily(context);

            DepositsFilter(context);

            //// 3.	Employees full information
            //var employees = context.Employees.ToList();

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine($@"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary}");
            //}
            //-----------------------------------------------------------------------------
            //// 4.	Employees with Salary Over 50 000
            //var employees = context.Employees.Where(s => s.Salary > 50000).Select(s => s.FirstName).ToList();

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}
            //--------------------------------------------------------------------------------
            ////5.	Employees from Seattle
            //var emploees =
            //    context.Employees.Where(e => e.Department.Name == "Research and Development")
            //        .OrderBy(e => e.Salary)
            //        .ThenByDescending(e => e.FirstName)
            //        .ToList();

            //foreach (var employee in emploees)
            //{
            //    Console.WriteLine($@"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:F2}");
            //}
            //---------------------------------------------------------------------------------
            ////6.	Adding a New Address and Updating Employee
            //var adress = new Address
            //{
            //    AddressText = "Vitoshka 15",
            //    TownID = 4
            //};

            //Employee employee = null;
            //employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            //employee.Address = adress;

            //context.SaveChanges();

            //var employees = context.Employees.OrderByDescending(e => e.AddressID).Take(10).Select(e => e.Address.AddressText);

            //foreach (var employee1 in employees)
            //{
            //    Console.WriteLine(employee1);
            //}
            //------------------------------------------------------------------------------------------
            ////7.	Delete Project by Id
            //var project = context.Projects.Find(2);

            //var employees = project.Employees;

            //foreach (var employee in employees)
            //{
            //    employee.Projects.Remove(project);
            //}

            //context.SaveChanges();
            //context.Projects.Remove(project);
            //context.SaveChanges();

            //var projects = context.Projects.Select(p => p.Name).Take(10);
            //foreach (var project1 in projects)
            //{
            //    Console.WriteLine(project1);
            //}
            //--------------------------------------------------------------------------------------
            ////8.	Find employees in period
            //var employees =
            //    context.Employees.Where(e => e.Projects.Count(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003) > 0)
            //        .Take(30);

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine($@"{employee.FirstName} {employee.LastName} {employee.Manager.FirstName}");

            //    foreach (var employeeProject in employee.Projects)
            //    {
            //        object test1 = null;
            //        if (employeeProject.EndDate != null)
            //        {
            //            var test = (DateTime) employeeProject.EndDate;
            //            test1 = test.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            //        }
            //        else
            //        {
            //            test1 = "";
            //        }
            //        Console.WriteLine($@"--{employeeProject.Name} {employeeProject.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} {test1}");
            //    }
            //}
            //------------------------------------------------------------------------------------------
            ////8.	Addresses by town name 
            //var addresses =
            //    context.Addresses.OrderByDescending(x => x.Employees.Count()).ThenBy(a => a.Town.Name).Take(10);
            //foreach (var address in addresses)
            //{
            //    Console.WriteLine($@"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
            //}
            //-------------------------------------------------------------------------------------
            ////9.	Employee with id 147 sorted by project names 
            //var employees = context.Employees.Where(e => e.EmployeeID == 147);

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine($@"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            //    var projects = employee.Projects.OrderBy(p => p.Name).Select(p => p.Name);
            //    foreach (var project in projects)
            //    {
            //        Console.WriteLine($@"{project}");
            //    }
            //}
            //-------------------------------------------------------------------------------------------
            ////10.	Departments with more than 5 employees
            //var departments = context.Departments.Where(d => d.Employees.Count > 5).OrderBy(d => d.Employees.Count);

            //foreach (var department in departments)
            //{
            //    var manId = department.ManagerID;
            //    var manager = context.Employees.FirstOrDefault(e => e.EmployeeID == manId);
            //    Console.WriteLine($@"{department.Name} {manager.FirstName}");
            //    foreach (var departmentEmployee in department.Employees)
            //    {
            //        Console.WriteLine($@"{departmentEmployee.FirstName} {departmentEmployee.LastName} {departmentEmployee.JobTitle}");
            //    }
            //}
            //---------------------------------------------------------------------------------------------
            ////11.	*Native SQL Query
            //context.Employees.Count();
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //var employee =
            //    context.Employees.Where(e => e.Projects.Count(p => p.StartDate.Year == 2002) > 0)
            //        .Select(e => e.FirstName).GroupBy(s => s);
            //sw.Stop();
            //Console.WriteLine($@"Linq - {sw.Elapsed}");

            //sw.Restart();
            //sw.Start();
            //var employee1 =
            //    context.Employees.SqlQuery(
            //        @"select e.FirstName, count(1) from Employees as e join EmployeesProjects as ep on ep.EmployeeID = e.EmployeeID join Projects as p on p.ProjectID = ep.ProjectID and year(p.StartDate) = '2002' group by e.FirstName");
            //sw.Stop();
            //Console.WriteLine($@"Native - {sw.Elapsed}");
            //----------------------------------------------------------------------------------
            ////14.	Find Latest 10 Projects
            //var projects = context.Projects.OrderByDescending(x => x.StartDate).Take(10).OrderBy(x => x.Name);
            //foreach (var project in projects)
            //{
            //    object test1 = null;
            //    if (project.EndDate != null)
            //    {
            //        var test = (DateTime)project.EndDate;
            //        test1 = test.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            //    }
            //    else
            //    {
            //        test1 = "";
            //    }
            //    Console.WriteLine($@"{project.Name} {project.Description} {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} {test1}");
            //--------------------------------------------------------------------------------
            //15.	Increase Salaries
            //var employees =
            //    context.Employees.Where(
            //        e =>
            //            e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" ||
            //            e.Department.Name == "Marketing" || e.Department.Name == "Information Services");

            //foreach (var employee in employees)
            //{
            //    employee.Salary *= (decimal) 1.12;
            //    Console.WriteLine($@"{employee.FirstName} {employee.LastName} (${employee.Salary})");
            //}
            //context.SaveChanges();
            //----------------------------------------------------------------------------------------
            ////17.	Remove Towns
            //var town = Console.ReadLine();

            //var townForDeleted = context.Towns.FirstOrDefault(t => t.Name == town);

            //var adresses = townForDeleted.Addresses.ToArray();

            //foreach (var address in adresses)
            //{
            //    foreach (var empl in address.Employees)
            //    {
            //        empl.AddressID = null;
            //    }
            //}

            //context.Addresses.RemoveRange(adresses);
            //context.Towns.Remove(townForDeleted);
            ////context.SaveChanges();
            //Console.WriteLine($@"{adresses.Length} address in {town} was deleted");
            //------------------------------------------------------------------------------
            //18.	Find Employees by First Name starting with ‘SA’
            //var empl = context.Employees.Where(e => e.FirstName.ToUpper().StartsWith("SA"));
            //foreach (var employee in empl)
            //{
            //    Console.WriteLine($@"{employee.FirstName} {employee.LastName} – {employee.JobTitle} - (${employee.Salary:f4})");
            //}

            //var context = new Gringotts();
            //StringBuilder result = new StringBuilder();

            //var wizzards =
            //    context.WizzardDeposits.Where(wd => wd.DepositGroup == "Troll Chest")
            //        .Distinct()
            //        .Select(wfl => wfl.FirstName.Substring(0, 1))
            //        .Distinct()
            //        .OrderBy(x => x);

            //foreach (var wizzard in wizzards)
            //{
            //    result.AppendLine(wizzard);
            //}
            //Console.WriteLine(result.ToString());
        }

        private static void DepositsFilter(Gringotts context)
        {
            var deposits =
                context.WizzardDeposits.Where(wd => wd.MagicWandCreator == "Ollivander family")
                    .GroupBy(wd => wd.DepositGroup)
                    .Select(wd => new {DepositGroupName = wd.Key, Sum = wd.Sum(s => s.DepositAmount)})
                    .Where(s => s.Sum < 150000)
                    .OrderByDescending(o => o.Sum);

            foreach (var deposit in deposits)
            {
                Console.WriteLine($"{deposit.DepositGroupName} - {deposit.Sum}");
            }
        }

        private static void DepositsSumForOllivanderFamily(Gringotts context)
        {
            var deposits =
                context.WizzardDeposits.Where(wd => wd.MagicWandCreator == "Ollivander family")
                    .GroupBy(wd => wd.DepositGroup)
                    .Select(s => new {DepositGroupName = s.Key, Sum = s.Sum(wd => wd.DepositAmount)});
            foreach (var deposit in deposits)
            {
                Console.WriteLine($"{deposit.DepositGroupName} - {deposit.Sum}");
            }
        }

        private static void GetEmployeesMaximumSalaries(SoftuniContext context)
        {
            var departments =
                context.Departments.Select(d => new {DepName = d.Name, MaxSalary = d.Employees.Max(e => e.Salary)})
                    .Where(ds => ds.MaxSalary < 30000 && ds.MaxSalary > 70000);
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepName} - {department.MaxSalary}");
            }
        }
    }
}
