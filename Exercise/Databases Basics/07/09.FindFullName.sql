USE bank;
GO

CREATE PROCEDURE udp_GetHoldersFullName
AS
     BEGIN
         SELECT ah.FirstName+' '+ah.LastName AS 'Full Name'
         FROM AccountHolders AS ah;
     END;
GO

EXEC dbo.udp_GetHoldersFullName;