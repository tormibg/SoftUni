USE Minions;
GO

ALTER TABLE dbo.Users
ADD CONSTRAINT chk_Password CHECK( LEN(Password) >= 5 );

