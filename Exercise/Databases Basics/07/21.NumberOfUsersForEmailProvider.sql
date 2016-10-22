USE Diablo;
GO

SELECT SUBSTRING(u.Email, CHARINDEX('@', u.Email)+1, LEN(u.email)) AS 'Email Provider',
       COUNT(1) AS 'Number Of Users'
FROM Users AS u
GROUP BY SUBSTRING(u.Email, CHARINDEX('@', u.Email)+1, LEN(u.email))
ORDER BY [Number Of Users] DESC,
         [Email Provider] ASC;