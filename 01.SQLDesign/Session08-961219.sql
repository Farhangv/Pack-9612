CREATE DATABASE Session08
GO
USE Session08
GO
CREATE TABLE Person
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	Family NVARCHAR(50) NOT NULL,
	NationalCode CHAR(10) NOT NULL UNIQUE
)
GO
CREATE TABLE Student
(
	Id INT PRIMARY KEY FOREIGN KEY REFERENCES Person(Id) ON DELETE CASCADE ON UPDATE CASCADE,
	CellPhone CHAR(11),
	FatherName NVARCHAR(50),
	CreatedDate DATETIME DEFAULT GETDATE(),
	RowGuid UNIQUEIDENTIFIER DEFAULT NEWID(),
	[RowVersion] TIMESTAMP,
	--UNIQUE(Name,Family,FatherName),
	--CONSTRAINT UQ_Name_Family_FatherName UNIQUE(Name,Family,FatherName)
)
GO
CREATE TABLE Teacher
(
	Id INT,
	Experience INT
)
GO
CREATE TABLE Course
(
	Id INT IDENTITY PRIMARY KEY,
	Title NVARCHAR(50),
	Duration INT,
	TeacherId INT
)
GO
CREATE TABLE Course_Student
(
	CourseId INT,
	StudentId INT,
	PRIMARY KEY(CourseId, StudentId),
	CONSTRAINT FK_CourseId FOREIGN KEY (CourseId) REFERENCES Course(Id) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT FK_StudentId FOREIGN KEY (StudentId) REFERENCES Student(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
)
GO
ALTER TABLE Course
ALTER COLUMN Title NVARCHAR(100)
GO
ALTER TABLE Course
ALTER COLUMN Title NVARCHAR(100) NOT NULL
GO
ALTER TABLE Course
ADD CONSTRAINT UQ_Title UNIQUE(Title)
GO
ALTER TABLE Student WITH NOCHECK
ADD CONSTRAINT  CHK_CellPhone CHECK(CellPhone LIKE '09_________')
GO
ALTER TABLE Teacher
ALTER COLUMN Id INT NOT NULL
GO
ALTER TABLE Teacher
ADD CONSTRAINT PK_Teacher_Id PRIMARY KEY(Id)
GO
ALTER TABLE Teacher
ADD CONSTRAINT FK_TeacherId_PersonId FOREIGN KEY(Id) REFERENCES Person(Id)
GO
CREATE VIEW VW_Student_Courses
AS
SELECT p.Name 'StudentName', p.Family 'StudentFamily', c.Title
FROM Person p
INNER JOIN Student s
ON p.Id = s.Id
INNER JOIN Course_Student cs
ON s.Id = cs.StudentId
INNER JOIN Course c
ON cs.CourseId = c.Id
GO
SELECT * FROM VW_Student_Courses
GO
CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY,
	FullName NVARCHAR(100),
	DepartmentName NVARCHAR(20)
)
GO
CREATE VIEW VW_Employee_Sales
AS
SELECT * FROM Employees
WHERE DepartmentName = N'فروش'
GO
CREATE VIEW VW_Employee_Production
AS
SELECT * FROM Employees
WHERE DepartmentName = N'تولید'
GO
CREATE VIEW VW_Employee_Education
AS
SELECT * FROM Employees
WHERE DepartmentName = N'آموزش'
GO
SELECT * FROM VW_Employee_Sales
GO
INSERT INTO VW_Employee_Sales(FullName, DepartmentName)
VALUES(N'حسن حسنی', N'فروش')
GO
INSERT INTO VW_Employee_Sales(FullName, DepartmentName)
VALUES(N'اکبر اکبری', N'تولید')
GO
SELECT * FROM VW_Employee_Production
GO
ALTER VIEW VW_Employee_Sales
AS
SELECT * FROM Employees
WHERE DepartmentName = N'فروش'
WITH CHECK OPTION
GO
ALTER VIEW VW_Employee_Production
AS
SELECT * FROM Employees
WHERE DepartmentName = N'تولید'
WITH CHECK OPTION
GO
ALTER VIEW VW_Employee_Education
AS
SELECT * FROM Employees
WHERE DepartmentName = N'آموزش'
WITH CHECK OPTION
GO
INSERT INTO VW_Employee_Sales(FullName, DepartmentName)
VALUES (N'فرشاد فرشادی', N'آموزش')
GO
SELECT * 
FROM INFORMATION_SCHEMA.COLUMNS
GO
SELECT *
FROM AdventureWorks.INFORMATION_SCHEMA.COLUMNS
WHERE COLUMN_NAME LIKE '%Name%'
GO
SELECT * FROM INFORMATION_SCHEMA.VIEWS
GO
ALTER VIEW VW_Employee_Sales
WITH ENCRYPTION
AS
SELECT * FROM Employees
WHERE DepartmentName = N'فروش'
WITH CHECK OPTION
GO
ALTER VIEW VW_Employee_Sales
WITH ENCRYPTION, SCHEMABINDING
AS
SELECT Id, FullName, DepartmentName FROM dbo.Employees
WHERE DepartmentName = N'فروش'
WITH CHECK OPTION
GO
ALTER TABLE Employees
ALTER COLUMN FullName NVARCHAR(200)
GO
USE AdventureWorks
GO
CREATE FUNCTION UDF_GetTotalSalesQtyByProductId
(
	@ProductId INT
)
RETURNS INT
AS
BEGIN
	DECLARE @Result INT
	SELECT @Result = ISNULL(SUM(OrderQty),0)
	FROM Sales.SalesOrderDetail
	WHERE ProductID = @ProductId
	--IF @Result IS NULL
	--BEGIN
	--	SET @Result = 0
	--END

	RETURN @Result
END
GO
SELECT dbo.UDF_GetTotalSalesQtyByProductId(777)
GO
SELECT ProductId, Name, Color, dbo.UDF_GetTotalSalesQtyByProductId(ProductId) 'SumQty'
FROM Production.Product
GO
CREATE FUNCTION UDF_GetYearDiff
(
	@Date DATETIME
)
RETURNS INT
AS
BEGIN
	DECLARE @Result INT
	SELECT @Result = YEAR(GETDATE()) - YEAR(@Date)
	RETURN @Result
END
GO
ALTER FUNCTION UDF_GetSalesPersonExperience
(
	@SalesPersonId INT
)
RETURNS INT
AS
BEGIN
	DECLARE @Result INT
	DECLARE @LatestInvoiceYear INT
	DECLARE @HireYear INT

	SELECT @HireYear = YEAR(HireDate)
	FROM HumanResources.Employee
	WHERE BusinessEntityID = @SalesPersonId

	SELECT @LatestInvoiceYear = YEAR(MAX(OrderDate))
	FROM Sales.SalesOrderHeader 
	WHERE SalesPersonID = @SalesPersonId

	SELECT @Result = @LatestInvoiceYear - @HireYear

	RETURN @Result
END
GO
SELECT DISTINCT SalesPersonId, dbo.UDF_GetSalesPersonExperience(SalesPersonId)
FROM Sales.SalesOrderHeader
GO
ALTER FUNCTION UDF_TotalSalesByDate
(
	@StartDate DATETIME,
	@EndDate DATETIME,
	@SalesPersonId INT
)
RETURNS INT
AS
BEGIN
	DECLARE @Result INT

	SELECT @Result = SUM(sd.OrderQty)
	FROM Sales.SalesOrderHeader sh 
	INNER JOIN Sales.SalesOrderDetail sd
	ON sh.SalesOrderID = sd.SalesOrderID 
	WHERE sh.SalesPersonID = @SalesPersonId AND
	sh.OrderDate BETWEEN @StartDate AND @EndDate

	RETURN @Result
END
GO
CREATE FUNCTION UDF_GetLastSalesPersonInvoiceDate
(
	@SalesPersonId INT
)
RETURNS DATETIME
AS
BEGIN
	DECLARE @Result DATETIME
	SELECT @Result = MAX(OrderDate)
	FROM Sales.SalesOrderHeader
	WHERE SalesPersonID = @SalesPersonId

	RETURN @Result
END
GO
SELECT s.BusinessEntityID, p.FirstName, p.LastName,
dbo.UDF_TotalSalesByDate(DATEADD(YEAR,-1,dbo.UDF_GetLastSalesPersonInvoiceDate(s.BusinessEntityID)),dbo.UDF_GetLastSalesPersonInvoiceDate(s.BusinessEntityID), s.BusinessEntityID),
dbo.UDF_TotalSalesByDate(DATEADD(YEAR,-2,dbo.UDF_GetLastSalesPersonInvoiceDate(s.BusinessEntityID)),DATEADD(YEAR,-1,dbo.UDF_GetLastSalesPersonInvoiceDate(s.BusinessEntityID)), s.BusinessEntityID),
dbo.UDF_TotalSalesByDate(DATEADD(YEAR,-3,dbo.UDF_GetLastSalesPersonInvoiceDate(s.BusinessEntityID)),DATEADD(YEAR,-2,dbo.UDF_GetLastSalesPersonInvoiceDate(s.BusinessEntityID)), s.BusinessEntityID)
FROM Sales.SalesPerson s
INNER JOIN Person.Person p
ON s.BusinessEntityID = p.BusinessEntityID
WHERE dbo.UDF_GetSalesPersonExperience(s.BusinessEntityID) = 3