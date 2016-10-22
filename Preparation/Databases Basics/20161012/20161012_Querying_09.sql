USE Bank;
GO

SELECT TOP 5 c.CustomerID, l.Amount
FROM Customers AS c
	 INNER JOIN
	 Loans AS l
	 ON l.CustomerID = c.CustomerID
WHERE l.Amount >
(
	SELECT AVG(l.Amount) AS AvgAmount
	FROM Customers AS c
		 INNER JOIN
		 Loans AS l
		 ON l.CustomerID = c.CustomerID
	WHERE c.Gender = 'm'
)
	ORDER BY c.LastName ASC;