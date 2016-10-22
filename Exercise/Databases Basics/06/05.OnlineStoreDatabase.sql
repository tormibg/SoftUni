USE OneToOne;
GO

CREATE TABLE Cities
(CityID INT NOT NULL IDENTITY(1, 1)
                     PRIMARY KEY,
 Name   VARCHAR(50),
);

CREATE TABLE Customers
(CustomerID INT NOT NULL IDENTITY(1, 1)
                         PRIMARY KEY,
 Name       VARCHAR(50),
 Birthday   DATE,
 CityID     INT NOT NULL
                FOREIGN KEY REFERENCES Cities(CityID)
);

CREATE TABLE Orders
(OrderID    INT NOT NULL IDENTITY(1, 1)
                         PRIMARY KEY,
 CustomerID INT NOT NULL
                FOREIGN KEY REFERENCES Customers(CustomerID)
);

CREATE TABLE ItemTypes
(ItemTypeID INT NOT NULL IDENTITY(1, 1)
                         PRIMARY KEY,
 Name       VARCHAR(50)
);

CREATE TABLE Items
(ItemID     INT NOT NULL IDENTITY(1, 1)
                         PRIMARY KEY,
 Name       VARCHAR(50),
 ItemTypeID INT NOT NULL
                FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
);

CREATE TABLE OrderItems
(OrderID INT NOT NULL
             FOREIGN KEY REFERENCES Orders(OrderID),
 ItemID INT NOT NULL
             FOREIGN KEY REFERENCES Items(ItemID),
 CONSTRAINT PK_OrderID_ItemsID PRIMARY KEY(OrderID, ItemID)
);