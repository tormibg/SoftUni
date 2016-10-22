USE SoftUni;
GO

UPDATE Employees
SET
    Salary*=1.12
WHERE DepartmentID IN
(
  SELECT d.DepartmentID
  FROM dbo.Departments d
  WHERE d.Name IN
  ('Engineering',
   'Tool Design',
   'Marketing',
   'Information Services')
);

SELECT e.Salary
FROM Employees e;