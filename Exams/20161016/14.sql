USE AMS;
GO

SELECT TOP 5 f.FlightID,
             f.DepartureTime,
             f.ArrivalTime,
             ap1.AirportName as 'Origin',
             ap2.AirportName as 'Destination'
FROM Flights AS f
     JOIN Airports AS ap1 ON ap1.AirportID = f.OriginAirportID
     JOIN Airports AS ap2 ON ap2.AirportID = f.DestinationAirportID
WHERE f.[Status] = 'Departing'
ORDER BY f.DepartureTime ASC,
         f.FlightID ASC;