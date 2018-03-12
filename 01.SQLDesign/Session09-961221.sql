USE AdventureWorks
GO
CREATE FUNCTION UDF_GetProductsByCategoryName
(
	@CategoryName NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN--بر اساس نام دسته بندی لیست محصولات دسته بندی را تولید میکنیم
	SELECT ProductId, p.[Name], Color, ListPrice, StandardCost
	FROM Production.Product p
	INNER JOIN Production.ProductSubcategory ps 
	ON p.ProductSubcategoryID = ps.ProductSubcategoryID
	INNER JOIN Production.ProductCategory pc
	ON ps.ProductCategoryID = pc.ProductCategoryID
	WHERE pc.Name LIKE '%' + @CategoryName + '%'
GO
SELECT * 
FROM UDF_GetProductsByCategoryName('Bike')
GO
SELECT * 
FROM Production.ProductCategory
GO
SELECT * 
FROM UDF_GetProductsByCategoryName('Comp')
GO
CREATE FUNCTION UDF_GetProductsBySalesQtyRange
(
	@Min INT,
	@Max INT
)
RETURNS TABLE
AS
RETURN
	SELECT p.ProductId, Name, Color, StandardCost, ListPrice, SUM(s.OrderQty) 'SumQty'
	FROM Production.Product p
	INNER JOIN Sales.SalesOrderDetail s
	ON p.ProductID = s.ProductID
	GROUP BY p.ProductId, Name, Color, StandardCost, ListPrice
	HAVING SUM(OrderQty) BETWEEN @Min AND @Max
GO
SELECT * 
FROM UDF_GetProductsBySalesQtyRange(1000,2000)
ORDER BY SumQty DESC
GO
SELECT DISTINCT
ProductId, UnitPrice, YEAR(ModifiedDate)
FROM Sales.SalesOrderDetail
WHERE ProductID = 777
--تابعی بنویسید که
GO--افزایش قیمت فروش هر محصول را از اولین سال فروش تا آخرین فروش به درصد بیان کند
--این تابع یک پارامتر کمترین درصد افزایش دریافت کن و محصولاتی که بیش از آن افزایش فروش داشته اند را فیلتر کند
ALTER FUNCTION UDF_GetProductsByPriceGrowth
(
	@MinGrowth INT
)
RETURNS @Result TABLE 
(
	ProductId INT,
	ProductName NVARCHAR(100),
	StartYear INT,
	EndYear INT,
	Growth NVARCHAR(10)
)
AS
BEGIN

	WITH Q
	AS
	(
		SELECT os.ProductId, YEAR(MIN(os.ModifiedDate)) 'MinYear', 
		(
		SELECT TOP 1 UnitPrice
		FROM Sales.SalesOrderDetail s
		WHERE s.ProductID = os.ProductID 
		AND s.ModifiedDate = MIN(os.ModifiedDate)
		) 'MinYearPrice', 

		YEAR(MAX(ModifiedDate)) 'MaxYear',
		(
		SELECT TOP 1 UnitPrice
		FROM Sales.SalesOrderDetail s
		WHERE s.ProductID = os.ProductID 
		AND s.ModifiedDate = MAX(os.ModifiedDate)
		) 'MaxYearPrice'
		FROM Sales.SalesOrderDetail os
		GROUP BY ProductId
	)

	INSERT INTO @Result
	SELECT Q.ProductID, p.Name, MinYear, MaxYear, 
	CONVERT(NVARCHAR(6),(((MaxYearPrice - MinYearPrice)/ MinYearPrice) * 100)) + '%' 'Growth'
	FROM Q
	INNER JOIN Production.Product p 
	ON Q.ProductID = p.ProductID

	WHERE (((MaxYearPrice - MinYearPrice)/ MinYearPrice) * 100) >= @MinGrowth

	RETURN
END
GO
SELECT CONVERT(NVARCHAR(10), 10)
GO
SELECT *
FROM UDF_GetProductsByPriceGrowth(100)
GO
SELECT ProductName, Growth
FROM UDF_GetProductsByPriceGrowth(100)
GO
CREATE DATABASE Session09
GO
USE Session09
GO
CREATE TABLE [User]
(
	Id INT IDENTITY PRIMARY KEY,
	FullName NVARCHAR(50),
	Username NVARCHAR(50),
	PasswordHash NVARCHAR(100)
)
GO

INSERT INTO [User] VALUES('Joey Tribianni', 'jt', '123')
GO
SELECT * FROM [User]
GO
INSERT INTO [User] VALUES('Ross Geller', 'rg', HASHBYTES('md5', '123'))
GO
CREATE PROC USP_UserInsert
(
	@FullName NVARCHAR(50),
	@Username NVARCHAR(50),
	@Password NVARCHAR(50)
)
AS
BEGIN
	INSERT INTO [User]
	VALUES (@FullName,@Username,HASHBYTES('md5',@Password))
END
GO
EXEC USP_UserInsert 'Monica Geller' , 'mg', '123'
GO
SELECT * FROM [User]
