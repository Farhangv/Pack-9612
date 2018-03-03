USE AdventureWorks
------------------
SELECT NTILE(5) OVER (PARTITION BY Color ORDER BY ProductID) 'NTILE',ProductId, Name,Color
FROM Production.Product
------------------
SELECT ProductId, SUM(OrderQty) OVER (PARTITION BY ProductId) 'SumQty'
FROM Sales.SalesOrderDetail
------------------
SELECT ProductId, Name, Color
FROM Production.Product 
WHERE ProductID IN 
(
	SELECT ProductId
	FROM Sales.SalesOrderDetail
)
------------------
SELECT ProductId, Name, Color
FROM Production.Product 
WHERE StandardCost = 
(
	SELECT MAX(StandardCost)
	FROM Production.Product
)
------------------
SELECT ProductId, Name, Color
FROM Production.Product 
WHERE StandardCost = MAX(StandardCost)
-------------------
SELECT ProductId, Name, Color
FROM Production.Product 
WHERE StandardCost IN
(
	SELECT MAX(StandardCost)
	FROM Production.Product
)
--------------------(1)
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
WHERE ProductID IN
(
SELECT TOP 10 ProductId
FROM Sales.SalesOrderDetail
GROUP BY ProductID
ORDER BY SUM(OrderQty) DESC
)
---------------------
SELECT ProductId, 
(
	SELECT Name 
	FROM Production.Product p
	WHERE s.ProductID = p.ProductID
) 'ProductName', 
OrderQty, UnitPrice, LineTotal 
FROM Sales.SalesOrderDetail s
WHERE s.SalesOrderID = 65345
---------------------
SELECT AVG(SumQty) QtyAverage
FROM 
(
SELECT ProductId, SUM(OrderQty) 'SumQty'
FROM Sales.SalesOrderDetail
GROUP BY ProductId
) s
-----------------
SELECT AVG(OrderQty)
FROM Sales.SalesOrderDetail
-----------------
;
WITH MyQuery
AS
(
SELECT ProductId, SUM(OrderQty) 'SumQty'
FROM Sales.SalesOrderDetail
GROUP BY ProductId
)
SELECT AVG(SumQty)
FROM MyQuery
;
DECLARE @PageNumber INT
DECLARE @RowsPerPage INT
SET @PageNumber = 2
SET @RowsPerPage = 20
SELECT Row, ProductId, Name, Color
FROM (
SELECT ROW_NUMBER() OVER (ORDER BY Name) 'Row', ProductId, Name, Color
FROM Production.Product
) s
WHERE Row BETWEEN ((@PageNumber - 1) * @RowsPerPage + 1) AND (@PageNumber * @RowsPerPage)
---------------------
SELECT s.ProductId, Name, Color, OrderQty, UnitPrice, StandardCost, LineTotal,
UnitPriceDiscount,
(UnitPriceDiscount * UnitPrice * OrderQty) Discount,
(LineTotal - (OrderQty * StandardCost)) 'Benefit'
FROM Production.Product p
INNER JOIN Sales.SalesOrderDetail s
ON p.ProductID = s.ProductID
--------------------
SELECT ProductId, p.Name, p.ProductSubCategoryId , ps.Name
FROM Production.Product p
INNER JOIN Production.ProductSubcategory ps
ON p.ProductSubcategoryID = ps.ProductSubcategoryID
--------------------
SELECT * FROM Production.ProductSubcategory
--------------------
SELECT * FROM Production.ProductCategory
--------------------
SELECT * FROM Production.Product
--------------------
SELECT ProductId, p.Name 'ProductName', ISNULL(p.ProductSubCategoryId, 0) 'SubCatId' , 
ISNULL(ps.Name, 'NoSubCatDefined') 'SubCategoryName'
FROM Production.Product p
LEFT OUTER JOIN Production.ProductSubcategory ps
ON p.ProductSubcategoryID = ps.ProductSubcategoryID
--------------------
SELECT ProductId, p.Name 'ProductName', ISNULL(ps.ProductSubCategoryId, 0) 'SubCatId' , 
ISNULL(ps.Name, 'NoSubCatDefined') 'SubCategoryName'
FROM Production.Product p
RIGHT OUTER JOIN Production.ProductSubcategory ps
ON p.ProductSubcategoryID = ps.ProductSubcategoryID
--------------------
SELECT ProductId, p.Name 'ProductName', ISNULL(ps.ProductSubCategoryId, 0) 'SubCatId' , 
ISNULL(ps.Name, 'NoSubCatDefined') 'SubCategoryName'
FROM Production.Product p
FULL OUTER JOIN Production.ProductSubcategory ps
ON p.ProductSubcategoryID = ps.ProductSubcategoryID

----------------------
SELECT ProductId, p.Name 'ProductName', ps.Name 'SubCatName', pc.Name 'CatName'
FROM Production.Product p
INNER JOIN Production.ProductSubcategory ps
ON p.ProductSubcategoryID = ps.ProductSubcategoryID
INNER JOIN Production.ProductCategory pc
ON ps.ProductCategoryID = pc.ProductCategoryID
----------------------
SELECT ProductId, p.Name 'ProductName', ps.Name 'SubCatName', pc.Name 'CatName'
FROM Production.Product p
LEFT OUTER JOIN Production.ProductSubcategory ps
ON p.ProductSubcategoryID = ps.ProductSubcategoryID
RIGHT OUTER JOIN Production.ProductCategory pc
ON ps.ProductCategoryID = pc.ProductCategoryID
----------------------
SELECT ProductId, p.Name 'ProductName', ps.Name 'SubCatName', pc.Name 'CatName'
FROM Production.Product p
FULL OUTER JOIN Production.ProductSubcategory ps
ON p.ProductSubcategoryID = ps.ProductSubcategoryID
FULL OUTER JOIN Production.ProductCategory pc
ON ps.ProductCategoryID = pc.ProductCategoryID
----------------------
SELECT c.Name, SUM(s.OrderQty) 'SumQty'
FROM Production.ProductCategory c
INNER JOIN Production.ProductSubcategory ps
ON c.ProductCategoryID = ps.ProductCategoryID
INNER JOIN Production.Product p
ON ps.ProductSubcategoryID = p.ProductSubcategoryID
INNER JOIN Sales.SalesOrderDetail s
ON p.ProductID = s.ProductID
GROUP BY c.Name
ORDER BY SumQty DESC
--------------------
SELECT c.Name 'CatName', ps.Name 'SubCatName', SUM(s.OrderQty) 'SumQty'
FROM Production.ProductCategory c
INNER JOIN Production.ProductSubcategory ps
ON c.ProductCategoryID = ps.ProductCategoryID
INNER JOIN Production.Product p
ON ps.ProductSubcategoryID = p.ProductSubcategoryID
INNER JOIN Sales.SalesOrderDetail s
ON p.ProductID = s.ProductID
GROUP BY c.Name, ps.Name
ORDER BY SumQty DESC
-----------------
SELECT c.Name 'CatName', ps.Name 'SubCatName', p.Name 'ProductName' , SUM(s.OrderQty) 'SumQty'
FROM Production.ProductCategory c
INNER JOIN Production.ProductSubcategory ps
ON c.ProductCategoryID = ps.ProductCategoryID
INNER JOIN Production.Product p
ON ps.ProductSubcategoryID = p.ProductSubcategoryID
INNER JOIN Sales.SalesOrderDetail s
ON p.ProductID = s.ProductID
GROUP BY c.Name, ps.Name, p.Name
ORDER BY SumQty DESC
-------------------
SELECT JobTitle, COUNT(*)
FROM HumanResources.Employee
GROUP BY JobTitle
--------------------
