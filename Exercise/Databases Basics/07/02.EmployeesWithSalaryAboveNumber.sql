USE SoftUni;
GO

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(
       @salMoney MONEY)
AS
     BEGIN
         SELECT e.FirstName , e.LastName
         FROM dbo.Employees AS e
         WHERE e.Salary >= @salMoney;
     END;
GO

EXEC dbo.usp_GetEmployeesSalaryAboveNumber @salMoney = 1200;