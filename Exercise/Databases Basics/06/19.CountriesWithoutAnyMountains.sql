USE Geography;
GO

SELECT COUNT(1) AS 'CountryCode'
FROM dbo.Countries AS c
WHERE c.CountryCode NOT IN
(
    SELECT mc.CountryCode
    FROM dbo.MountainsCountries AS mc
)