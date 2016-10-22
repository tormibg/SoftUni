USE AMS;
GO

UPDATE [dbo].[Tickets]
  SET price*=1.5
WHERE FlightID IN
(
	SELECT f.FlightID
	FROM [dbo].[Flights] AS f
	WHERE f.AirlineID IN
	(
		SELECT TOP 1 a.AirlineID
		FROM Airlines AS a
		ORDER BY rating DESC
	)
);