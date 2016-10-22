USE Gringotts;
GO

SELECT LEFT(wd.FirstName, 1) AS first_letter
FROM WizzardDeposits AS wd
WHERE wd.DepositGroup = 'Troll Chest'
GROUP BY LEFT(wd.FirstName, 1)
ORDER BY first_letter ASC;