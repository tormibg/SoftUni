USE SoftUni;
GO

SELECT em.EmployeeID,
       em.FirstName,
       em.ManagerID,
(
    SELECT emp.FirstName
    FROM Employees AS emp
    WHERE em.ManagerID = emp.EmployeeID
) AS ManagerName
FROM Employees AS em
WHERE em.ManagerID IN(3, 7)
ORDER BY em.EmployeeID;