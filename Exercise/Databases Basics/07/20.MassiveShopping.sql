USE Diablo;
GO

SET XACT_ABORT ON;

DECLARE @user VARCHAR(MAX)= 'Stamat';

DECLARE @game VARCHAR(MAX)= 'Safflower';

DECLARE @gameId INT, @userId INT, @userGameId INT;

SELECT @userId = Users.Id,
       @gameId = Games.Id,
       @userGameId = UsersGames.Id
FROM Users
     JOIN UsersGames ON UsersGames.UserId = Users.Id
     JOIN Games ON Games.Id = UsersGames.GameId
WHERE Users.FirstName = @user
      AND Games.Name = @game;

BEGIN TRANSACTION [Item1];
BEGIN TRY
    DECLARE @SumItem1120 MONEY=
    (
        SELECT SUM(i.Price)
        FROM Items AS i
        WHERE i.MinLevel BETWEEN 11 AND 12
    );
    UPDATE UsersGames
      SET
          Cash-=@SumItem1120
    WHERE UserId = @userId
          AND GameId = @gameId;
    INSERT INTO UserGameItems
    (ItemId,
     UserGameId
    )
           SELECT i.id AS 'ItemId',
                  ug.id AS 'UserGameId'
           FROM UsersGames AS ug
                CROSS JOIN Items AS i
           WHERE i.MinLevel BETWEEN 11 AND 12
                 AND ug.GameId = @gameId
                 AND ug.UserId = @userId;
    COMMIT TRANSACTION [Item1];
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION [Item1];
END CATCH;


BEGIN TRANSACTION [123]
BEGIN TRY
    DECLARE @SumItem1921 MONEY=
    (
        SELECT SUM(i.Price)
        FROM Items AS i
        WHERE i.MinLevel BETWEEN 19 AND 21
    );
    UPDATE UsersGames
      SET
          Cash-=@SumItem1921
    WHERE UserId = @userId
          AND GameId = @gameId;

    INSERT INTO UserGameItems
    (ItemId,
     UserGameId
    )
           SELECT i.id AS 'ItemId',
                  ug.id AS 'UserGameId'
           FROM UsersGames AS ug
                CROSS JOIN Items AS i
           WHERE i.MinLevel BETWEEN 19 AND 21
                 AND ug.GameId = @gameId
                 AND ug.UserId = @userId;

    COMMIT TRANSACTION [123]
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION [123]
END CATCH;

SELECT i.Name
FROM UserGameItems AS ug
     JOIN Items AS i ON ug.ItemId = i.Id
WHERE ug.UserGameId IN
(
    SELECT ug.id
    FROM UsersGames AS ug
         JOIN Games AS g ON ug.GameId = g.Id
                            AND g.Name = @game
         JOIN Users AS u ON ug.UserId = u.Id
                            AND u.Username = @user
)
ORDER BY i.Name;