USE OneToOne;
GO

CREATE TABLE Students
(StudentID INT NOT NULL IDENTITY(1, 1)
                        PRIMARY KEY,
 Name      VARCHAR(30)
);

CREATE TABLE Exams
(ExamID INT NOT NULL IDENTITY(101, 1)
                     PRIMARY KEY,
 Name   VARCHAR(30)
);

CREATE TABLE StudentsExams
(StudentID INT NOT NULL
               FOREIGN KEY REFERENCES dbo.Students(StudentID),
 ExamID    INT NOT NULL
               FOREIGN KEY REFERENCES dbo.Exams(ExamID)
               CONSTRAINT PK_StudentID_ExamID PRIMARY KEY(StudentID, ExamID)
);

INSERT INTO Students( Name )
VALUES( 'Mila' ), ( 'Toni' ), ( 'Ron' );

INSERT INTO Exams( Name )
VALUES( 'Spring MVC' ), ( 'Neo4j' ), ( 'Oracle 11g' );

INSERT INTO StudentsExams( StudentID, ExamID )
VALUES( 1, 101 ), ( 1, 102 ), ( 2, 101 ), ( 3, 103 ), ( 2, 102 ), ( 2, 103 );
