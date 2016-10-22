USE OneToOne;
GO

CREATE TABLE Teachers
(TeacherID INT NOT NULL IDENTITY(101, 1)
                        PRIMARY KEY,
 Name      VARCHAR(30),
 ManagerID INT foreign key REFERENCES Teachers(TeacherID)
);

INSERT INTO Teachers( name, ManagerID )
VALUES( 'John', NULL), ( 'Maya', 106 ), ( 'Silvia', 106 ), ( 'Ted', 105 ), ( 'Mark', 101 ), ( 'Greta', 101 );