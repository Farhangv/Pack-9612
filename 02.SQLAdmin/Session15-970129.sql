CREATE DATABASE Session15
GO
USE Session15
GO
CREATE TABLE Production.Product
(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(50),
	Color NVARCHAR(30),
	Cost DECIMAL(10,2)
)
GO
INSERT INTO Production.Product
SELECT Name, Color, StandardCost
FROM AdventureWorks.Production.Product
GO
CREATE TABLE Production.Category
(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(50)
)
GO
CREATE USER Manager WITHOUT LOGIN;  
CREATE USER Sales1 WITHOUT LOGIN;  
CREATE USER Sales2 WITHOUT LOGIN;
GO
CREATE TABLE Sales  
    (  
    OrderID int,  
    SalesRep sysname,  
    Product varchar(10),  
    Qty int  
    );
GO
INSERT Sales VALUES   
(1, 'Sales1', 'Valve', 5),   
(2, 'Sales1', 'Wheel', 2),   
(3, 'Sales1', 'Valve', 4),  
(4, 'Sales2', 'Bracket', 2),   
(5, 'Sales2', 'Wheel', 5),   
(6, 'Sales2', 'Seat', 5);  
-- View the 6 rows in the table  
SELECT * FROM Sales;
GO
GRANT SELECT ON Sales TO Manager;  
GRANT SELECT ON Sales TO Sales1;  
GRANT SELECT ON Sales TO Sales2;
GO
CREATE SCHEMA Security;  
GO  

CREATE FUNCTION Security.fn_securitypredicate
(
	@SalesRep AS sysname
)  
RETURNS TABLE  
WITH SCHEMABINDING  
AS  
	RETURN 
	SELECT 1 'fn_securitypredicate_result'
	WHERE @SalesRep = USER_NAME() OR USER_NAME() = 'Manager';
GO
CREATE SECURITY POLICY SalesFilter
ADD FILTER PREDICATE Security.fn_securitypredicate(SalesRep)   
ON dbo.Sales  
WITH (STATE = ON);
GO
EXECUTE AS USER = 'Sales1';  
SELECT * FROM Sales;   
REVERT;  

EXECUTE AS USER = 'Sales2';  
SELECT * FROM Sales;   
REVERT;  

EXECUTE AS USER = 'Manager';  
SELECT * FROM Sales;   
REVERT;
GO
SELECT USER_NAME()
GO
EXECUTE AS USER = 'Manager'
SELECT *
FROM Security.fn_securitypredicate('Manager')
REVERT;
GO
CREATE TABLE Invoice
(
	Id INT PRIMARY KEY IDENTITY,
	CustomerName NVARCHAR(50),
	Total INT
) ON SalesGroup
GO
INSERT INTO Invoice 
VALUES('Payam', 12000)
GO 100000
