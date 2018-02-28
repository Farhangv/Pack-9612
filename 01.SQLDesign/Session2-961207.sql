SELECT 123
--------------------
SELECT 'Hello, How Are You?'
--------------------
SELECT N'سلام'
--------------------
SELECT @@CONNECTIONS
--------------------
SELECT @@LANGUAGE
--------------------
SELECT @@VERSION
--------------------
SELECT GETDATE()
--------------------
USE AdventureWorks
--------------------
SELECT * 
FROM Production.Product
--------------------
SELECT ProductId, Name, Color
FROM Production.Product
---------------------
SELECT * 
FROM DatabaseLog
---------------------
SELECT ProductId 'کد محصول', 
Name نام, 
Color AS رنگ, 
StandardCost AS 'هزینه تولید'
FROM Production.Product
---------------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
ORDER BY Name
---------------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
ORDER BY Name DESC
---------------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
ORDER BY Color, Name DESC
---------------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
ORDER BY 3, 2 DESC
---------------------
SELECT ProductId, Name, Color, StandardCost
FROM Production.Product
ORDER BY StandardCost DESC
---------------------
SELECT TOP 6 WITH TIES
ProductId, Name, Color, StandardCost
FROM Production.Product
ORDER BY StandardCost DESC
----------------------
SELECT TOP 10 PERCENT
ProductId, Name, Color, StandardCost
FROM Production.Product
ORDER BY StandardCost DESC
----------------------
SELECT DISTINCT Color
FROM Production.Product
----------------------
SELECT DISTINCT Color, Name
FROM Production.Product
----------------------
SELECT --DISTINCT
TOP 10
ProductId, UnitPrice
FROM Sales.SalesOrderDetail
ORDER BY UnitPrice DESC
----------------------
SELECT TOP 10 WITH TIES BirthDate, JobTitle
FROM HumanResources.Employee
ORDER BY BirthDate
-----------------------
SELECT TOP 10 WITH TIES 
BirthDate, YEAR(GETDATE()) - YEAR(BirthDate) 'Age',JobTitle
FROM HumanResources.Employee
ORDER BY BirthDate
-----------------------
SELECT TOP 10 WITH TIES 
BirthDate, YEAR(GETDATE()) - YEAR(BirthDate) 'Age',JobTitle,
HireDate, YEAR(GETDATE()) - YEAR(HireDate) 'Experience'
FROM HumanResources.Employee
ORDER BY HireDate ASC
-----------------------
SELECT TOP 1
BusinessEntityID, CommissionPct
FROM Sales.SalesPerson
ORDER BY CommissionPct DESC
-----------------------
SELECT DISTINCT JobTitle
FROM HumanResources.Employee
-----------------------

