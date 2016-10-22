USE Gringotts;
GO

SELECT SUM(TableHG.Difference) AS 'SumDifference'
FROM
(
    SELECT wd.FirstName AS 'Host Wizard',
           wd.DepositAmount AS 'Host Wizard Deposit',
           WizzardTable.FirstName AS 'Guest Wizard',
           WizzardTable.DepositAmount AS 'Guest Wizard Deposit',
           wd.DepositAmount - WizzardTable.DepositAmount AS 'Difference'
    FROM WizzardDeposits AS wd
         JOIN
    (
        SELECT wd.id - 1 AS 'id',
               wd.FirstName,
               wd.DepositAmount
        FROM WizzardDeposits AS wd
    ) AS WizzardTable ON wd.Id = WizzardTable.Id
) AS TableHG;