USE SoftUni;
GO

SELECT t.TownID,
       t.Name
FROM dbo.Towns
AS t
WHERE t.Name LIKE '[mkbe]%'
ORDER BY t.Name ASC;