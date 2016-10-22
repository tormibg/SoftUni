USE SoftUni;
GO

UPDATE dbo.Employees
SET
    Employees.Salary=Employees.Salary*1.10;

SELECT e.Salary
FROM dbo.Employees e;