USE SoftUni;
GO

SELECT top 7 e.FirstName,
       e.LastName,
       e.HireDate
FROM dbo.Employees e
ORDER BY e.HireDate DESC

--SELECT e.FirstName,
--       e.LastName,
--       e.HireDate
--FROM dbo.Employees e
--WHERE e.EmployeeID NOT IN
--(
--  SELECT TOP (
--             (
--               SELECT COUNT( * )
--               FROM dbo.Employees e2
--             )-7 ) EmployeeID
--  FROM dbo.Employees e2
--);