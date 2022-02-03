
CREATE TABLE  Customer(
	custId int PRIMARY KEY,
	custName varchar(50),
	custAge varchar(3),
	custAddress varchar (50),
	custEmail varchar (50),
	custPhoneNumber varchar (12)
)

insert into Customer
values(0, 'John Smith', 33, 'Utopia', 'John.Smith@gmail.com', '123-456-7890'),
	(1, 'Joe Doe', 42, 'Nowhere', 'JoeDoe@hotmail.com', '987-654-3210')

	
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
	storeName varchar(50),
	storeAddress varchar(50) PRIMARY KEY
)

insert into StoreFront 
values('Sprouts', '0000 Sprouts Lane'),
	('Target', '0001 Target Lane'),
	('Costco', '0002 Costco Lane')

	
CREATE TABLE  LineItem(
	itemName varchar(50) FOREIGN KEY REFERENCES Product(prodName),
	itemQuantity int,
	orderNumber int FOREIGN KEY REFERENCES Orders(orderNumber)
)

values('Pencil', '')


CREATE TABLE Orders(
	orderNumber int PRIMARY KEY not null,
	custId int FOREIGN KEY REFERENCES Customer(custId),
	storeAddress  varchar(50) FOREIGN KEY REFERENCES StoreFront (storeAddress)
)

CREATE TABLE Inventory(
	prodQuantitiy int,
	storeAddress varchar(50) FOREIGN KEY REFERENCES StoreFront(storeAddress),
	prodName varchar(50) FOREIGN KEY REFERENCES Product(prodName)
)

