
CREATE TABLE  Customer(
	custId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	custName varchar(50),
	custAge int,
	custAddress varchar (50),
	custEmail varchar (50),
	custPhoneNumber varchar (12)
	-- there is a many to many from cust to order
)


insert into Customer
values('John Smith', 33, 'Utopia', 'John.Smith@gmail.com', '123-456-7890'),
	('Joe Doe', 42, 'Nowhere', 'JoeDoe@hotmail.com', '987-654-3210')

alter table Customer
alter column custAge int 




	
	
CREATE TABLE Product(
	prodName varchar(50) PRIMARY KEY ,
	prodPrice int,
	prodDesc varchar (50),
	prodAgeRestriction int,
)

insert into Product 
values('Pencil', 1, 'Used to write', 0),
	('Paper', 1, 'Used to be written on', 0),
	('Mouse', 50, 'Computer mouse', 5)


CREATE TABLE  StoreFront(
	storeId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	storeName varchar(50),
	storeAddress varchar(50) 
) 


CREATE TABLE Inventory(
	inventoryId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	prodName varchar(50) FOREIGN KEY REFERENCES Product(prodName),
	prodQuantitiy int,
	storeId int FOREIGN KEY REFERENCES StoreFront(storeId)
)
alter table Inventory 
add storeId int FOREIGN KEY REFERENCES StoreFront(storeId)

insert into Inventory
values (5, 'Pencil', 1)


insert into StoreFront 
values('Sprouts', '0000 Sprouts Lane'),
	('Target', '0001 Target Lane'),
	('Costco', '0002 Costco Lane')

	
CREATE TABLE  LineItem(
	lineItemId int IDENTITY(1,1) PRIMARY KEY,
	itemName varchar(50) FOREIGN KEY REFERENCES Product(prodName),
	itemQuantity int
)

insert into LineItem
values(1, 'Pencil', 1, 10)

alter table LineItem 
add constraint lineItemId IDENTITY(1,1)

CREATE TABLE Orders(
	orderNumber int PRIMARY KEY not null,
	custId int FOREIGN KEY REFERENCES Customer(custId) 
	storeAddress int FOREIGN KEY REFERENCES StoreFront(storeName)
	lineItemId int FOREIGN KEY REFERENCES LineItem (lineItemId)
)
ALTER TABLE Orders
ADD lineItemId int FOREIGN KEY REFERENCES LineItem(lineItemId) 

CREATE TABLE ShopOrders(
	storeAddress varchar (50) FOREIGN KEY REFERENCES StoreFront(storeAddress),
	orderNumber int FOREIGN KEY REFERENCES Orders(orderNumber)
)


select * from Customer

-----------------------------------------------------------------------------------

SELECT *  FROM StoreFront sf 
INNER JOIN Inventory i ON i.storeId = sf.storeId 




