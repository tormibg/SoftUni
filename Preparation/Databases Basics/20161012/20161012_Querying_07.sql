USE Bank;
GO

SELECT TOP 3 e.FirstName, c.CityName
FROM Employees AS e
	 JOIN
	 Branches AS b
	 ON b.BranchID = e.BranchID
	 JOIN
	 Cities AS c
	 ON c.CityID = b.CityID
UNION ALL
SELECT TOP 3 cu.FirstName, ci.CityName
FROM Customers AS cu
	 JOIN
	 Cities AS ci
	 ON ci.CityID = cu.CityID;