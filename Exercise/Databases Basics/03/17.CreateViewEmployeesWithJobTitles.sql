USE SoftUni;
GO

CREATE VIEW V_EmployeeNameJobTitle
AS SELECT isnull( e.FirstName, '' )+' '+isnull( e.MiddleName, '' )+' '+isnull( e.LastName, '' )
   AS 'Full Name',
          e.JobTitle
   FROM Employees e;