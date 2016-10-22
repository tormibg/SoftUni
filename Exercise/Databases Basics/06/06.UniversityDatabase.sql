CREATE DATABASE University;
GO

USE University;
GO

CREATE TABLE Majors
(MajorID INT NOT NULL IDENTITY(1, 1)
                      PRIMARY KEY,
 Name    VARCHAR(50),
);

CREATE TABLE Students
(StudentID     INT NOT NULL IDENTITY(1, 1)
                            PRIMARY KEY,
 StudentNumber VARCHAR(50),
 StudentName   VARCHAR(50),
 MajorID       INT NOT NULL
                   FOREIGN KEY REFERENCES Majors(MajorID)
);

CREATE TABLE Payments
(PaymentID     INT NOT NULL IDENTITY(1, 1)
                            PRIMARY KEY,
 PaymentDate   DATE,
 PaymentAmount DECIMAL(13, 2),
 StudentID     INT FOREIGN KEY REFERENCES Students(StudentID)
);

CREATE TABLE Subjects
(SubjectID   INT NOT NULL IDENTITY(1, 1)
                          PRIMARY KEY,
 SubjectName VARCHAR(50)
);

CREATE TABLE Agenda
(StudentID INT NOT NULL
               FOREIGN KEY REFERENCES Students(StudentID),
 SubjectID INT NOT NULL
               FOREIGN KEY REFERENCES Subjects(SubjectID),
 CONSTRAINT PK_StudentID_SubjectID PRIMARY KEY(StudentID, SubjectID)
);