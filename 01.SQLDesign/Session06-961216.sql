CREATE DATABASE Session06
GO
USE Session06
GO
CREATE TABLE Student
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50),
	Family NVARCHAR(50),
	EducationalYear INT DEFAULT YEAR(GETDATE()),
	Age TINYINT
)
GO
INSERT INTO Student(Name, Family, EducationalYear, Age)
VALUES (N'رضا', N'رضایی', 2013, 20),
	   (N'پیام', N'پیامکی', 2010, 21)
GO
SELECT * FROM Student
GO
INSERT INTO Student(Name, Family, Age)
VALUES (N'رضا', N'رضایی', 20),
	   (N'پیام', N'پیامکی', 21)
GO
INSERT INTO Student(Name, Family)
VALUES (N'رضا', N'رضایی'),
	   (N'پیام', N'پیامکی')
GO
DROP TABLE Student
GO
CREATE TABLE Student
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	Family NVARCHAR(50) NOT NULL,
	EducationalYear INT DEFAULT YEAR(GETDATE()),
	Age TINYINT
)
GO
INSERT INTO Student(Name)
VALUES (N'رضا'),
	   (N'پیام')
GO
INSERT INTO Student
VALUES (N'رضا', N'رضایی', 2017, NULL),
	   (N'پیام', N'پیامکی',2013, 10)
GO
INSERT INTO Student(Name, Family, EducationalYear, Age)
--VALUES
SELECT p.FirstName, p.LastName, YEAR(e.HireDate), YEAR(GETDATE()) - YEAR(e.BirthDate)
FROM AdventureWorks.Person.Person p
INNER JOIN AdventureWorks.HumanResources.Employee e
ON p.BusinessEntityID = e.BusinessEntityID
GO
SELECT * FROM Student
GO
SELECT p.ProductId, p.Name, p.Color, ISNULL(SUM(s.OrderQty),0) 'SumQty'
INTO Product
FROM AdventureWorks.Production.Product p
LEFT OUTER JOIN AdventureWorks.Sales.SalesOrderDetail s
ON p.ProductID = s.ProductID
GROUP BY p.ProductId, p.Name, p.Color
GO
SELECT * FROM Product
GO
UPDATE Student SET Name = N'مریم', 
				   Family = N'مریمی',
				   EducationalYear = 2002
WHERE Id = 2
GO
UPDATE Student SET EducationalYear = 2012
WHERE Id BETWEEN 10 AND 20
GO
UPDATE Student SET EducationalYear = 1990
--WHERE Id = 2
GO
DELETE FROM Student
WHERE Id < 10
GO
SELECT * FROM Student
GO
DELETE FROM Student
GO
SELECT * 
INTO InvoiceRow
FROM AdventureWorks.Sales.SalesOrderDetail
GO
SELECT * FROM InvoiceRow
GO
DELETE FROM InvoiceRow
GO
DROP TABLE InvoiceRow
GO
SELECT * 
INTO InvoiceRow
FROM AdventureWorks.Sales.SalesOrderDetail
GO
TRUNCATE TABLE InvoiceRow
GO
SELECT * FROm Student
GO
TRUNCATE TABLE Student
GO
USE Session06
GO
USE master
GO
SELECT * FROM INFORMATION_SCHEMA.VIEWS
GO
SELECT * FROM INFORMATION_SCHEMA.COLUMNS
GO
CREATE DATABASE Session062
ON -- MDF
(
	NAME = 'Session062_Data', --نام منطقی فایل مورد نظر - سرویس اس کیو ال این فایل را با این نام خواهد شناخت
	FILENAME = 'C:\DBFiles\Session062_Data.mdf',--آدرس فیزیکی فایل در فایل سیستم
	SIZE = 10 MB, -- سایز اولیه
	MAXSIZE = UNLIMITED, -- حداکثر سایز
	FILEGROWTH = 10 MB -- میزا افزایش در هر مرحله
)
LOG ON -- LDF
(
	NAME = 'Session062_Log', --نام منطقی فایل مورد نظر - سرویس اس کیو ال این فایل را با این نام خواهد شناخت
	FILENAME = 'C:\DBFiles\Session062_Log.ldf',--آدرس فیزیکی فایل در فایل سیستم
	SIZE = 10 MB, -- سایز اولیه
	MAXSIZE = UNLIMITED, -- حداکثر سایز
	FILEGROWTH = 10 % -- میزا افزایش در هر مرحله
)
GO
USE Session062
GO
CREATE TABLE Student
(
	Id INT IDENTITY(10, 5),-- PRIMARY KEY,
	Name NVARCHAR(50),
	Family NVARCHAR(50),
	NationalCode NVARCHAR(50),
	PersianBirthDate NVARCHAR(10),
	CellPhone NVARCHAR(11),
	PRIMARY KEY(Id)
)
GO
DROP TABLE Student
GO
CREATE TABLE Student
(
	Id INT IDENTITY(10, 5),-- PRIMARY KEY,
	Name NVARCHAR(50),
	Family NVARCHAR(50),
	NationalCode NVARCHAR(50),
	PersianBirthDate NVARCHAR(10),
	CellPhone NVARCHAR(11),
	--PRIMARY KEY(Id)
	CONSTRAINT PK_Student PRIMARY KEY (Id)
)

