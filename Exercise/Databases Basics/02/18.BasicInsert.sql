USE SoftUni;
GO

--TRUNCATE TABLE dbo.Employees
--GO

--TRUNCATE TABLE dbo.Departments
--GO

--TRUNCATE TABLE dbo.Addresses
--GO

--TRUNCATE TABLE dbo.Towns
--GO


INSERT INTO dbo.Towns
(
--Id - this column value is auto-generated
Name)
VALUES
(
  N'Sofia'),
(
  N'Plovdiv'),
(
  N'Varna'),
(
  N'Burgas');

INSERT INTO dbo.Departments
(Name)
VALUES
(
  N'Engineering'),
(
  N'Sales'),
(
  N'Marketing'),
(
  N'Software Development'),
(
  N'Quality Assurance');

INSERT INTO dbo.Employees
(
--Id - this column value is auto-generated
FirstName,
MiddleName,
LastName,
JobTitle,
DepartmentId,
HireDate,
Salary,
AddressId)
VALUES
(
  N'Ivan', N'Ivanov', N'Ivanov', N'.NET Developer', 4, '2013-02-01', 3500, NULL),
  (
  N'Petar', N'Petrov', N'Petrov', N'Senior Engineer', 1, '2004-03-02', 4000, NULL),
  (
  N'Maria', N'Petrova', N'Ivanova', N'Intern', 5, '2016-08-28', 525.25, NULL),
  (
  N'Georgi', N'Teziev', N'Ivanov', N'CEO', 2, '2007-12-09', 3000, NULL),
  (
  N'Peter', N'Pan', N'Pan', N'Intern', 3, '2016-08-28', 599.88, NULL);