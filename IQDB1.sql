
create database InquiryDetailsDB;
USE InquiryDetailsDB;

Create Table Users(
userId int NOT NULL PRIMARY KEY,
password varchar(50) not null,
firstName VARCHAR(100) NOT NULL,
lastName VARCHAR(100) NOT NULL,
address VARCHAR(200) NOT NULL,
contactNumber VARCHAR(50) NOT NULL,
email VARCHAR(100) NOT NULL
);
Create Table Features(
featureId INT AUTO_INCREMENT PRIMARY KEY,
featureName VARCHAR(100) NOT NULL
);

Create Table Categories(
categoryId INT AUTO_INCREMENT PRIMARY KEY,
categoryName VARCHAR(100) NOT NULL,
createdBy VARCHAR(100) NOT NULL,
createdDate datetime DEFAULT CURRENT_TIMESTAMP,
modifiedBy VARCHAR(100) NOT NULL,
modifiedDate datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
CREATE TABLE products(
	productId INT AUTO_INCREMENT PRIMARY KEY,
	productName varchar(100) not null,
	features VARCHAR(100) NOT NULL,
	ProductDescription VARCHAR(100) NOT NULL,
	Price int,
	qty int,
	IsActive boolean,
	createdBy VARCHAR(100) NOT NULL,
	createdDate datetime DEFAULT CURRENT_TIMESTAMP,
	modifiedBy VARCHAR(100) NOT NULL,
	modifiedDate datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    userId int,
    categoryId int,
	CONSTRAINT fk_users
		FOREIGN KEY (userId) 
		REFERENCES users(userId),
	CONSTRAINT fk_category
		FOREIGN KEY (categoryId) 
		REFERENCES categories(categoryId)
);
CREATE TABLE Inquiries(
    InquiryId INT AUTO_INCREMENT PRIMARY KEY,   
    customerNotes VARCHAR(200) NOT NULL,
    attchments blob,   
    nextfllowupDate  datetime, 
    createdBy VARCHAR(100) NOT NULL,
	createdDate datetime DEFAULT CURRENT_TIMESTAMP,
	modifiedBy VARCHAR(100) NOT NULL,
	modifiedDate datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    productId INT,
    CONSTRAINT fk_product
    FOREIGN KEY (productId) 
        REFERENCES products(productId)
);





