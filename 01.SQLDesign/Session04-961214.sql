CREATE DATABASE Session05
GO
USE Session05
GO
CREATE TABLE Student
(
	Id INT PRIMARY KEY,
	FullName NVARCHAR(50)
)
GO
CREATE TABLE Course
(
	Id INT PRIMARY KEY,
	Title NVARCHAR(50),
	TeacherId INT
)
GO
CREATE TABLE Teacher
(
	Id INT PRIMARY KEY,
	FullName NVARCHAR(50)
)
GO
INSERT INTO Student(Id, FullName)
VALUES (1, 'Reza Rezayi'),
	   (2, 'Sara Sarayi'),
	   (3, 'Maryam Maryami'),
	   (4, 'Payam Payami')
GO
INSERT INTO Teacher(Id,FullName)
VALUES	(1, 'John Doe'),
		(2, 'Chandler Bing'),
		(3, 'Joey Tribbiani'),
		(4, 'Monica Geller')
GO
INSERT INTO Course(Id, Title, TeacherId)
VALUES	(1, 'C#', 2),
		(2, 'SQL Server', 4),
		(3, 'Java', 5),
		(4, 'JavaScript', 2),
		(5, 'PHP', 3)
GO
SELECT c.Id, c.Title, t.FullName
FROM Course c 
FULL OUTER JOIN Teacher t
ON c.TeacherId = t.Id
GO
SELECT *
FROM Course c
CROSS JOIN Student
WHERE c.Id IN ( 1, 5 ,4)
GO
CREATE TABLE Employee
(
	Id INT PRIMARY KEY,
	FullName NVARCHAR(50),
	ManagerId INT
)
GO
ALTER TABLE Employee
ADD JobTitle NVARCHAR(50)
GO
INSERT INTO Employee(Id, FullName, JobTitle, ManagerId)
VALUES (1, 'Reza Rezayi','CEO', NULL),
	   (2, 'Sara Sarayi', 'Production Manager', 1),
	   (3, 'Maryam Maryami', 'Public Relation Manager', 1),
	   (4, 'Payam Payami', 'Support Manager', 1),
	   (5, 'John Doe', 'Senior Web Developer', 2),
	   (6, 'Chandler Bing', 'Junior Web Developer', 5),
	   (7, 'Joey Tribbiani', 'Support Technician', 4),
	   (8, 'Monica Geller', 'Public Relation Employee', 3)
GO
SELECT e.FullName, e.JobTitle, m.FullName 'Manager FullName', m.JobTitle 'Manager Job Title'
FROM Employee e
INNER JOIN Employee m
ON e.ManagerId = m.Id
GO
SELECT e.FullName, e.JobTitle, m.FullName 'Manager FullName', m.JobTitle 'Manager Job Title'
FROM Employee e
LEFT OUTER JOIN Employee m
ON e.ManagerId = m.Id
GO
SELECT e.FullName, e.JobTitle, m.FullName 'Manager FullName', m.JobTitle 'Manager Job Title'
FROM Employee e
RIGHT OUTER JOIN Employee m
ON e.ManagerId = m.Id
GO
USE AdventureWorks
GO
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color = 'Blue'
INTERSECT
SELECT ProductID, Name, Color
FROM Production.Product
WHERE ProductId IN 
(
	SELECT DISTINCT ProductID
	FROM Sales.SalesOrderDetail
)
GO
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color = 'Blue'
UNION
SELECT ProductID, Name, Color
FROM Production.Product
WHERE ProductId IN 
(
	SELECT DISTINCT ProductID
	FROM Sales.SalesOrderDetail
)
GO
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color = 'Blue'
UNION ALL
SELECT ProductID, Name, Color
FROM Production.Product
WHERE ProductId IN 
(
	SELECT DISTINCT ProductID
	FROM Sales.SalesOrderDetail
)
GO
SELECT ProductID, Name, Color
FROM Production.Product
WHERE ProductId IN 
(
	SELECT DISTINCT ProductID
	FROM Sales.SalesOrderDetail
)
EXCEPT
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color = 'Blue'
GO
SELECT GETDATE() 'DateTime', 
SYSDATETIME() 'DateTime2', 
SYSDATETIMEOFFSET() 'DateTimeOffset'
GO
SELECT YEAR(GETDATE()), MONTH(GETDATE()), DAY(GETDATE())
GO
SELECT DATEPART(YEAR, GETDATE()),
DATEPART(MONTH, GETDATE()),
DATEPART(DAY, GETDATE()),
DATEPART(HOUR, GETDATE()),
DATEPART(MINUTE, GETDATE()),
DATEPART(SECOND, GETDATE())
GO
SELECT DATEADD(DAY, 7, GETDATE())
GO
SELECT BusinessEntityId, JobTitle, HireDate, DATEADD(YEAR, 30, HireDate) 'Retire Date'
FROM HumanResources.Employee
ORDER BY [Retire Date]
GO
SELECT BusinessEntityId, JobTitle, HireDate, DATEDIFF(YEAR, HireDate, GETDATE()) 'WorkExperience'
FROM HumanResources.Employee
ORDER BY WorkExperience DESC
GO
SELECT SYSDATETIMEOFFSET(),SWITCHOFFSET(SYSDATETIMEOFFSET(), '+00:00')
GO
SELECT SYSDATETIME(), '+03:30', TODATETIMEOFFSET(SYSDATETIME(), '+03:30')
GO
SELECT FirstName, MiddleName, LastName, 
FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName 'FullName'
FROM Person.Person
GO
SELECT FirstName, MiddleName, LastName, 
CONCAT(FirstName, ' ' ,MiddleName , ' ' , LastName) 'FullName'
FROM Person.Person
GO
SELECT Name, SUBSTRING(Name, 1, 2)
FROM Production.Product
GO
SELECT Name, LEFT(Name, 2), RIGHT(Name, 2)
FROM Production.Product
GO
SELECT Name, CHARINDEX('_', Name)
FROM Production.Product
GO
SELECT Name, (RIGHT(Name, LEN(Name) - CHARINDEX(',', Name) )) 'Size'
FROM Production.Product
GO
SELECT Name, (SUBSTRING(Name, CHARINDEX(',', Name), LEN(Name) - CHARINDEX(',', Name))) 'Size'
FROM Production.Product
GO
SELECT ProductId, Name, (RIGHT(Name, LEN(Name) - CHARINDEX(',', Name) )) 'Size'
FROM Production.Product
WHERE CHARINDEX(',', Name) != 0 
--AND 
--(
--RIGHT(Name, LEN(Name) - CHARINDEX(',', Name))
--NOT IN (SELECT DISTINCT Color FROM Production.Product)
--)
UNION 
SELECT ProductId, Name , '-' 'Size'
FROM Production.Product
WHERE CHARINDEX(',', Name) = 0
ORDER BY Size
GO
SELECT Name , (REPLACE(Name, ',' , ' |')) 
FROM Production.Product
GO
SELECT REPLICATE(0, 10)
GO
SELECT Name, UPPER(Name), LOWER(Name)
FROM Production.Product
GO
SELECT '       Farhangv@live.com', LTRIM('       Farhangv@live.com')
GO
SELECT LEN('Farhangv@live.com       ' + 'aaa'), LEN(RTRIM('Farhangv@live.com       ') + 'aaa')
GO
SELECT DISTINCT Color, 
CASE Color
WHEN 'Blue' THEN N'آبی'
WHEN 'Red' THEN N'قرمز'
WHEN 'Black' THEN N'مشکی'
ELSE N'سایر رنگ ها'
END رنگ
FROM Production.Product
GO
SELECT p.ProductId, Name, Color, SUM(OrderQty),
CASE 
WHEN SUM(OrderQty) > 4000 THEN N'پرفروش'
WHEN SUM(OrderQty) BETWEEN 2000 AND 4000 THEN N'فروش متوسط'
WHEN SUM(OrderQty) <= 1999 THEN N'کم فروش'
END
FROM Production.Product p
INNER JOIN Sales.SalesOrderDetail s
ON p.ProductID = s.ProductID
GROUP BY p.ProductId, Name, Color
GO
SELECT p.ProductId, Name, Color, SUM(OrderQty),
CASE 
WHEN SUM(OrderQty) > 4000 AND SUM(OrderQty) < 5000 THEN N'پرفروش'
WHEN SUM(OrderQty) BETWEEN 2000 AND 4000 THEN N'فروش متوسط'
WHEN SUM(OrderQty) <= 1999 THEN N'کم فروش'
END
FROM Production.Product p
INNER JOIN Sales.SalesOrderDetail s
ON p.ProductID = s.ProductID
GROUP BY p.ProductId, Name, Color
