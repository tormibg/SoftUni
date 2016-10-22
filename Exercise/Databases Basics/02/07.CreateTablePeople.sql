USE Minions;
GO

CREATE TABLE People
(
  id        INTEGER NOT NULL
                    PRIMARY KEY IDENTITY( 1, 1 ),
  Name      NVARCHAR(200) NOT NULL,
  Picture   VARBINARY(MAX) CHECK( DATALENGTH( Picture )<=2097152 ),
  Height    DECIMAL(3, 2),
  Weight    DECIMAL(5, 2),
  Gender    CHAR(1) NOT NULL
                    CHECK( Gender='m'
                           OR Gender='f' ),
  Birthdate DATE NOT NULL,
  Biography NVARCHAR(MAX));
INSERT INTO dbo.People
(
--id - this column value is auto-generated
Name,
Picture,
Height,
Weight,
Gender,
Birthdate,
Biography)
VALUES
(
  N'Иван', 0x, 1.80, 80.12, 'm', '2000-01-01', N'Първи'),
(
  N'Тодор', 0x, 1.77, 79.13, 'm', '1999-02-02', N'Втори'),
(
  N'Петкан', 0x, 1.99, 90.15, 'm', '1998-03-03', N'Трети'),
(
  N'Ася', 0x, 1.67, 65.65, 'f', '2001-04-04', N'Четвърта'),
(
  N'Поля', 0x, 1.83, 79.45, 'f', '2002-05-05', N'Пета');