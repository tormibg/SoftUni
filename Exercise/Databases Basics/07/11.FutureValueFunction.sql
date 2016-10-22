USE bank;
GO

CREATE FUNCTION ufn_CalculateFutureValue
(@sum MONEY,
 @R   FLOAT,
 @T   INT
)
RETURNS MONEY
AS
     BEGIN
         DECLARE @result MONEY;
         SET @result = @sum * POWER((1 + @R), @T);
         RETURN @result;
     END;
GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5);