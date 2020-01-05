
create database InquiryDB;
USE InquiryDB;

Create Table Logins(
loginId INT AUTO_INCREMENT PRIMARY KEY,
userId VARCHAR(100) NOT NULL,
password varchar(50) not null,
firstName VARCHAR(100) NOT NULL,
lastName VARCHAR(100) NOT NULL,
email VARCHAR(100) NOT NULL,
isActive boolean NOT NULL
);
Create Table Features(
featureId INT AUTO_INCREMENT PRIMARY KEY,
featureName VARCHAR(100) NOT NULL
);
Create Table Categories(
categoryId INT AUTO_INCREMENT PRIMARY KEY,
categoryName VARCHAR(100) NOT NULL,
  featureId INT,
    CONSTRAINT fk_feature
    FOREIGN KEY (featureId) 
        REFERENCES Features(featureId)
);
CREATE TABLE products(
    productId INT AUTO_INCREMENT PRIMARY KEY,
    productName varchar(100) not null,
    categoryId INT,
    CONSTRAINT fk_category
    FOREIGN KEY (categoryId) 
        REFERENCES categories(categoryId)
);
CREATE TABLE Inquiries(
    InquiryId INT AUTO_INCREMENT PRIMARY KEY,
    customerName varchar(100) not null,
    email VARCHAR(100) NOT NULL,
    phoneNumber VARCHAR(100) NOT NULL,
    address VARCHAR(100) NOT NULL,
    customerNotes VARCHAR(200) NOT NULL,
    attchments blob,
    updatedDate datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    productId INT,
    CONSTRAINT fk_product
    FOREIGN KEY (productId) 
        REFERENCES products(productId)
);


INSERT INTO `inquirydb`.`logins`
(`userId`,
`password`,
`firstName`,
`lastName`,
`email`,
`isActive`)
VALUES
(
"kb",
"kb",
"khushbu",
"patel",
"kb@gmail.com",
1);

INSERT INTO `inquirydb`.`features`
(`featureName`)
VALUES
("Feature 1");
INSERT INTO `inquirydb`.`categories`
(`categoryName`,
`featureId`)
VALUES
("Catgory 1",
1);

INSERT INTO `inquirydb`.`products`
(`productName`,
`categoryId`)
VALUES
("ProductName",
1);