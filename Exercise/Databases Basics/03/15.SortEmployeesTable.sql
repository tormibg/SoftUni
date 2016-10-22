USE SoftUni;
GO

SELECT *
FROM dbo.Employees e
ORDER BY e.Salary DESC,
         e.FirstName ASC,
         e.LastName DESC,
         e.MiddleName ASC;