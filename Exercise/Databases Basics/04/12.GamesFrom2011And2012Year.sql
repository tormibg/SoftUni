USE Diablo;
GO

SELECT TOP 50 g.Name AS 'Game',
              CONVERT(varchar(10), g.Start, 120) AS 'Start'
FROM Games AS g
WHERE YEAR(Start) IN(2012, 2011)
ORDER BY g.Start, Game;