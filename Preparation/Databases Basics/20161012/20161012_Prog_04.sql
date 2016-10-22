USE Bank;
GO

CREATE TRIGGER tr_InsertNewEmployee ON [dbo].[Employees]
AFTER INSERT
AS
BEGIN
	UPDATE EmployeesLoans
	  SET EmployeeID = i.EmployeeID
	FROM EmployeesLoans AS ea
		 JOIN
		 inserted AS i
		 ON i.EmployeeID = ea.EmployeeID + 1;
END;