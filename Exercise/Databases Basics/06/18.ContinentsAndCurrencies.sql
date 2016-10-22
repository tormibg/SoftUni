USE Geography;
GO

SELECT GrpConCur.ContinentCode,
       GrpCurrCode.CurrencyCode,
       GrpConCur.CurrencyUsage
FROM
(
    SELECT GrpCnt.ContinentCode,
           MAX(GrpCnt.CurrencyUsage) AS CurrencyUsage
    FROM
    (
        SELECT cn.ContinentCode,
               cn.CurrencyCode,
               COUNT(1) AS CurrencyUsage
        FROM Countries AS cn
        GROUP BY cn.ContinentCode,
                 cn.CurrencyCode
        HAVING COUNT(1) > 1
    ) AS GrpCnt
    GROUP BY GrpCnt.ContinentCode
) AS GrpConCur
INNER JOIN
(
    SELECT cn.CurrencyCode,
           cn.ContinentCode,
           COUNT(1) AS CurrencyUsage
    FROM Countries AS cn
    GROUP BY cn.ContinentCode,
             cn.CurrencyCode
    HAVING COUNT(1) > 1
) AS GrpCurrCode ON GrpConCur.ContinentCode + CONVERT( VARCHAR(10), GrpConCur.CurrencyUsage) = GrpCurrCode.ContinentCode + CONVERT(VARCHAR(10), GrpCurrCode.CurrencyUsage)
ORDER BY GrpConCur.ContinentCode;
-----------------------------------------------------------------------------------------------


SELECT c.ContinentCode,
       cc.CurrencyCode,
       COUNT(cc.COUNTryCode) AS CurrencyUsage
FROM Continents AS c
     JOIN Countries AS cc ON c.ContinentCode = cc.ContinentCode
GROUP BY c.ContinentCode,
         cc.CurrencyCode
HAVING COUNT(cc.CountryCode) =
(
    SELECT MAX(xxx.CurrencyXX)
    FROM
    (
        SELECT cx.ContinentCode,
               ccx.CurrencyCode,
               COUNT(ccx.COUNTryCode) AS CurrencyXX
        FROM Continents AS cx
             JOIN Countries AS ccx ON cx.ContinentCode = ccx.ContinentCode
        WHERE c.ContinentCode = cx.ContinentCode
        GROUP BY cx.ContinentCode,
                 ccx.CurrencyCode
    ) AS xxx
)
       AND COUNT(cc.CountryCode) > 1
ORDER BY c.ContinentCode;

-----------------------------------------------------------------------------------------------
SELECT sel.ContinentCode,
       sel.CurrencyCode AS CurrencyCode,
       sel.CurrencyUs AS CurrencyUsage
FROM
(
    SELECT c.ContinentCode,
           cr.CurrencyCode,
           COUNT(cr.Description) AS CurrencyUs,
           DENSE_RANK() OVER(PARTITION BY c.ContinentCode ORDER BY COUNT(cr.CurrencyCode) DESC) AS rankk
    FROM Currencies cr
         JOIN Countries c ON cr.CurrencyCode = c.CurrencyCode
    GROUP BY c.ContinentCode,
             cr.CurrencyCode
    HAVING COUNT(cr.Description) > 1
) AS sel
WHERE sel.rankk = 1
ORDER BY ContinentCode;