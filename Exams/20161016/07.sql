USE AMS;
GO

SELECT c.CustomerID,
       c.FirstName+' '+c.LastName AS 'FullName',
       c.Gender
FROM Customers AS c
ORDER BY [FullName] ASC,
         c.CustomerID ASC;