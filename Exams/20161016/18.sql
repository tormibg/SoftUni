USE AMS;
GO

CREATE PROCEDURE usp_PurchaseTicket(
	   @CustomerID int, @FlightID int, @TicketPrice decimal(8, 2), @Class varchar(6), @Seat varchar(5))
AS
BEGIN
	BEGIN TRANSACTION;
	DECLARE @CurBalance decimal(13, 2);
	SELECT @CurBalance = cba.Balance
	FROM CustomerBankAccounts AS cba
	WHERE cba.AccountID = @CustomerID;

	IF @CurBalance < @TicketPrice
	BEGIN
		ROLLBACK;
		RAISERROR('Insufficient bank account balance for ticket purchase.', 16, 1);
		RETURN;
	END;

	UPDATE CustomerBankAccounts
	  SET Balance-=@TicketPrice;

	DECLARE @TicketID int;

	SELECT @TicketID = MAX(t.TicketID)
	FROM Tickets AS t;

	SET @TicketID+=1;

	INSERT INTO Tickets( TicketID, Price, Class, Seat, CustomerID, FlightID )
	VALUES( @TicketID, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID );
	COMMIT;
END;
GO