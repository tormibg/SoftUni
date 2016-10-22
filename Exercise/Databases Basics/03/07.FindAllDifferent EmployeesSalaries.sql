USE SoftUni
go

--SELECT e.FirstName+'.'+e.LastName+'@softuni.bg' AS 'Full Email Address' FROM dbo.Employees as e
SELECT CONCAT(e.FirstName,'.',e.LastName,'@softuni.bg') FROM Employees AS e