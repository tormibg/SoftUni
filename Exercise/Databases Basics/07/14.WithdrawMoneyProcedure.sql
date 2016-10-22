CREATE PROCEDURE usp_WithdrawMoney(
	   @AccountId int, @moneyAmount money)
AS
BEGIN
	UPDATE Accounts
	  SET Balance-=@moneyAmount
	WHERE Accounts.Id = @AccountId;
END;
GO

EXEC dbo.usp_WithdrawMoney @AccountId = 1, @moneyAmount = 1000;
