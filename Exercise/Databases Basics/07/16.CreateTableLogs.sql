USE Bank;
GO

CREATE TRIGGER dbo.tr_logsAccAfterUpdate ON dbo.Accounts
INSTEAD OF UPDATE
AS
BEGIN
	IF OBJECT_ID('dbo.Logs') IS NULL
	BEGIN
		CREATE TABLE Logs
		( 
					 LogId int PRIMARY KEY IDENTITY(1, 1), AccountId int, OldSum money, NewSum money
		);
	END;
	DECLARE @id int=
	(
		SELECT i.id
		FROM inserted AS i
	);
	DECLARE @NewSum money=
	(
		SELECT i.Balance
		FROM inserted AS i
	);
	DECLARE @OldSum money=
	(
		SELECT a.Balance
		FROM Accounts AS a
		WHERE a.Id = @id
	);
	INSERT INTO Logs( AccountId, OldSum, NewSum )
	VALUES( @id, @oldSum, @newSum );
	UPDATE Accounts
	  SET Balance = @NewSum
	WHERE Id = @id;
END;
GO