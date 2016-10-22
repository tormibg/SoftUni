USE SoftUni;
GO

SELECT top 10 p.*
FROM dbo.Projects p
ORDER BY p.StartDate ASC,
         p.Name ASC;