USE SoftUni;
GO

SELECT TOP 5 e.FirstName,
             e.LastName
FROM dbo.Employees e
ORDER BY e.Salary DESC;