CREATE PROCEDURE usp_CalculateFutureValueForAccount(@AccountId INT,
                                                    @interest  DECIMAL(20, 8))
AS
     BEGIN
         SELECT a.Id AS [Account Id],
                ah.FirstName AS [First Name],
                ah.LastName AS [Last Name],
                a.Balance AS [Current Balance],
                dbo.ufn_CalculateFutureValue(a.Balance, @interest, 5) AS [Balance in 5 years]
         FROM dbo.Accounts AS a
              INNER JOIN dbo.AccountHolders AS ah ON a.AccountHolderId = ah.Id
         WHERE a.Id = @AccountId;
     END;
GO

EXEC usp_CalculateFutureValueForAccount
     1,
     0.1;