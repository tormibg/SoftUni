USE SoftUni;
GO

SELECT TOP 5 em.EmployeeID,
             em.FirstName,
             em.Salary,
             dep.Name
FROM Employees AS em
     LEFT JOIN Departments dep ON em.DepartmentID = dep.DepartmentID
WHERE em.Salary > 15000
ORDER BY em.DepartmentID ASC;