USE AMS;
GO

SELECT DISTINCT
       c.CustomerID,
       c.FirstName+' '+c.LastName AS FullName,
       DATEDIFF(year, c.DateOfBirth, '2016') AS 'Age'
FROM Customers AS c
     JOIN Tickets AS ti ON ti.CustomerID = c.CustomerID
     JOIN Flights AS f ON f.FlightID = ti.FlightID
                          AND f.[Status] = 'Departing'
ORDER BY [Age] ASC,
         c.CustomerID ASC;