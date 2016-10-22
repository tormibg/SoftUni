USE SoftUni;
GO

CREATE PROCEDURE usp_GetEmployeesFromTown(
       @str VARCHAR(MAX))
AS
     BEGIN
         SELECT e.FirstName as 'First Name', e.LastName as 'Last Name' from Employees as e 
	    inner join Addresses as a on e.AddressID = a.AddressID
	    inner join Towns as t on t.TownID = a.TownID
         WHERE t.Name LIKE @str;
     END;
GO

EXEC dbo.usp_GetEmployeesFromTown 'Sofia';