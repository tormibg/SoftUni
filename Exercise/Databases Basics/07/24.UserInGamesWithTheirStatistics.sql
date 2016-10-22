WITH help AS (SELECT ug.UserId,
                     ug.GameId,
                     SUM(s.Strength) AS Strength,
                     SUM(s.Defence) AS Defence,
                     SUM(s.Speed) AS Speed,
                     SUM(s.Mind) AS Mind,
                     SUM(s.Luck) AS Luck
                FROM UsersGames AS ug
               INNER JOIN UserGameItems AS ugi
                  ON ugi.UserGameId = ug.Id
               INNER JOIN Items AS i
                  ON ugi.ItemId = i.Id
               INNER JOIN [Statistics] AS s
                  ON s.Id = i.StatisticId
               GROUP BY ug.UserId, ug.GameId)
SELECT DISTINCT u.Username,
       g.[Name] AS 'Game',
       MAX(c.[Name]) AS 'Character',
       MAX(s1.Strength) + MAX(s2.Strength) + MAX(h.Strength) AS 'Strength',
       MAX(s1.Defence) + MAX(s2.Defence) + MAX(h.Defence) AS 'Defence',
       MAX(s1.Speed) + MAX(s2.Speed) + MAX(h.Speed) AS 'Speed',
       MAX(s1.Mind) + MAX(s2.Mind) + MAX(h.Mind) AS 'Mind',
       MAX(s1.Luck) + MAX(s2.Luck) + MAX(h.Luck) AS 'Luck'
  FROM UsersGames AS ug
 INNER JOIN Users AS u
    ON u.Id = ug.UserId
 INNER JOIN Games AS g
    ON g.Id = ug.GameId
 INNER JOIN UserGameItems AS ugi
    ON ugi.UserGameId = ug.Id
 INNER JOIN Items AS i
    ON ugi.ItemId = i.Id
 INNER JOIN Characters AS c
    ON c.Id = ug.CharacterId
 INNER JOIN GameTypes AS gt
    ON gt.Id = g.GameTypeId
 INNER JOIN [Statistics] AS s1
    ON s1.Id = c.StatisticId
 INNER JOIN [Statistics] AS s2
    ON s2.Id = gt.BonusStatsId
 INNER JOIN help AS h
    ON h.UserId = u.Id
   AND h.GameId = g.Id
 GROUP BY u.Username, g.[Name]
 ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC