USE SoftUni;
GO

CREATE VIEW V_EmployeesHiredAfter2000
AS SELECT e.FirstName,
          e.LastName
   FROM dbo.Employees
   AS e
   WHERE YEAR( e.HireDate )>2000;
