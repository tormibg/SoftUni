USE Bank;
GO

CREATE PROCEDURE usp_CustomersWithUnexpiredLoans(
	   @CustomerID int)
AS
BEGIN
	SELECT c.CustomerID, c.FirstName, l.LoanID
	FROM dbo.Customers AS c
		 JOIN
		 dbo.Loans AS l
		 ON l.CustomerID = c.CustomerID
	WHERE c.CustomerID = @CustomerID AND 
		  l.ExpirationDate IS NULL;
END;