USE Bank;
GO

SELECT c.FirstName, c.DateOfBirth, DATEDIFF(year, c.DateOfBirth, '2016-10-01') AS 'Age'
FROM dbo.Customers AS c
WHERE DATEDIFF(year, c.DateOfBirth, GETDATE()) BETWEEN 40 AND 50;