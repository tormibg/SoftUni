USE SoftUni;
GO

SELECT COUNT(1) AS 'Count'
FROM Employees e
WHERE e.ManagerID IS NULL;