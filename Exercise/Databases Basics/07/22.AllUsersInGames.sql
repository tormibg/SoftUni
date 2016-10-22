USE Diablo;
GO

SELECT g.Name AS 'Game',
       gt.Name AS 'Game Type',
       u.Username AS 'Username',
       ug.Level AS 'Level',
       ug.Cash,
       ch.Name AS 'Character'
FROM Users AS u
     LEFT JOIN UsersGames AS ug ON u.Id = ug.UserId
     INNER JOIN Games AS g ON ug.GameId = g.Id
     LEFT JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
     LEFT JOIN Characters AS ch ON ch.id = ug.CharacterId
ORDER BY [Level] DESC,
         [Username] ASC,
         [Game] ASC;