drop database payrollDB;
create database payrollDB;
USE payrollDB;

Create Table organizations(
organizationId int NOT NULL PRIMARY KEY,
organizationName VARCHAR(100) NOT NULL,
phone VARCHAR(50) NOT NULL,
email VARCHAR(100) NOT NULL,
password varchar(50) not null
);
Create Table organizationDetails(
organizationDetailId INT AUTO_INCREMENT PRIMARY KEY,
organizationId  int,
organizationname VARCHAR(100) NOT NULL,
organizationlogo blob,
contactperson VARCHAR(100) NOT NULL,
address VARCHAR(500) NOT NULL,
country VARCHAR(100) NOT NULL,
city VARCHAR(100) NOT NULL,
state VARCHAR(100) NOT NULL,
postalcode VARCHAR(100) NOT NULL,
email VARCHAR(100) NOT NULL,
phonenumber VARCHAR(100) NOT NULL,
mobilenumber VARCHAR(100) NOT NULL,
fax VARCHAR(100) NOT NULL,
websiteurl VARCHAR(100) NOT NULL,
CONSTRAINT fk_organizations
		FOREIGN KEY (organizationId) 
		REFERENCES organizations(organizationId)
);
Create Table Departments(
departmentId INT AUTO_INCREMENT PRIMARY KEY,
departmentName VARCHAR(100) NOT NULL
);
Create Table bankdetails(
bankId INT AUTO_INCREMENT PRIMARY KEY,
accountholdername VARCHAR(100) NOT NULL,
bankname VARCHAR(100) NOT NULL,
accountnumber VARCHAR(100) NOT NULL,
IFSCCode VARCHAR(100) NOT NULL,
accountType VARCHAR(100) NOT NULL
);
CREATE TABLE investmentDetails(
	investmentdetailId INT AUTO_INCREMENT PRIMARY KEY,
	year varchar(100) not null,
	deductionname VARCHAR(100) NOT NULL,
	deductionplan VARCHAR(100) NOT NULL,
    associatewith VARCHAR(100) NOT NULL,
	amount VARCHAR(100) NOT NULL,
	proofimage blob,
	isproofgiven boolean
);
Create Table employees(
employeeId INT AUTO_INCREMENT PRIMARY KEY,
employeeimage blob,
firstname VARCHAR(100) NOT NULL,
middlename VARCHAR(100) NOT NULL,
lastname VARCHAR(100) NOT NULL,
email VARCHAR(100) NOT NULL,
designation VARCHAR(100) NOT NULL,
gender VARCHAR(100) NOT NULL,
dateofjoining datetime NOT NULL,
departmentId INT,
dateofbirth datetime,
pannumber VARCHAR(100) NOT NULL,
personalemail VARCHAR(100) NOT NULL,
mobilenumber VARCHAR(100) NOT NULL,
address1 VARCHAR(500) NOT NULL,
address2 VARCHAR(500) NOT NULL,
country VARCHAR(100) NOT NULL,
city VARCHAR(100) NOT NULL,
state VARCHAR(100) NOT NULL,
postalcode VARCHAR(100) NOT NULL,
CONSTRAINT fk_Departments
		FOREIGN KEY (departmentId) 
		REFERENCES Departments(departmentId)
);
CREATE TABLE salaryTypes(
    salaryTypeId INT AUTO_INCREMENT PRIMARY KEY,   
    salaryTypeName decimal
);
CREATE TABLE salary(
    salaryId INT AUTO_INCREMENT PRIMARY KEY,   
    monthlyctc decimal,
    annualctc decimal,   
    fromdate  datetime, 
    salaryTypeId  int,
	hourlyrate decimal,
CONSTRAINT fk_salaryTypes
		FOREIGN KEY (salaryTypeId) 
		REFERENCES salaryTypes(salaryTypeId)
    
);
CREATE TABLE salaryrevisions(
    salaryrevisionId INT AUTO_INCREMENT PRIMARY KEY,   
    monthlyctc decimal,
    annualctc decimal,   
    fromdate  datetime, 
    todate datetime,
    salaryTypeId  int,
	hourlyrate decimal  ,
CONSTRAINT fk_salaryTypes1
		FOREIGN KEY (salaryTypeId) 
		REFERENCES salaryTypes(salaryTypeId)
);
CREATE TABLE financialyears(
    financialyearId INT AUTO_INCREMENT PRIMARY KEY,   
    financialyear VARCHAR(100) NOT NULL,
    fromdate datetime,
    todate datetime
);
CREATE TABLE financialyearTaxes(
	financialyearTaxeId INT AUTO_INCREMENT PRIMARY KEY,   
    financialyearId INT ,   
    fromrange VARCHAR(100) NOT NULL,
    torange VARCHAR(100) NOT NULL,
    percentage INT ,
CONSTRAINT fk_financialyears
		FOREIGN KEY (financialyearId) 
		REFERENCES financialyears(financialyearId)
);
CREATE TABLE holidays(
    holidayId INT AUTO_INCREMENT PRIMARY KEY,   
    holidayname VARCHAR(100) NOT NULL,
    date datetime
);
create table salaryperiods(
salaryperiodId INT AUTO_INCREMENT PRIMARY KEY,
salaryperiodName varchar(100)
);
create table salaryaction(
salaryactionId INT AUTO_INCREMENT PRIMARY KEY,
employeeId int,
isPaused boolean,
CONSTRAINT fk_employees
		FOREIGN KEY (employeeId) 
		REFERENCES employees(employeeId)
);
create table componentsections(
componentsectionId INT AUTO_INCREMENT PRIMARY KEY,
componentsectionName varchar(100)
);
create table calculationmethods(
methodId INT AUTO_INCREMENT PRIMARY KEY,
methodName varchar(100)
);
create table components(
componentId INT AUTO_INCREMENT PRIMARY KEY,
componentName varchar(100),
componentsectionId int,
methodId int,
CONSTRAINT fk_componentsections
		FOREIGN KEY (componentsectionId) 
		REFERENCES componentsections(componentsectionId),
CONSTRAINT fk_calculationmethods
		FOREIGN KEY (methodId) 
		REFERENCES calculationmethods(methodId)

);
create table fixedamount(
fixedamountId INT AUTO_INCREMENT PRIMARY KEY,
componentId int,
fixedamount decimal,
CONSTRAINT fk_components
		FOREIGN KEY (componentId) 
		REFERENCES components(componentId)
);
create table percentageamount(
percentageamountId INT AUTO_INCREMENT PRIMARY KEY,
componentId int,
rate decimal,
CONSTRAINT fk_componentpercentage
		FOREIGN KEY (componentId) 
		REFERENCES components(componentId)
);
create table slabamount(
slabamountId INT AUTO_INCREMENT PRIMARY KEY,
componentId int,
minrange decimal,
maxrange decimal,
amount decimal,
CONSTRAINT fk_componentslab
		FOREIGN KEY (componentId) 
		REFERENCES components(componentId)
);
create table summation(
summationId INT AUTO_INCREMENT PRIMARY KEY,
componentId int,
CONSTRAINT fk_componentsummation
		FOREIGN KEY (componentId) 
		REFERENCES components(componentId)
);
create table minus(
minusId INT AUTO_INCREMENT PRIMARY KEY,
firstcomponentId int,
secondcomponentId int,
CONSTRAINT fk_firstcomponents
		FOREIGN KEY (firstcomponentId) 
		REFERENCES components(componentId),        
CONSTRAINT fk_secondcomponents
		FOREIGN KEY (secondcomponentId) 
		REFERENCES components(componentId)
);