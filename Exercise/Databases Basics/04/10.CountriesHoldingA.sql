USE Geography;
GO

SELECT c.CountryName,
       c.IsoCode
FROM dbo.Countries
AS c
WHERE c.CountryName LIKE '%a%a%a%'
ORDER BY c.IsoCode;