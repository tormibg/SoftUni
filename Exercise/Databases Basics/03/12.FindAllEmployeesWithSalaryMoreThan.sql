USE SoftUni;
GO

SELECT e.FirstName,
       e.LastName,
       e.Salary
FROM dbo.Employees e
WHERE e.Salary>50000
ORDER BY e.Salary DESC;