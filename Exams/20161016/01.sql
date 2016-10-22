USE AMS;
GO

CREATE TABLE Flights
(FlightID             INT PRIMARY KEY,
 DepartureTime        DATETIME NOT NULL,
 ArrivalTime          DATETIME NOT NULL,
 [Status]             VARCHAR(9),
 OriginAirportID      INT,
 DestinationAirportID INT,
 AirlineID            INT,
 CONSTRAINT chk_Status CHECK([Status] IN('Departing', 'Delayed', 'Arrived', 'Cancelled')),
 CONSTRAINT FK_Flights_From_Airports FOREIGN KEY(OriginAirportID) REFERENCES Airports(AirportID),
 CONSTRAINT FK_Flights_To_Airports FOREIGN KEY(DestinationAirportID) REFERENCES Airports(AirportID),
 CONSTRAINT FK_Flights_Airlines FOREIGN KEY(AirlineID) REFERENCES Airlines(AirlineID)
);

CREATE TABLE Tickets
(TicketID   INT PRIMARY KEY,
 Price      DECIMAL(8, 2) NOT NULL,
 Class      VARCHAR(6),
 Seat       VARCHAR(5),
 CustomerID INT,
 FlightID   INT,
 CONSTRAINT chk_Class CHECK(Class IN('First', 'Second', 'Third')),
 CONSTRAINT FK_Tickets_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),
 CONSTRAINT FK_Tickets_Flights FOREIGN KEY(FlightID) REFERENCES Flights(FlightID)
);