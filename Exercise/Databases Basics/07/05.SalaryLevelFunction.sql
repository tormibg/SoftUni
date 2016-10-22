USE SoftUni;
GO

CREATE FUNCTION ufn_GetSalaryLevel
( 
				@salary money
)
RETURNS varchar(max)
AS
BEGIN
	DECLARE @return AS varchar(max);
	IF(@salary < 30000)
	BEGIN
		SET @return = 'Low';
	END;
	ELSE
	BEGIN
		IF( @salary >= 30000 AND 
			@salary <= 50000
		  )
		BEGIN
			SET @return = 'Average';
		END;
		ELSE
		BEGIN
			SET @return = 'High';
		END;
	END;
	RETURN @return;
END;
GO

SELECT e.Salary, dbo.ufn_GetSalaryLevel( e.Salary ) AS 'Salary Level'
FROM Employees AS e
ORDER BY Salary DESC;