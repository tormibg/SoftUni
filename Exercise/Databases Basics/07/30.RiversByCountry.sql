USE Geography;
GO

SELECT c.CountryName,
       co.ContinentName,
       GroupedCountries.RiversCount,
       ISNULL(GroupedCountries.TotalLength, 0) AS TotalLength
FROM
(
    SELECT c.CountryCode,
           COUNT(r.Id) AS RiversCount,
           SUM(r.Length) AS TotalLength
    FROM Countries c
         LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
         LEFT JOIN Rivers r ON r.Id = cr.RiverId
    GROUP BY c.CountryCode
) AS GroupedCountries
JOIN Countries c ON c.CountryCode = GroupedCountries.CountryCode
JOIN Continents co ON co.ContinentCode = c.ContinentCode
ORDER BY RiversCount DESC,
         TotalLength DESC,
         CountryName;