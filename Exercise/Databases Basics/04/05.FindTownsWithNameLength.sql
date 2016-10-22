USE SoftUni;
GO

SELECT e.Name
FROM dbo.Towns
AS e
WHERE LEN( e.name ) BETWEEN 5 AND 6
ORDER BY e.Name;