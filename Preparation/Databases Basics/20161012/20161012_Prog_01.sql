USE Bank;
GO

CREATE FUNCTION udf_ConcatString
( 
				@FirstStr varchar(max), @SecStr varchar(max)
)
RETURNS varchar(max)
BEGIN
	RETURN CONCAT(REVERSE(@FirstStr), REVERSE(@SecStr));
END;