USE Gringotts;
GO

SELECT GroupWithSize.DepositGroup
FROM
(
	SELECT wd.DepositGroup, AVG(wd.MagicWandSize) AS 'AvgSize'
	FROM WizzardDeposits AS wd
	GROUP BY wd.DepositGroup
) AS GroupWithSize
JOIN
(
	SELECT MIN(AvgMagicWandSize.AvgSize) AS 'MinSize'
	FROM
	(
		SELECT w.DepositGroup, AVG(w.MagicWandSize) AS 'AvgSize'
		FROM WizzardDeposits AS w
		GROUP BY w.DepositGroup
	) AS AvgMagicWandSize
) AS MinSize
ON GroupWithSize.AvgSize = MinSize.MinSize;