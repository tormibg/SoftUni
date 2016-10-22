BEGIN TRAN
DECLARE @totalItemSum MONEY = (SELECT SUM(Price) AS TotalPrice FROM Items AS i 
		WHERE i.MinLevel BETWEEN 11 AND 12)

DECLARE @currentBalance MONEY = (SELECT ug.Cash FROM Users AS u 
		LEFT JOIN UsersGames AS ug ON ug.UserId = u.Id
		LEFT JOIN Games AS g ON g.Id = ug.GameId
		WHERE u.FirstName = 'Stamat' AND g.Name = 'Safflower')

BEGIN TRY 
	UPDATE UsersGames SET
	Cash -= @totalItemSum
	WHERE UserId = (SELECT Id FROM Users WHERE FirstName = 'Stamat') AND
	 GameId = (SELECT Id FROM Games WHERE Name = 'Safflower')

	INSERT INTO UserGameItems SELECT i.Id, ug.Id FROM UsersGames AS ug CROSS JOIN Items AS i 
		LEFT JOIN Games AS g ON g.Id = ug.GameId
		LEFT JOIN Users AS u ON u.Id = ug.UserId
		WHERE i.MinLevel BETWEEN 11 AND 12 AND u.FirstName = 'Stamat' AND g.Name = 'Safflower'

	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
END CATCH

BEGIN TRAN
SET @totalItemSum = (SELECT SUM(Price) AS TotalPrice FROM Items AS i 
		WHERE i.MinLevel BETWEEN 19 AND 21)

SET @currentBalance = (SELECT ug.Cash FROM Users AS u 
		LEFT JOIN UsersGames AS ug ON ug.UserId = u.Id
		LEFT JOIN Games AS g ON g.Id = ug.GameId
		WHERE u.FirstName = 'Stamat' AND g.Name = 'Safflower')

BEGIN TRY 
	UPDATE UsersGames SET
	Cash -= @totalItemSum
	WHERE UserId = (SELECT Id FROM Users WHERE FirstName = 'Stamat') AND
	 GameId = (SELECT Id FROM Games WHERE Name = 'Safflower')

	INSERT INTO UserGameItems SELECT i.Id, ug.Id FROM UsersGames AS ug CROSS JOIN Items AS i 
		LEFT JOIN Games AS g ON g.Id = ug.GameId
		LEFT JOIN Users AS u ON u.Id = ug.UserId
		WHERE i.MinLevel BETWEEN 19 AND 21 AND u.FirstName = 'Stamat' AND g.Name = 'Safflower'
	
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
END CATCH

SELECT Name AS 'Item Name' FROM Items 
	WHERE Id IN (
		SELECT ugi.ItemId FROM UserGameItems AS ugi 
			WHERE ugi.UserGameId = (
				SELECT ug.Id FROM UsersGames AS ug 
					LEFT JOIN Games AS g ON g.Id = ug.GameId
					LEFT JOIN Users AS u ON u.Id = ug.UserId
					WHERE u.FirstName = 'Stamat' AND g.Name = 'Safflower'))
	ORDER BY Name ASC

--SELECT * FROM UserGameItems AS ugi
--	LEFT JOIN Items AS i ON i.Id = ugi.ItemId
--	WHERE ugi.UserGameId = (SELECT ug.Id FROM UsersGames AS ug
--								LEFT JOIN Games AS g ON g.Id = ug.GameId
--								LEFT JOIN Users AS u ON u.Id = ug.UserId
--									WHERE u.FirstName = 'Stamat' AND g.Name = 'Safflower')
