CREATE PROCEDURE usp_MoneyTransfer(
	   @Account1Id int, @Account2Id int, @moneyAmount money)
AS
BEGIN
	BEGIN TRANSACTION;
	BEGIN
		UPDATE Accounts
		  SET Balance-=@moneyAmount
		WHERE Accounts.Id = @Account1Id;
		UPDATE Accounts
		  SET Balance+=@moneyAmount
		WHERE Accounts.Id = @Account2Id;
		DECLARE @IfAcc1Id int=
		(
			SELECT ISNULL(
						 (
							 SELECT a.AccountHolderId
							 FROM dbo.Accounts AS a
							 WHERE a.AccountHolderId = @Account1Id
						 ), 0)
		);
		DECLARE @IfAcc2Id int=
		(
			SELECT ISNULL(
						 (
							 SELECT a.AccountHolderId
							 FROM dbo.Accounts AS a
							 WHERE a.AccountHolderId = @Account2Id
						 ), 0)
		);
		DECLARE @Acc1Sum money=
		(
			SELECT a.Balance
			FROM dbo.Accounts AS a
			WHERE a.AccountHolderId = @Account1Id
		);
		IF( @Acc1Sum - @moneyAmount < 0 OR 
			@IfAcc1Id = 0 OR 
			@IfAcc2Id = 0 OR 
			@moneyAmount <= 0
		  )
		BEGIN
			RAISERROR('Error ...', 16, 1);
			ROLLBACK;
		END;
		ELSE
		BEGIN
			COMMIT;
		END;
	END;
END;
GO

EXEC dbo.usp_MoneyTransfer @Account1Id = 1, @Account2Id = 2, @moneyAmount = 1000;