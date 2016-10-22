USE Bank;
GO

SELECT c.CustomerID, c.Height
FROM Customers AS c
	 LEFT JOIN
	 Accounts AS a
	 ON a.CustomerID = c.CustomerID
WHERE AccountID IS NULL AND 
	  c.Height BETWEEN 1.74 AND 2.04;