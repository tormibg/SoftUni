USE Geography;
GO

SELECT TOP 5 c.CountryName,
             ccp.HighestPeakElevation,
             cm.LongestRiverLength
FROM Countries AS c
     LEFT JOIN
(
    SELECT cr.CountryCode,
           MAX(r.Length) AS 'LongestRiverLength'
    FROM CountriesRivers AS cr
         LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
    GROUP BY cr.CountryCode
) AS cm ON c.CountryCode = cm.CountryCode
     LEFT JOIN
(
    SELECT mc.CountryCode,
           MAX(p.Elevation) AS 'HighestPeakElevation'
    FROM MountainsCountries AS mc
         LEFT JOIN Peaks AS p ON mc.MountainId = p.MountainId
    GROUP BY mc.CountryCode
) AS ccp ON c.CountryCode = ccp.CountryCode
ORDER BY ccp.HighestPeakElevation DESC,
         cm.LongestRiverLength DESC,
         c.CountryName ASC;