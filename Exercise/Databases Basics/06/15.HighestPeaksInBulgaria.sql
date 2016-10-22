USE Geography;
GO

SELECT c.CountryCode,
       mnt.MountainRange,
       p.PeakName,
       p.Elevation
FROM Countries AS c
     INNER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
     INNER JOIN Mountains AS mnt ON mc.MountainId = mnt.Id
     INNER JOIN Peaks AS p ON mnt.Id = p.MountainId
WHERE c.CountryName = 'Bulgaria'
      AND p.Elevation > 2835
ORDER BY p.Elevation DESC;