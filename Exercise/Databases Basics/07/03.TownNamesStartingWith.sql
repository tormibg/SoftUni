USE SoftUni;
GO

CREATE PROCEDURE usp_GetTownsStartingWith(
       @str VARCHAR(MAX))
AS
     BEGIN
         SELECT t.Name AS Town
         FROM dbo.Towns AS t
         WHERE t.Name LIKE @str+'%';
     END;
GO

EXEC dbo.usp_GetTownsStartingWith 'b';