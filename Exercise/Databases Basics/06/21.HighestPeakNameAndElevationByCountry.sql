USE Geography;
GO

SELECT TOP 5 c.CountryName,
             isnull(p.PeakName, '(no highest peak)') AS 'HighestPeakName',
             isnull(MaxP.HighestPeakElevation, 0) AS 'HighestPeakElevation',
             CASE
                 WHEN MaxP.HighestPeakElevation IS NULL
                 THEN '(no mountain)'
                 ELSE mn.MountainRange
             END AS 'Mountain'
FROM Countries AS c
     LEFT JOIN
(
    SELECT mc.CountryCode,
           MAX(p.Elevation) AS HighestPeakElevation
    FROM MountainsCountries AS mc
         INNER JOIN Peaks AS p ON mc.MountainId = p.MountainId
    GROUP BY mc.CountryCode
) AS MaxP ON c.CountryCode = MaxP.CountryCode
     LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
     LEFT JOIN Mountains AS mn ON mc.MountainId = mn.Id
     LEFT JOIN Peaks AS p ON p.MountainId = mn.Id
WHERE MaxP.HighestPeakElevation = p.Elevation
      OR MaxP.HighestPeakElevation IS NULL
ORDER BY [CountryName],
         [PeakName];

--------------------------------------------------------------------------

SELECT TOP 5 * FROM (
						SELECT c.CountryName, 
							   p.PeakName AS 'HighestPeakName', 
							   p.Elevation AS HighestPeakElevation, 
							   m.MountainRange AS Mountain
							FROM [dbo].[Countries] AS c
						JOIN [dbo].[MountainsCountries] AS mc
							ON mc.CountryCode = c.CountryCode
						JOIN [dbo].[Mountains] AS m
							ON mc.MountainId = m.Id
						JOIN [dbo].[Peaks] AS p
							ON m.Id = p.MountainId
						INNER JOIN(
									SELECT c.CountryName, 
									MAX(p.Elevation) AS MaxElevation
										 FROM [dbo].[Countries] AS c
									JOIN [dbo].[MountainsCountries] AS mc
										ON mc.CountryCode = c.CountryCode
									JOIN [dbo].[Mountains] AS m
										ON mc.MountainId = m.Id
									JOIN [dbo].[Peaks] AS p
										ON m.Id = p.MountainId
									GROUP BY c.CountryName
								   ) AS MaxElevat
						ON MaxElevat.MaxElevation = p.Elevation
						AND MaxElevat.CountryName = c.CountryName
						UNION
						SELECT c.CountryName AS 'Country',
							   '(no highest peak)' AS 'HighestPeakName',
							   0 AS HighestPeakElevation,
							   '(no mountain)' AS Mountain
							FROM [dbo].[Countries] AS c
						LEFT JOIN [dbo].[MountainsCountries] AS mc
							ON c.CountryCode = mc.CountryCode
						WHERE mc.[MountainId] IS NULL
			) AS result
ORDER BY result.CountryName, result.HighestPeakName