USE SoftUni;
GO

SELECT em.EmployeeID,
       em.FirstName,
       'ProjectName' = CASE
                           WHEN YEAR(pr.StartDate) >= 2005
                           THEN NULL
                           ELSE pr.Name
                       END
FROM Employees AS em
     INNER JOIN EmployeesProjects AS empr ON em.EmployeeID = empr.EmployeeID
     INNER JOIN Projects AS pr ON empr.ProjectID = pr.ProjectID
WHERE em.EmployeeID = 24;