USE Geography;
GO

SELECT p.PeakName,
       m.MountainRange AS Mountain,
       c.CountryName,
       co.ContinentName
FROM Peaks p
     JOIN Mountains m ON m.Id = p.MountainId
     JOIN MountainsCountries mc ON mc.MountainId = m.Id
     JOIN Countries c ON c.CountryCode = mc.CountryCode
     JOIN Continents co ON co.ContinentCode = c.ContinentCode
ORDER BY PeakName,
         CountryName;