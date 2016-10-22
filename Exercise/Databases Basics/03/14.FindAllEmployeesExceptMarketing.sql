USE SoftUni;
GO

SELECT e.FirstName,
       e.LastName
FROM dbo.Employees e
WHERE e.DepartmentID!=4;