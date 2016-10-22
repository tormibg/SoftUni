USE AMS;
GO

SELECT c.CustomerID,
       c.FirstName+' '+c.LastName AS FullName,
       tw.TownName AS HomeTown
FROM Customers AS c
     JOIN Tickets AS t ON t.CustomerID = c.CustomerID
     JOIN Flights AS f ON f.FlightID = t.FlightID
                          AND f.[Status] = 'departing'
     JOIN Airports AS ap ON ap.AirportID = f.OriginAirportID
     JOIN Towns AS tw ON tw.TownID = ap.TownID
WHERE c.HomeTownID = tw.TownID
ORDER BY c.CustomerID ASC;