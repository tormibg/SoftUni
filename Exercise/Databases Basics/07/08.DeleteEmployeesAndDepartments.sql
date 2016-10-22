USE SoftUni;
GO

ALTER TABLE Employees NOCHECK CONSTRAINT ALL;

ALTER TABLE EmployeesProjects NOCHECK CONSTRAINT ALL;

ALTER TABLE Departments NOCHECK CONSTRAINT ALL;

DELETE FROM Employees
WHERE Employees.DepartmentID IN
(
	SELECT d.DepartmentID
	FROM Departments AS d
	WHERE d.Name = 'Production' OR 
		  d.Name = 'Production Control'
);

DELETE FROM Departments
WHERE Departments.Name = 'Production' OR 
	  Departments.Name = 'Production Control';

ALTER TABLE Employees CHECK CONSTRAINT ALL;

ALTER TABLE EmployeesProjects CHECK CONSTRAINT ALL;

ALTER TABLE Departments CHECK CONSTRAINT ALL;