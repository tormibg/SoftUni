CREATE DATABASE SoftUni;
GO

USE SoftUni;
GO

CREATE TABLE Towns
(
  Id   INT NOT NULL
           PRIMARY KEY IDENTITY( 1, 1 ),
  Name NVARCHAR(30) NOT NULL);

CREATE TABLE Addresses
(
  Id          INT NOT NULL
                  PRIMARY KEY IDENTITY( 1, 1 ),
  AddressText NVARCHAR(MAX) NOT NULL,
  TownId      INT NOT NULL
                  FOREIGN KEY REFERENCES dbo.Towns( id ));

CREATE TABLE Departments
(
  Id   INT NOT NULL
           PRIMARY KEY IDENTITY( 1, 1 ),
  Name NVARCHAR(30) NOT NULL);

CREATE TABLE Employees
(
  Id           INT NOT NULL
                   PRIMARY KEY IDENTITY( 1, 1 ),
  FirstName    NVARCHAR(30) NOT NULL,
  MiddleName   NVARCHAR(30),
  LastName     NVARCHAR(30),
  JobTitle     NVARCHAR(30) NOT NULL,
  DepartmentId INT NOT NULL
                   FOREIGN KEY REFERENCES dbo.Departments( id ),
  HireDate     DATE NOT NULL,
  Salary       DECIMAL(9, 2),
  AddressId    INT FOREIGN KEY REFERENCES dbo.Addresses( id ));

--INSERT INTO dbo.Towns
--(
----Id - this column value is auto-generated
--Name)
--VALUES
--(
--  N'София'),
--(
--  N'Пловдив'),
--(
--  N'Варна');

--INSERT INTO dbo.Addresses
--(
----Id - this column value is auto-generated
--AddressText,
--TownId)
--VALUES
--(
--  N'Някъде в София', 1),
--(
--  N'Някъде в Пловдив', 2),
--(
--  N'Някъде във Варна', 3);

--INSERT INTO dbo.Departments
--(
----Id - this column value is auto-generated
--Name)
--VALUES
--(
--  N'IT'),
--(
--  N'Sales'),
--(
--  N'Security');

--INSERT INTO dbo.Employees
--(
----Id - this column value is auto-generated
--FirstName,
--MiddleName,
--LastName,
--JobTitle,
--DepartmentId,
--HireDate,
--Salary,
--AddressId)
--VALUES
--(
--  N'Иван', N'Иванов', N'Иванов', N'Sys Admin', 1, '2016-01-01', 1000, 1),
--(
--  N'Петър', N'Иванов', N'Петров', N'Sale Director', 2, '2016-02-02', 2500, 2),
--(
--  N'Асен', N'Иванов', N'Асенов', N'Security', 3, '2016-03-03', 1500, 3);