-- One to one
CREATE DATABASE OneToOne
GO

USE OneToOne
GO

CREATE TABLE Drivers(
DriverID INT PRIMARY KEY,
DriverName VARCHAR(50)
)

CREATE TABLE Cars(
CarID INT PRIMARY KEY,
Name VARCHAR(50),
DriverID INT UNIQUE,
CONSTRAINT FK_Cars_Drivers FOREIGN KEY(DriverID)
REFERENCES Drivers(DriverID)
)


INSERT INTO Drivers (DriverID,DriverName)
VALUES (1, 'Pesho')


INSERT INTO Cars(CarID, DriverID)
VALUES (101, 1)

INSERT INTO Cars(CarID, DriverID)
VALUES (102, NULL)

INSERT INTO Cars(CarID, DriverID)
VALUES (103, 1)

UPDATE Drivers
SET DriverID = 2
WHERE DriverID = 1


-- Many-to-Many

CREATE TABLE Employees(
	EmployeeID INT PRIMARY KEY,
	FirstName VARCHAR(50)
)

CREATE TABLE Projects(
	ProjectID INT PRIMARY KEY,
	ProjectName VARCHAR(50)
)

INSERT INTO Employees (EmployeeID, FirstName)
VALUES (1, 'John'), (2, 'Adam')

INSERT INTO Projects (ProjectID, ProjectName)
VALUES (101, 'Web Store'), (102, 'Database Design'), 
(103, 'Android App')

CREATE TABLE EmployeesProjects(
EmployeeID INT,
ProjectID INT,
CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
CONSTRAINT FK_EmployeesProjects_Employees FOREIGN KEY(EmployeeID)
REFERENCES Employees(EmployeeID),
CONSTRAINT FK_EmployeesProjects_Projects FOREIGN KEY(ProjectID)
REFERENCES Projects(ProjectID)
)

INSERT INTO Employees (EmployeeID, FirstName)
VALUES (1, 'John'), (2, 'Adam')

INSERT INTO Projects (ProjectID, ProjectName)
VALUES (101, 'Web Store'), (102, 'Database Design'), 
(103, 'Android App')

INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
VALUES (1, 101), (1, 102), (2, 102), (2, 103), (1, 103)

INSERT INTO EmployeesProjects(EmployeeID)
VALUES (1)

-- Cascade
CREATE DATABASE CascadeDemo
GO

USE CascadeDemo
GO

CREATE TABLE Drivers(
DriverID INT PRIMARY KEY,
DriverName VARCHAR(50)
)

CREATE TABLE Cars(
CarID INT PRIMARY KEY,
Name VARCHAR(50),
DriverID INT UNIQUE,
CONSTRAINT FK_Cars_Drivers FOREIGN KEY(DriverID)
REFERENCES Drivers(DriverID) ON UPDATE CASCADE
)


INSERT INTO Drivers (DriverID,DriverName)
VALUES (1, 'Pesho')


INSERT INTO Cars(CarID, DriverID)
VALUES (101, 1)


UPDATE Drivers
   SET DriverID = 2
 WHERE DriverID = 1

-- Joins
USE SoftUni
GO


SELECT * 
  FROM [dbo].[Employees] AS e
 INNER JOIN [dbo].[Departments] AS d
    ON e.DepartmentID = d.DepartmentID


INSERT INTO [dbo].[Employees] 
(FirstName, ManagerID, DepartmentID)
VALUES ('Pesho', 1, NULL)


SELECT * 
  FROM [dbo].[Employees] AS e
  LEFT JOIN  [dbo].[Departments] AS d
    ON e.DepartmentID = d.DepartmentID


SELECT * 
  FROM [dbo].[Employees] AS e
 RIGHT JOIN  [dbo].[Departments] AS d
    ON e.DepartmentID = d.DepartmentID

INSERT INTO Departments ( ManagerID, Name)
VALUES (1, 'Database Support')


SELECT * 
  FROM [dbo].[Employees] AS e
  FULL JOIN  [dbo].[Departments] AS d
    ON e.DepartmentID = d.DepartmentID


-- FROM Tables

SELECT *
  FROM [dbo].[Employees] AS e
 INNER JOIN [dbo].[Departments] AS d
    ON d.DepartmentID = e.DepartmentID
 INNER JOIN [dbo].[EmployeesProjects] AS ep
    ON ep.EmployeeID = e.EmployeeID

SELECT *
  FROM [dbo].[Employees] AS e,
       [dbo].[Departments] AS d,
	   [dbo].[EmployeesProjects] AS ep
 WHERE e.DepartmentID = d.DepartmentID
   AND e.Salary > 10000
   AND d.ManagerID !=1 
   AND ep.EmployeeID = e.EmployeeID


-- Subqueries
SELECT * 
  FROM [dbo].[Employees] AS e
 WHERE e.Salary > 10000


 SELECT * 
   FROM [dbo].[Employees] AS e
   WHERE e.EmployeeID IN (SELECT e.EmployeeID 
                            FROM [dbo].[Employees] AS e
						   WHERE e.Salary > 10000)




 SELECT MAX(AverageSalary) AS MaxAverageSalary
   FROM 
(SELECT e.DepartmentID, AVG(e.Salary) AS AverageSalary
   FROM [dbo].[Employees] AS e
  GROUP BY e.DepartmentID) AS av

-- CTE

SELECT 1

;
WITH av AS(
 SELECT e.DepartmentID, AVG(e.Salary) AS AverageSalary
   FROM [dbo].[Employees] AS e
  GROUP BY e.DepartmentID
), 
avn AS(
SELECT * 
  FROM av
 WHERE av.DepartmentID IS NOT NULL
)
SELECT * FROM avn

-- Indexes

CREATE NONCLUSTERED INDEX IX_Employees_FirstName_Salary
    ON Employees(FirstName,Salary)

SELECT e.FirstName, e.Salary 
  FROM Employees AS e
 