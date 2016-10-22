USE AMS;
GO

CREATE PROCEDURE usp_SubmitReview(
	   @CustomerID int, @ReviewContent varchar(255), @ReviewGrade smallint, @AirlineName varchar(30))
AS
BEGIN
	BEGIN TRANSACTION;
	DECLARE @AirlineID int;
	SELECT @AirlineID = Airlines.AirlineID
	FROM Airlines
	WHERE AirlineName = @AirlineName;
	IF @AirlineID IS NULL
	BEGIN
		ROLLBACK;
		RAISERROR('Airline does not exist.', 16, 1);
		RETURN;
	END;
	DECLARE @CustReviewID int;
	SELECT @CustReviewID = MAX(CustomerReviews.ReviewID)
	FROM CustomerReviews;
	SET @CustReviewID+=1;
	INSERT INTO CustomerReviews( ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID )
	VALUES( @CustReviewID, @ReviewContent, @ReviewGrade, @AirlineID, @CustomerID );
	COMMIT;
END;
GO

EXEC dbo.usp_SubmitReview 1, 'asasa', 5, 'Royal Airline';