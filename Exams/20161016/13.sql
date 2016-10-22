USE AMS;
GO

SELECT TOP 3 c.CustomerID,
             c.FirstName+' '+c.LastName AS FullName,
             t.Price AS 'TicketPrice',
             a.AirportName
FROM Customers AS c
     JOIN Tickets AS t ON t.CustomerID = c.CustomerID
     JOIN Flights AS f ON f.FlightID = t.FlightID
                          AND f.[Status] = 'Delayed'
     JOIN Airports AS a ON a.AirportID = f.DestinationAirportID
ORDER BY [TicketPrice] DESC,
         c.CustomerID ASC;