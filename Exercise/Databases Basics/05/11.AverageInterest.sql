USE Gringotts;
GO

SELECT wd.DepositGroup,
       wd.IsDepositExpired,
       AVG(wd.DepositInterest) AS 'AverageInterest'
FROM WizzardDeposits AS wd
WHERE wd.DepositStartDate > '1985-01-01'
GROUP BY wd.DepositGroup,
         wd.IsDepositExpired
ORDER BY wd.DepositGroup DESC,
         wd.IsDepositExpired ASC;