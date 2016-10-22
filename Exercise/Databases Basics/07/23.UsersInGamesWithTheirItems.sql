USE Diablo;
GO

SELECT u.Username AS 'Username',
       g.Name AS 'Game',
       COUNT(1) AS 'Items Count',
       SUM(i.Price) AS 'Items Price'
FROM Users AS u
     JOIN UsersGames AS ug ON u.Id = ug.UserId
     JOIN Games AS g ON ug.GameId = g.Id
     JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
     JOIN Items AS i ON i.Id = ugi.ItemId
GROUP BY u.Username,
         g.Name
HAVING COUNT(1) >= 10
ORDER BY [Items Count] DESC,
         [Items Price] DESC,
         [Username] ASC;