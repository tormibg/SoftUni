USE Minions;
GO

INSERT INTO dbo.Towns
(id,
 Name)
VALUES
(
  1, N'Sofia'),
(
  2, N'Plovdiv'),
(
  3, N'Varna');

INSERT INTO dbo.Minions
(id,
 Name,
 Age,
 TownId)
VALUES
(
  1, N'Kevin', 22, 1),
(
  2, N'Bob', 15, 3),
(
  3, N'Steward', NULL, 2);