USE Geography;
GO

CREATE TABLE Monasteries
(Id          INT NOT NULL IDENTITY
                          PRIMARY KEY,
 Name        NVARCHAR(MAX) NOT NULL,
 CountryCode CHAR(2),
 CONSTRAINT FK_Monasteries_Countries FOREIGN KEY(CountryCode) REFERENCES dbo.Countries(CountryCode)
);

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')


ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL
                  CONSTRAINT [Default] DEFAULT 0;

UPDATE Countries
  SET
      IsDeleted = 1
WHERE CountryCode IN
(
    SELECT c.CountryCode
    FROM Countries AS c
         JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
         JOIN Rivers AS r ON r.Id = cr.RiverId
    GROUP BY c.CountryCode
    HAVING COUNT(r.Id) > 3
);

SELECT m.Name AS Monastery,
       c.CountryName AS Country
FROM Monasteries AS m
     LEFT JOIN Countries AS c ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted != 1
ORDER BY Monastery;