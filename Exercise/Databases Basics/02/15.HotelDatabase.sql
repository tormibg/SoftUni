CREATE DATABASE Hotel;
GO

USE Hotel;
GO

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
  AccountNumber   INT NOT NULL
                      PRIMARY KEY IDENTITY( 1, 1 ),
  FirstName       NVARCHAR(30) NOT NULL,
  LastName        NVARCHAR(30),
  PhoneNumber     NVARCHAR(30),
  EmergencyName   NVARCHAR(30),
  EmergencyNumber NVARCHAR(30),
  Notes           NVARCHAR(MAX));

CREATE TABLE RoomStatus
(
  RoomStatus INT NOT NULL
                 PRIMARY KEY IDENTITY( 1, 1 ),
  Notes      NVARCHAR(MAX));

CREATE TABLE RoomTypes
(
  RoomType INT NOT NULL
               PRIMARY KEY IDENTITY( 1, 1 ),
  Notes    NVARCHAR(MAX));

CREATE TABLE BedTypes
(
  BedType INT NOT NULL
              PRIMARY KEY IDENTITY( 1, 1 ),
  Notes   NVARCHAR(MAX));

CREATE TABLE Rooms
(
  RoomNumber INT NOT NULL
                 PRIMARY KEY IDENTITY( 1, 1 ),
  RoomType   INT NOT NULL,
  BedType    INT NOT NULL,
  Rate       SMALLINT,
  RoomStatus INT NOT NULL,
  Notes      NVARCHAR(MAX));

CREATE TABLE Payments
(
  Id                INT NOT NULL
                        PRIMARY KEY IDENTITY( 1, 1 ),
  EmployeeId        INT NOT NULL,
  PaymentDate       DATE NOT NULL,
  AccountNumber     INT NOT NULL,
  FirstDateOccupied DATE NOT NULL,
  LastDateOccupied  DATE NOT NULL,
  TotalDays         INT NOT NULL
                        DEFAULT 'DATEDIFF( day, FirstDateOccupied, LastDateOccupied )',
  AmountCharged     MONEY NOT NULL,
  TaxRate           NUMERIC(5, 2) NOT NULL,
  TaxAmount         NUMERIC(9, 2) NOT NULL
                                  DEFAULT 'AmountCharged*TaxAmount',
  PaymentTotal      NUMERIC NOT NULL
                            DEFAULT 'AmountCharged+TaxAmount',
  Notes             NVARCHAR(MAX));

CREATE TABLE Occupancies
(
  Id            INT NOT NULL
                    PRIMARY KEY IDENTITY( 1, 1 ),
  EmployeeId    INT NOT NULL,
  DateOccupied  DATE NOT NULL,
  AccountNumber INT NOT NULL,
  RoomNumber    INT NOT NULL,
  RateApplied   BIT,
  PhoneCharge   DECIMAL(5, 2),
  Notes         NVARCHAR(MAX));

INSERT INTO dbo.BedTypes
(
--BedType - this column value is auto-generated
Notes)
VALUES
(
  N'единични'),
(
  N'двойни'),
(
  N'king');

INSERT INTO dbo.RoomStatus
(
--RoomStatus - this column value is auto-generated
Notes)
VALUES
(
  N'свободна'),
(
  N'заета'),
(
  N'в ремонт');

INSERT INTO dbo.RoomTypes
(
--RoomType - this column value is auto-generated
Notes)
VALUES
(
  N'студио'),
(
  N'апартамент'),
(
  N'почивки');

INSERT INTO dbo.Employees
(
--Id - this column value is auto-generated
FirstName,
LastName,
Title,
Notes)
VALUES
(
  N'Иван', N'Иванов', N'Президент', NULL),
(
  N'Асен', N'Асенов', N'Работник', NULL),
(
  N'Петя', N'Петрова', N'Секретарка', NULL);

INSERT INTO dbo.Customers
(
--AccountNumber - this column value is auto-generated
FirstName,
LastName,
PhoneNumber,
EmergencyName,
EmergencyNumber,
Notes)
VALUES
(
  N'Петър', N'Петров', N'0888123456', N'Какво', N'123', NULL),
(
  N'Никола', N'Николов', N'0888555666', N'Какво1', N'124', NULL),
(
  N'Мария', N'Петрова', N'0888777888', N'Какво2', N'125', NULL);

INSERT INTO dbo.Rooms
(
--RoomNumber - this column value is auto-generated
RoomType,
BedType,
Rate,
RoomStatus,
Notes)
VALUES
(
  1, 1, 5, 1, NULL),
(
  2, 2, 4, 2, NULL),
(
  3, 3, 4, 3, NULL);

INSERT INTO dbo.Payments
(
--Id - this column value is auto-generated
EmployeeId,
PaymentDate,
AccountNumber,
FirstDateOccupied,
LastDateOccupied,
TotalDays,
AmountCharged,
TaxRate,
TaxAmount,
PaymentTotal,
Notes)
VALUES
(
  1, '2016-09-12', 1, '2016-09-01', '2016-09-02', 1, 10, 0.2, 2, 12, NULL),
(
  2, '2016-09-12', 2, '2016-09-01', '2016-09-03', 2, 20, 0.2, 4, 24, NULL),
(
  2, '2016-09-12', 2, '2016-09-01', '2016-09-04', 3, 100, 0.2, 20, 120, NULL);

INSERT INTO dbo.Occupancies
(
--Id - this column value is auto-generated
EmployeeId,
DateOccupied,
AccountNumber,
RoomNumber,
RateApplied,
PhoneCharge,
Notes)
VALUES
(
  1, '2016-09-01', 1, 1, 1, 10, NULL),
(
  2, '2016-09-02', 2, 2, 2, 20, NULL),
(
  3, '2016-09-03', 3, 3, 3, 10, NULL);