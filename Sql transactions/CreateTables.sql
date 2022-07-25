GO

CREATE TABLE tblOrder(
OrderId INT IDENTITY(1,1) PRIMARY KEY,
CustomerOrderID VARCHAR(20),
OriginAddress VARCHAR(500),
DestinationAddress VARCHAR(500),
MaterialQuantity INT,
QuantityUnit VARCHAR(20),
TotalWeight INT,
WeightUnit VARCHAR(20),
MaterialId VARCHAR(20),
OrderStatusId INT,
Note VARCHAR(500),
CreatedBy VARCHAR(50),
CreateDate DATETIME,
UpdatedBy VARCHAR(50),
UpdateDate DATETIME
)

GO

CREATE TABLE tblMaterial(
MaterialId VARCHAR(20) PRIMARY KEY,
MaterialName VARCHAR(50),
CreatedBy VARCHAR(50),
CreateDate DATETIME,
UpdatedBy VARCHAR(50),
UpdateDate DATETIME
)

GO

CREATE TABLE tblOrderStatusDescription(
OrderStatusId INT PRIMARY KEY IDENTITY(1,1),
OrderStatusDescription VARCHAR(50),
CreatedBy VARCHAR(50),
CreateDate DATETIME,
UpdatedBy VARCHAR(50),
UpdateDate DATETIME
)