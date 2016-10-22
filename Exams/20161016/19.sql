USE AMS;
GO

CREATE TRIGGER tr_ArrivedFlights ON dbo.Flights
INSTEAD OF UPDATE
AS
     BEGIN
         BEGIN TRANSACTION;
         IF OBJECT_ID(N'dbo.ArrivedFlights', N'U') IS NULL
             BEGIN
                 CREATE TABLE ArrivedFlights
                 (FlightID    INT PRIMARY KEY,
                  ArrivalTime DATETIME NOT NULL,
                  Origin      VARCHAR(50) NOT NULL,
                  Destination VARCHAR(50) NOT NULL,
                  Passengers  INT NOT NULL
                 );
             END;
         INSERT INTO ArrivedFlights
         (FlightID,
          ArrivalTime,
          Origin,
          Destination,
          Passengers
         )
                SELECT i.FlightID,
                       i.ArrivalTime,
                       ap1.AirportName,
                       ap2.AirportName,
                       isnull(
                             (
                                 SELECT COUNT(1)
                                 FROM Tickets AS t
                                      JOIN inserted AS i ON i.FlightID = t.FlightID
                                                            AND i.[Status] = 'Arrived'
                                 GROUP BY i.FlightID
                             ), 0) AS Passengers
                FROM inserted AS i
                     JOIN Airports AS ap1 ON ap1.AirportID = i.OriginAirportID
                     JOIN Airports AS ap2 ON ap2.AirportID = i.DestinationAirportID
                WHERE i.[Status] = 'Arrived';
         UPDATE Flights
           SET
               [Status] = i.[status]
         FROM Flights AS f
              JOIN inserted AS i ON i.FlightID = f.FlightID;
         COMMIT;
     END;