USE Gringotts;
GO
SELECT wd.DepositGroup,
       SUM(wd.DepositAmount)
FROM WizzardDeposits AS wd
WHERE wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup;