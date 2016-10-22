USE Gringotts;
GO

SELECT GroupAges.AgeGroup, COUNT(1)
FROM
(
	SELECT *, 'AgeGroup' = CASE
						   WHEN wd.Age BETWEEN 0 AND 10 THEN '[0-10]'
						   WHEN wd.Age BETWEEN 11 AND 20 THEN '[11-20]'
						   WHEN wd.Age BETWEEN 21 AND 30 THEN '[21-30]'
						   WHEN wd.Age BETWEEN 31 AND 40 THEN '[31-40]'
						   WHEN wd.Age BETWEEN 41 AND 50 THEN '[41-50]'
						   WHEN wd.Age BETWEEN 51 AND 60 THEN '[51-60]'
						   WHEN wd.Age > 60 THEN '[61+]'
						   END
	FROM WizzardDeposits AS wd
) AS GroupAges
GROUP BY GroupAges.AgeGroup;