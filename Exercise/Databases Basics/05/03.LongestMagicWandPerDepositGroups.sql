USE Gringotts;
GO
SELECT w.DepositGroup AS 'DepositGroup',
       MAX(w.MagicWandSize) AS 'LongestMagicWand'
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup;