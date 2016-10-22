CREATE PROCEDURE usp_DepositMoney(@AccountId   INT,
                                  @moneyAmount MONEY)
AS
     BEGIN
         UPDATE Accounts
           SET
               Balance+=@moneyAmount
         WHERE Accounts.Id = @AccountId;
     END;
GO

BEGIN TRANSACTION;

EXEC dbo.usp_DepositMoney
     @AccountId = 1,
     @moneyAmount = 1000;

COMMIT;