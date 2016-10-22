USE Geography;
GO

SELECT mc.CountryCode,
       COUNT(mnt.MountainRange)
FROM Mountains AS mnt
     left JOIN MountainsCountries mc ON mnt.Id = mc.MountainId
WHERE mc.MountainId IN
(
    SELECT mc.MountainId
    FROM MountainsCountries AS mc
    WHERE mc.CountryCode IN
    (
        SELECT c.CountryCode
        FROM Countries AS c
        WHERE c.CountryName IN('United States', 'Russia', 'Bulgaria')
    )
)
GROUP BY mc.CountryCode
having mc.CountryCode in ('BG','RU','US')

---------------------------------------
SELECT c.CountryCode,
       COUNT(mc.MountainId)
FROM Countries c
     JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
WHERE c.CountryName IN('United States', 'Russia', 'Bulgaria')
GROUP BY c.CountryCode;