﻿CREATE TABLE Category
(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	CategoryName VARCHAR(200) NOT NULL
)

CREATE TABLE Attribute
(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	AttributeName VARCHAR(30) NOT NULL
)

CREATE TABLE GameItem
(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	ItemCode VARCHAR(100) NOT NULL,
	ItemName VARCHAR(200) NOT NULL,
	ItemCategoryID INT NOT NULL REFERENCES Category(ID), 
	ItemDescription VARCHAR(MAX) NULL,
	ItemGivenAttributeID INT REFERENCES  Attribute(ID),
	ItemGivenAttributeQuantity INT,
	ItemImage VARBINARY(MAX),
	ItemPrice INT NOT NULL
)

