USE AMS;
GO

SELECT ap.AirportID,
       ap.AirportName,
       CountPass.pas
FROM Airports AS ap
     JOIN Flights AS f ON f.OriginAirportID = ap.AirportID
                          AND f.[Status] = 'Departing'
     JOIN
(
    SELECT COUNT(1) AS 'pas',
           t.FlightID
    FROM Tickets AS t
    GROUP BY t.FlightID
) AS CountPass ON f.FlightID = CountPass.FlightID
WHERE CountPass.pas != 0
ORDER BY ap.AirportID ASC;