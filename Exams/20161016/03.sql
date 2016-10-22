USE AMS;
GO

UPDATE [dbo].[Flights]
  SET [AirlineID] = 1
WHERE [status] = 'Arrived';