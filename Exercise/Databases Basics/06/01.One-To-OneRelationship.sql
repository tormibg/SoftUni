--OneToOne;
--GO


USE OneToOne;
GO

CREATE TABLE Passports
(PassportID     INT NOT NULL IDENTITY(1, 1)
                             PRIMARY KEY,
 PassportNumber VARCHAR(8)
);

CREATE TABLE Persons
(PersonID   INT NOT NULL IDENTITY(1, 1)
                         PRIMARY KEY,
 FirstName  VARCHAR(30),
 Salary     DECIMAL(13, 2),
 PassportID INT NOT NULL UNIQUE
                FOREIGN KEY REFERENCES dbo.Passports(PassportID)
);