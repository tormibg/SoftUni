USE SoftUni;
GO

SELECT TOP 5 em.EmployeeID,
             em.FirstName,
             pr.Name
FROM Employees AS em
     INNER JOIN EmployeesProjects AS empr ON em.EmployeeID = empr.EmployeeID
     INNER JOIN Projects AS pr ON empr.ProjectID = pr.ProjectID
WHERE pr.StartDate > '2002-08-13'
      AND pr.EndDate IS NULL
ORDER BY em.EmployeeID ASC;