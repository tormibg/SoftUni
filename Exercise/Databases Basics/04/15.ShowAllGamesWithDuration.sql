USE Diablo;
GO

SELECT g.Name
AS 'Game',
       'Part of the Day'=CASE
                           WHEN CONVERT( INT, DATENAME( HOUR, g.Start ) ) BETWEEN 0 AND 11
                           THEN 'Morning'
                           WHEN CONVERT( INT, DATENAME( HOUR, g.Start ) ) BETWEEN 12 AND 17
                           THEN 'Afternoon'
                           WHEN CONVERT( INT, DATENAME( HOUR, g.Start ) ) BETWEEN 18 AND 23
                           THEN 'Evening'
                         END,
       'Duration'=CASE
                     WHEN g.Duration<=3
                     THEN 'Extra Short'
                     WHEN g.Duration BETWEEN 4 AND 6
                     THEN 'Short'
                     WHEN g.Duration>6
                     THEN 'Long'
                     WHEN g.Duration IS NULL
                     THEN 'Extra Long'
                   END
FROM games
AS g
ORDER BY Game ASC,
         [Duration] ASC,
         [Part of the Day] ASC;