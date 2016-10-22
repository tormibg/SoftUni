USE Diablo;
GO

CREATE FUNCTION ufn_CashInUsersGames
(@gameName VARCHAR(MAX)
)
RETURNS TABLE
AS
     RETURN
     SELECT SUM(Cash) AS 'SumCash'
     FROM
     (
         SELECT ug.GameId,
                ug.Cash,
                ROW_NUMBER() OVER(ORDER BY cash DESC) AS 'Row'
         FROM UsersGames AS ug
              INNER JOIN Games AS g ON ug.GameId = g.Id
                                       AND g.Name = @gameName
     ) AS GameIdCashRow
     WHERE Row % 2 = 1
     GROUP BY GameId;
GO

SELECT *
FROM dbo.ufn_CashInUsersGames('Bali')
UNION
SELECT *
FROM dbo.ufn_CashInUsersGames('Lily Stargazer')
UNION
SELECT *
FROM dbo.ufn_CashInUsersGames('Love in a mist')
UNION
SELECT *
FROM dbo.ufn_CashInUsersGames('Mimosa')
UNION
SELECT *
FROM dbo.ufn_CashInUsersGames('Ming fern')
ORDER BY SumCash;