USE AMS;
GO

SELECT t.TicketID, t.Price, t.Class, t.Seat
FROM Tickets AS t
ORDER BY t.TicketID ASC;