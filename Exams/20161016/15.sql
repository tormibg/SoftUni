USE AMS;
GO

SELECT c.CustomerID,
       c.FirstName+' '+c.LastName AS FullName,
       DATEDIFF(year, c.DateOfBirth, '2016') AS 'Age'
FROM Customers AS c
     JOIN Tickets AS t ON t.CustomerID = c.CustomerID
     JOIN Flights AS f ON f.FlightID = t.FlightID
                          AND f.[Status] = 'Arrived'
WHERE DATEDIFF(year, c.DateOfBirth, '2016') < 21
ORDER BY [Age] DESC,
         c.CustomerID ASC;