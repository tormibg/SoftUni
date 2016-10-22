USE SoftUni;
GO

SELECT TOP 3 em.EmployeeID,
             em.FirstName
FROM Employees AS em
WHERE em.EmployeeID NOT IN
(
    SELECT empr.EmployeeID
    FROM EmployeesProjects AS empr
)
ORDER BY em.EmployeeID ASC;