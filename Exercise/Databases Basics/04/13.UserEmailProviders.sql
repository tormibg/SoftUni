USE Diablo;
GO
SELECT u.Username,
       RIGHT(u.Email, LEN(u.Email)-CHARINDEX('@', u.Email)) AS 'Email Provider'
FROM Users AS u
ORDER BY 'Email Provider' ASC,
         u.Username ASC;