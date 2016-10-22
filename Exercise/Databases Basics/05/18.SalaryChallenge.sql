USE SoftUni;
GO

SELECT top 10 e.FirstName, e.LastName, e.DepartmentID
FROM Employees AS e
WHERE e.Salary >
(
	SELECT AVG(e2.Salary)
	FROM Employees AS e2s
	WHERE e2.DepartmentID = e.DepartmentID
	GROUP BY e2.DepartmentID
)
ORDER BY e.DepartmentID;