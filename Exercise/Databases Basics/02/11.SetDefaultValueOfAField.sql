USE Minions;
GO

ALTER TABLE dbo.Users
ADD CONSTRAINT cns_Default DEFAULT GETDATE( ) FOR LastLoginTime;