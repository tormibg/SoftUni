USE Minions;
GO

DECLARE
  @sql NVARCHAR(MAX);

SELECT @sql='ALTER TABLE dbo.Users DROP CONSTRAINT '+name+';'
FROM sys.key_constraints kc
WHERE kc.type='PK'
      AND kc.parent_object_id=OBJECT_ID( 'dbo.Users' );

EXEC sp_executeSQL
     @sql;

ALTER TABLE dbo.Users
ADD CONSTRAINT PK_ID PRIMARY KEY( id );

ALTER TABLE dbo.Users
ADD CONSTRAINT uc_UserName UNIQUE( UserName );

ALTER TABLE dbo.Users
ADD CONSTRAINT chk_UserName CHECK( LEN( UserName )>=3 );