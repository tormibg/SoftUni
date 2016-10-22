USE Gringotts;
GO

SELECT MAX(w.MagicWandSize) AS 'LongestMagicWand'
FROM WizzardDeposits AS w;