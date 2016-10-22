USE SoftUni;
GO

SELECT DepartmentID,
(
    SELECT DISTINCT
           e1.Salary
    FROM Employees AS e1
    WHERE e1.DepartmentID = e.DepartmentID
    ORDER BY e1.Salary DESC
    OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY
) AS ThirdHighestSalary
FROM Employees AS e
WHERE
(
    SELECT DISTINCT
           e2.Salary
    FROM Employees AS e2
    WHERE e2.DepartmentID = e.DepartmentID
    ORDER BY e2.Salary DESC
    OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY
) IS NOT NULL
GROUP BY e.DepartmentID;

--------------------------------------------------------------------------------
WITH
	DistinctSalaries
AS
(
	SELECT DISTINCT
  		e.DepartmentId,
  		e.Salary
  	FROM
  		Employees e
),

	DepartmentIdSalaryRows
AS
(
	SELECT
		ds.DepartmentId,
  		ds.Salary,
		ROW_NUMBER() OVER(PARTITION BY ds.DepartmentID ORDER BY ds.Salary DESC) AS RowNumber
	FROM
		DistinctSalaries ds
)
SELECT
	di.DepartmentId AS DepartmentID,
	di.Salary AS ThirdHighestSalary,
	di.RowNumber
FROM
	DepartmentIdSalaryRows di