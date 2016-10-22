USE Bank;
GO

--- DML


DELETE FROM [dbo].[EmployeesDeposits]
WHERE EmployeeID = 3 OR 
	  DepositID = 9;