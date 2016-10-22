USE SoftUni;
GO

SELECT TOP 5 em.EmployeeID,
             em.JobTitle,
             em.AddressID,
             ad.AddressText
FROM Employees em
     LEFT JOIN Addresses ad ON em.AddressID = ad.AddressID
ORDER BY em.AddressID;