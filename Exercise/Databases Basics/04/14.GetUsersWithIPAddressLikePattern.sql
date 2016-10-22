USE Diablo;
GO
SELECT u.Username,
       u.IpAddress
FROM Users AS u
WHERE u.IpAddress LIKE '___.1_%._%.___'
ORDER BY u.Username ASC;