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


