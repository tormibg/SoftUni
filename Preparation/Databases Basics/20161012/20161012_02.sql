USE Bank;
GO

--- DML


INSERT INTO DepositTypes( DepositTypeID, name )
VALUES( 1, 'Time Deposit' ), ( 2, 'Call Deposit' ), ( 3, 'Free Deposit' );

INSERT INTO [dbo].[Deposits]( Amount, StartDate, EndDate, DepositTypeID, CustomerID )
	   SELECT CASE
			  WHEN c.DateOfBirth > '1980-01-01' THEN 1000
			  ELSE 1500
			  END+CASE
				  WHEN c.Gender = 'm' THEN 100
				  WHEN c.Gender = 'f' THEN 200
				  END AS Amount, GETDATE() AS StartDate, NULL AS EndDate,
																 CASE
																 WHEN c.CustomerID > 15 THEN 3
																 WHEN c.CustomerID % 2 = 0 THEN 2
																 WHEN c.CustomerID % 2 != 0 THEN 1
																 END AS DepositTypeID, c.CustomerID
	   FROM [dbo].[Customers] AS c
	   WHERE c.CustomerID < 20;

INSERT INTO EmployeesDeposits( EmployeeID, DepositID )
VALUES( 15, 4 ), ( 20, 15 ), ( 8, 7 ), ( 4, 8 ), ( 3, 13 ), ( 3, 8 ), ( 4, 10 ), ( 10, 1 ), ( 13, 4 ), ( 14, 9 );