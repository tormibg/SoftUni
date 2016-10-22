USE Geography;
GO

SELECT c.ContinentName,
       GroupedCountries.CountriesArea,
       GroupedCountries.CountriesPopulation
FROM
(
    SELECT co.ContinentCode,
           SUM(CAST(AreaInSqKm AS BIGINT)) AS CountriesArea,
           SUM(CAST(Population AS BIGINT)) AS CountriesPopulation
    FROM Continents co
         JOIN Countries c ON c.ContinentCode = co.ContinentCode
    GROUP BY co.ContinentCode
) AS GroupedCountries
JOIN Continents c ON c.ContinentCode = GroupedCountries.ContinentCode
ORDER BY [CountriesPopulation] DESC;