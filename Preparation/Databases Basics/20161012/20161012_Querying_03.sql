USE Bank;
GO

SELECT c.CustomerID, c.FirstName, c.LastName, c.Gender, c2.CityName
FROM dbo.Customers AS c
	 LEFT JOIN
	 dbo.Cities AS c2
	 ON c2.CityID = c.CityID
WHERE( c.LastName LIKE 'Bu%' OR 
	   RIGHT(c.FirstName, 1) = 'a'
	 ) AND 
	 LEN(c2.CityName) >= 8
ORDER BY c.CustomerID ASC;