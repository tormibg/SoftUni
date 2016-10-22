USE Bank;
GO

--SELECT *
--INTO AccountLogs
--FROM Accounts
--WHERE NULL = NULL;


CREATE TRIGGER tr_LogDeletedAccounts ON [dbo].[Accounts]
INSTEAD OF DELETE
AS
BEGIN
	DELETE FROM EmployeesAccounts
	WHERE AccountID IN
	(
		SELECT d.AccountID
		FROM deleted AS d
	);
	INSERT INTO AccountLogs( AccountID, AccountNumber, StartDate, CustomerID )
		   SELECT *
		   FROM deleted;
	DELETE FROM Accounts
	WHERE AccountID IN
	(
		SELECT d.AccountIDs
		FROM deleted AS d
	);
END;

	DELETE FROM [dbo].[Accounts]
	WHERE CustomerID = 4;

	SELECT *
	FROM [dbo].[AccountLogs];