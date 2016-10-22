USE SoftUni;
GO

SELECT e.FirstName+' '+e.MiddleName+' '+e.LastName
AS 'Full Name'
FROM dbo.Employees e
WHERE e.Salary=25000
      OR e.Salary=14000
      OR e.Salary=12500
      OR e.Salary=23600;