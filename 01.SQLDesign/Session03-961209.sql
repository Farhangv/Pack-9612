USE AdventureWorks
--------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
ORDER BY Name ASC
OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
--------------
DECLARE @PageNumber INT
DECLARE @RowsPerPage INT
SET @PageNumber = 3
SET @RowsPerPage = 10

SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
ORDER BY Name ASC
OFFSET ((@PageNumber - 1)* @RowsPerPage) ROWS FETCH NEXT @RowsPerPage ROWS ONLY
------------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
WHERE Color = 'Blue'
------------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
WHERE ProductId >= 800
------------------
------------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
WHERE ProductId >= 800 AND ProductID <= 805
------------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
WHERE ProductId >= 800 AND ProductID <= 805 AND Color = 'Yellow'
------------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
WHERE ProductId >= 800 AND ProductID <= 805 AND Color IS NULL
------------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
WHERE ProductId >= 800 AND ProductID <= 805 AND Color IS NOT NULL
------------------
------------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
WHERE Color = 'Red' OR Color = 'Blue'
------------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
WHERE Color IN
(
	'Red', 'Blue', 'Yellow'
) 
OR Color IS NULL
------------------
SELECT Name, Color, StandardCost
FROM Production.Product
WHERE ProductId IN
(
	SELECT ProductId
	FROM Sales.SalesOrderDetail
) 
OR Color IN
(
	'Blue', 'Red'
)
------------------
SELECT Name, Color, StandardCost
FROM Production.Product
WHERE ProductId IN
(
	SELECT ProductId
	FROM Sales.SalesOrderDetail
	WHERE OrderQty >= 5
) 
ORDER BY Name
------------------
SELECT Name, Color, StandardCost
FROM Production.Product
--WHERE Name LIKE 'a%'
--WHERE Name LIKE 'b%'
--WHERE Name LIKE '%b%'
--WHERE Name LIKE '%Mountain%'
--WHERE Name LIKE '_a%'
--WHERE Name LIKE '%'
--WHERE Name LIKE '_a%'
WHERE Name LIKE '%&_%' ESCAPE '&'
ORDER BY Name
-----------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
WHERE ProductId BETWEEN 800 AND 805
-----------------
SELECT ProductId, [Name], Color, StandardCost
FROM Production.Product
WHERE Name BETWEEN 'a' AND 'bi'
ORDER BY Name
------------------
SELECT ProductId, [Name], Color, StandardCost
FROM Production.Product
WHERE Name BETWEEN 'a' AND 'bi'
ORDER BY Name
------------------
SELECT BusinessEntityId, BirthDate, YEAR(GetDate()) - YEAR(BirthDate) 'Age'
FROM HumanResources.Employee
WHERE YEAR(GetDate()) - YEAR(BirthDate) BETWEEN 40 AND 50
ORDER BY Age
------------------
SELECT ProductId, Name, StandardCost
FROM Production.Product
WHERE StandardCost <> 0
-------------------
SELECT YEAR(GETDATE())
-------------------
SELECT COUNT(*) ---تعداد رکوردهای جدول
FROM Production.Product
-------------------
SELECT COUNT(*) ---تعداد رکوردهای جدول
FROM Sales.SalesOrderDetail
-------------------
SELECT COUNT(Color)
FROM Production.Product
-------------------
SELECT COUNT(ISNULL(Color, 'NoColor'))
FROM Production.Product
-------------------
SELECT SUM(LineTotal)
FROM Sales.SalesOrderDetail
-------------------
SELECT MIN(StandardCost)
FROM Production.Product
WHERE StandardCost != 0
-------------------
SELECT ProductId, Name, StandardCost
FROM Production.Product
WHERE StandardCost IN
(
	SELECT MIN(StandardCost)
	FROM Production.Product
	WHERE StandardCost != 0
)
--------------------
SELECT MAX(StandardCost)
FROM Production.Product
WHERE StandardCost != 0
--------------------
SELECT MAX(OrderQty)
FROM Sales.SalesOrderDetail
-------------------- اشتباه است
SELECT MAX(SUM(OrderQty))
FROM Sales.SalesOrderDetail
--------------------
SELECT AVG(YEAR(GETDATE()) - YEAR(BirthDate))
FROM HumanResources.Employee
--------------------
SELECT AVG(YEAR(GETDATE()) - YEAR(BirthDate))
FROM HumanResources.Employee
--------------------
SELECT AVG(LineTotal), SQRT(VAR(LineTotal)), SUM(LineTotal)
FROM Sales.SalesOrderDetail
--------------------
SELECT SUM(LineTotal)
FROM Sales.SalesOrderDetail
WHERE ProductID = 777
--------------------
SELECT ProductId, SUM(OrderQty) 'SumQty'
FROM Sales.SalesOrderDetail
GROUP BY ProductID
ORDER BY SumQty DESC
---------------------
SELECT ProductId, SUM(OrderQty) 'SumQty'
FROM Sales.SalesOrderDetail
WHERE ProductID <= 800
GROUP BY ProductID
HAVING SUM(OrderQty) >= 4000
ORDER BY SumQty DESC
----------------------
SELECT YEAR(HireDate) 'HireYear', MONTH(HireDate) 'HireMonth', COUNT(*) 'Count'
FROM HumanResources.Employee
GROUP BY YEAR(HireDate), MONTH(HireDate)
ORDER BY HireYear, HireMonth
----------------------
SELECT YEAR(HireDate) 'HireYear', COUNT(*) 'Count'
FROM HumanResources.Employee
GROUP BY YEAR(HireDate)
----------------------
SELECT YEAR(HireDate) 'HireYear', MONTH(HireDate) 'HireMonth', COUNT(*) 'Count'
FROM HumanResources.Employee
GROUP BY YEAR(HireDate), MONTH(HireDate)
WITH ROLLUP
ORDER BY HireYear, HireMonth
----------------------
SELECT YEAR(HireDate) 'HireYear', MONTH(HireDate) 'HireMonth', COUNT(*) 'Count'
FROM HumanResources.Employee
GROUP BY YEAR(HireDate), MONTH(HireDate)
WITH CUBE
ORDER BY HireYear, HireMonth
----------------------
SELECT ROW_NUMBER() OVER(ORDER BY Name) 'Row' , ProductId, Name, Color, StandardCost
FROM Production.Product
--ORDER BY ProductId
----------------------
SELECT ROW_NUMBER() OVER(PARTITION BY Color ORDER BY Name) 'Row' , 
ProductId, Name, Color, StandardCost
FROM Production.Product
-----------------------
SELECT ROW_NUMBER() OVER(ORDER BY StandardCost DESC) 'Row' , 
RANK() OVER(ORDER BY StandardCost DESC) 'Rank',
ProductId, Name, Color, StandardCost
FROM Production.Product
ORDER BY StandardCost DESC
-----------------------
SELECT ROW_NUMBER() OVER(ORDER BY StandardCost DESC) 'Row' , 
RANK() OVER(ORDER BY StandardCost DESC) 'Rank',
DENSE_RANK() OVER(ORDER BY StandardCost DESC) 'Dense Rank',
ProductId, Name, Color, StandardCost
FROM Production.Product
ORDER BY StandardCost DESC



