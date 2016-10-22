USE Minions;
GO

ALTER TABLE dbo.Minions
ADD TownId INT;

ALTER TABLE dbo.Minions
ADD CONSTRAINT fk_Minions_Towns FOREIGN KEY(townId) REFERENCES dbo.Towns(id);