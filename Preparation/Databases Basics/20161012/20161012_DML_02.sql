USE Bank;
GO

--- DML


UPDATE dbo.Employees
  SET ManagerID = CASE
				   WHEN EmployeeID BETWEEN 2 AND 10 THEN 1
				   WHEN EmployeeID BETWEEN 12 AND 20 THEN 11
				   WHEN EmployeeID BETWEEN 22 AND 30 THEN 21
				   WHEN EmployeeID IN( 11, 21 ) THEN 1
				   END;