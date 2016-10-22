USE Bank;
GO

CREATE PROCEDURE usp_TakeLoan(
	   @CustomerID int, @LoanAmount decimal(10, 2), @Interest decimal(10, 2), @StartDate date)
AS
BEGIN
	BEGIN TRANSACTION;
	INSERT INTO Loans( CustomerID, Amount, Interest, StartDate )
	VALUES( @CustomerID, @LoanAmount, @Interest, @StartDate );

	IF @LoanAmount NOT BETWEEN 0.01 AND 100000
	BEGIN
		ROLLBACK;
		RAISERROR('Invalid Loan Amount.', 16, 1);
		RETURN;
	END;

	COMMIT;
END;