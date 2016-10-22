USE Minions;
GO

CREATE TABLE Users
(
  id            BIGINT NOT NULL
                       PRIMARY KEY IDENTITY( 1, 1 ),
  Name          VARCHAR(30) NOT NULL,
  Password      VARCHAR(26) NOT NULL,
  Picture       VARBINARY(MAX) CHECK( DATALENGTH( Picture )<=921600 ),
  LastLoginTime DATETIME,
  IsDeleted     BIT);

INSERT INTO dbo.Users
(
--id - this column value is auto-generated
Name,
Password,
Picture,
LastLoginTime,
IsDeleted)
VALUES
(
  'Ivan', 'Ivan', 0x, NULL, 0),
(
  'Todor', 'Todor', 0x, NULL, 1),
(
  'Petkan', 'Petkan', 0x, NULL, 0),
(
  'Asia', 'Asia', 0x, NULL, 1),
(
  'Polia', 'Polia', 0x, NULL, 0);




