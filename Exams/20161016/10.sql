USE AMS;
GO

SELECT t.TicketID,
       ap.AirportName AS 'Destination',
       c.FirstName+' '+c.LastName AS CustomerName
FROM Tickets AS t
     JOIN Flights AS f ON t.FlightID = f.FlightID
     JOIN Airports AS ap ON ap.AirportID = f.DestinationAirportID
     JOIN Customers AS c ON c.CustomerID = t.CustomerID
WHERE t.Price < 5000
      AND t.Class = 'First'
ORDER BY t.TicketID;