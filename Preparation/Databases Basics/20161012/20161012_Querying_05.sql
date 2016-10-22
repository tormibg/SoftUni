USE Bank;
GO

SELECT c.CityName, b.Name, COUNT(*)
FROM Cities AS c
	 JOIN
	 Branches AS b
	 ON c.CityID = b.CityID
	 JOIN
	 Employees AS e
	 ON e.BranchID = b.BranchID
WHERE c.CityID NOT IN( 4, 5 )
GROUP BY c.CityName, b.Name
HAVING COUNT(*) >= 3;