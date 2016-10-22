USE SoftUni;
GO

CREATE PROCEDURE ufn_EmployeesBySalaryLevel(
	   @salLvl varchar(max))
AS
BEGIN
	DECLARE @srtWhere varchar(max);
	IF(@salLvl = 'Low')
	BEGIN
		SET @srtWhere = 'e.Salary < 30000';
	END;
	ELSE
	BEGIN
		IF(@salLvl = 'Average')
		BEGIN
			SET @srtWhere = 'e.Salary >= 30000 and e.Salary <= 50000';
		END;
		ELSE
		BEGIN
			IF(@salLvl = 'High')
			BEGIN
				SET @srtWhere = 'e.Salary > 50000';
			END;
		END;
	END;
	DECLARE @sql nvarchar(max);

	SET @sql = 'select e.FirstName as ''First Name'' FROM Employees as e WHERE ('+@srtWhere+')';

	EXEC sp_executesql @sql;

END;
GO

EXEC dbo.ufn_EmployeesBySalaryLevel 'High';