BEGIN TRANSACTION;

USE Diablo;
GO

DECLARE @userId INT=
(
    SELECT u.Id
    FROM Users AS u
    WHERE u.Username = 'Alex'
);

DECLARE @gameId INT=
(
    SELECT g.Id
    FROM Games AS g
    WHERE g.Name = 'Edinburgh'
);

DECLARE @itemSUM MONEY=
(
    SELECT SUM(p.Price)
    FROM
    (
        SELECT i.Id,
               i.Price,
               ug.GameId
        FROM Items AS i
             CROSS JOIN UsersGames AS ug
        WHERE ug.UserId = @userId
              AND ug.GameId = @gameId
              AND i.Name IN('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet')
    ) AS p
);

UPDATE UsersGames
  SET
      Cash-=@itemSUM
WHERE GameId = @gameId
      AND UserId = @userId;

INSERT INTO UserGameItems
(UserGameId,
 ItemId
)
       SELECT @gameId,
              sel.Id
       FROM
       (
           SELECT Items.Id
           FROM Items
           WHERE Name IN('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet')
       ) AS sel;

SELECT Users.Username,
       Games.Name,
       UsersGames.Cash,
       Items.Name AS [Item Name]
FROM UsersGames
     JOIN Games ON UsersGames.GameId = Games.Id
     JOIN Users ON UsersGames.UserId = Users.Id
     JOIN UserGameItems ON UserGameItems.UserGameId = UsersGames.Id
     JOIN Items ON Items.Id = UserGameItems.ItemId
WHERE Games.Id = @gameId
ORDER BY Items.Name;

ROLLBACK TRANSACTION;