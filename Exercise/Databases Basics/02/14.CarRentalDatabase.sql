CREATE DATABASE CarRental;
GO

USE CarRental;
GO

CREATE TABLE Categories
(
  Id          INT NOT NULL
                  PRIMARY KEY IDENTITY( 1, 1 ),
  Category    NVARCHAR(30) NOT NULL,
  DailyRate   INT,
  WeeklyRate  INT,
  MonthlyRate INT,
  WeekendRate INT);

CREATE TABLE Cars
(
  Id          INT NOT NULL
                  PRIMARY KEY IDENTITY( 1, 1 ),
  PlateNumber NVARCHAR(10) NOT NULL,
  Make        DATE,
  Model       VARCHAR(30),
  CarYear     VARCHAR(4),
  CategoryId  INT,
  Doors       SMALLINT,
  Picture     VARBINARY(MAX),
  Condition   NVARCHAR(30),
  Available   BIT NOT NULL);

CREATE TABLE Employees
(
  Id        INT NOT NULL
                PRIMARY KEY IDENTITY( 1, 1 ),
  FirstName NVARCHAR(30) NOT NULL,
  LastName  NVARCHAR(30),
  Title     NVARCHAR(30),
  Notes     NVARCHAR(MAX));

CREATE TABLE Customers
(
  Id                  INT NOT NULL
                          PRIMARY KEY IDENTITY( 1, 1 ),
  DriverLicenceNumber NVARCHAR(30) NOT NULL,
  FullName            NVARCHAR(30),
  Address             NVARCHAR(30),
  City                NVARCHAR(30),
  ZIPCode             NVARCHAR(30),
  Notes               NVARCHAR(MAX));

CREATE TABLE RentalOrders
(
  Id               INT NOT NULL
                       PRIMARY KEY IDENTITY( 1, 1 ),
  EmployeeId       INT NOT NULL,
  CustomerId       INT NOT NULL,
  CarId            INT NOT NULL,
  CarCondition     NVARCHAR(30),
  TankLevel        DECIMAL(5, 2),
  KilometrageStart DECIMAL(9, 3),
  KilometrageEnd   DECIMAL(9, 3),
  TotalKilometrage DECIMAL(9, 3),
  StartDate        DATE,
  EndDate          DATE,
  TotalDays        SMALLINT,
  RateApplied      NVARCHAR(30),
  TaxRate          DECIMAL(4, 2),
  OrderStatus      BIT,
  Notes            NVARCHAR(MAX));

INSERT INTO dbo.Categories
(
--Id - this column value is auto-generated
Category,
DailyRate,
WeeklyRate,
MonthlyRate,
WeekendRate)
VALUES
(
  N'Седан', 0, 0, 0, 0),
(
  N'Комби', 0, 0, 0, 0),
(
  N'Кабрио', 0, 0, 0, 0);

INSERT INTO dbo.Customers
(
--Id - this column value is auto-generated
DriverLicenceNumber,
FullName,
Address,
City,
ZIPCode,
Notes)
VALUES
(
  N'123AD133', N'Ivan Ivanov', NULL, N'Sofia', N'12345', NULL),
(
  N'456FG234', N'Saho Sashev', NULL, N'Varna', N'76539', NULL),
(
  N'658AS232', N'Petko Petkov', NULL, N'Plovdiv', N'9009', NULL);

INSERT INTO dbo.Employees
(
--Id - this column value is auto-generated
FirstName,
LastName,
Title,
Notes)
VALUES
(
  N'Ivan', N'Ivanov', N'Монтьор', NULL),
(
  N'Vasil', N'Vasilev', N'Boss', NULL),
(
  N'Асен', N'Асенов', N'Дилър', NULL);

INSERT INTO dbo.Cars
(
--Id - this column value is auto-generated
PlateNumber,
Make,
Model,
CarYear,
CategoryId,
Doors,
Picture,
Condition,
Available)
VALUES
(
  N'123qwe345', NULL, 'Lada', '2012', 1, 3, 0x, N'Добро', 1),
(
  N'6865фдс321', NULL, 'Opel', '2011', 2, 5, 0x, N'Добро', 1),
(
  N'SD12132D', NULL, 'BMW', '2015', 3, 2, 0x, N'Добро', 0);

INSERT INTO dbo.RentalOrders
(
--Id - this column value is auto-generated
EmployeeId,
CustomerId,
CarId,
CarCondition,
TankLevel,
KilometrageStart,
KilometrageEnd,
TotalKilometrage,
StartDate,
EndDate,
TotalDays,
RateApplied,
TaxRate,
OrderStatus,
Notes)
VALUES
(
  1, 1, 1, N'Добро', 70, 12111, 12233, 122, '2016-01-01', '2016-01-03', 2, NULL, 0, 0, NULL),
  (
  2, 2, 2, N'Добро', 70, 12111, 12234, 123, '2016-02-01', '2016-02-04', 3, NULL, 0, 0, NULL),
  (
  3, 3, 3, N'Добро', 60, 12111, 12235, 124, '2016-03-01', '2016-03-05', 4, NULL, 0, 0, NULL);
