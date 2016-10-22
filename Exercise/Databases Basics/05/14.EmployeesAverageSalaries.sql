USE SoftUni;
GO

SELECT *
INTO EmplNewTable
FROM Employees AS e
WHERE e.Salary > 30000;

DELETE FROM EmplNewTable
WHERE EmplNewTable.ManagerID = 42;

UPDATE EmplNewTable
  SET
      Salary+=5000
WHERE EmplNewTable.DepartmentID = 1;

SELECT ent.DepartmentID,
       AVG(ent.Salary)
FROM EmplNewTable AS ent
GROUP BY ent.DepartmentID;