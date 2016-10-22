USE Geography;
GO

UPDATE Countries
  SET
      CountryName = 'Burma'
WHERE CountryName = 'Myanmar';

INSERT INTO Monasteries
(Name,
 CountryCode
)
VALUES
('Hanga Abbey',
(
    SELECT CountryCode
    FROM Countries
    WHERE CountryName = 'Tanzania'
)
),
('Myin-Tin-Daik',
(
    SELECT CountryCode
    FROM Countries
    WHERE CountryName = 'Myanmar'
)
);

SELECT co.ContinentName,
       c.CountryName,
       MonasteriesCount
FROM
(
    SELECT c.CountryCode,
           COUNT(m.Id) AS MonasteriesCount
    FROM Continents co
         JOIN Countries c ON c.ContinentCode = co.ContinentCode
         LEFT JOIN Monasteries m ON m.CountryCode = c.CountryCode
    WHERE c.IsDeleted = 0
    GROUP BY c.CountryCode
) AS MonasteriesByCountries
JOIN Countries c ON c.CountryCode = MonasteriesByCountries.CountryCode
JOIN Continents co ON co.ContinentCode = c.ContinentCode
ORDER BY MonasteriesCount DESC,
         c.CountryName;