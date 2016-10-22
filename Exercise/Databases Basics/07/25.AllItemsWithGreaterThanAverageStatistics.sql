USE Diablo;
GO

DECLARE @avgStrength INT, @avgDefence INT, @avgMind INT, @avgSpeed INT, @avgLuck INT;

SELECT @avgStrength = Strength,
       @avgDefence = Defence,
       @avgMind = Mind,
       @avgSpeed = Speed,
       @avgLuck = Luck
FROM
(
    SELECT AVG(s.Strength) AS 'Strength',
           AVG(s.Defence) AS 'Defence',
           AVG(s.Mind) AS 'Mind',
           AVG(s.Speed) AS 'Speed',
           AVG(s.Luck) AS 'Luck'
    FROM dbo.[Statistics] AS s
) AS sel;

SELECT i.Name,
       i.Price,
       i.MinLevel,
       s.Strength,
       s.Defence,
       s.Speed,
       s.Luck,
       s.Mind
FROM Items AS i
     JOIN [dbo].[Statistics] AS s ON i.StatisticId = s.Id
WHERE s.Mind > @avgMind
      AND s.Speed > @avgSpeed
      AND s.Luck > @avgLuck
ORDER BY i.Name;