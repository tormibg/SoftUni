USE Geography;
GO

SELECT TOP 5 c.CountryName,
             r.RiverName
FROM Countries AS c
     LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
     LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode IN
(
    SELECT cn.ContinentCode
    FROM Continents cn
    WHERE cn.ContinentName = 'Africa'
)
ORDER BY CountryName;