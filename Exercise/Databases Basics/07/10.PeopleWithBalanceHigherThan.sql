USE bank;
GO

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@num money)
AS
     BEGIN
         SELECT ah.FirstName,
                ah.LastName
         FROM AccountHolders AS ah
              left JOIN dbo.Accounts AS a ON ah.Id = a.AccountHolderId
		    GROUP BY ah.FirstName,ah.LastName
		    HAVING Sum(isnull(a.Balance,0)) > @num
     END;
GO

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 