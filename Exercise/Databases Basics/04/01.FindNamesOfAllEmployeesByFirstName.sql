USE SoftUni;
GO

SELECT e.FirstName,
       e.LastName
FROM dbo.Employees
AS e
WHERE LEFT( e.FirstName, 2 )='sa';