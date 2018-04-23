CREATE DATABASE Session16
GO
USE Session16
GO--Create New Table
CREATE TABLE dbo.Employee   
(    
  [EmployeeID] int IDENTITY PRIMARY KEY CLUSTERED   
  , [Name] nvarchar(100) NOT NULL  
  , [Position] nvarchar(100) NOT NULL   
  , [Department] nvarchar(100) NOT NULL  
  , [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START  
  , [ValidTo] datetime2 GENERATED ALWAYS AS ROW END  
  , PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)  
 )    
 WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.EmployeeHistory));  

 GO
SELECT * FROM Employee   
FOR SYSTEM_TIME BETWEEN '2014-01-01 00:00:00.0000000' AND '2015-01-01 00:00:00.0000000'   
WHERE EmployeeID = 1000 ORDER BY ValidFrom;  
GO
SELECT * FROM Employee   
    FOR SYSTEM_TIME ALL 
	WHERE EmployeeID = 2 
	ORDER BY ValidFrom DESC; 
GO
SELECT * FROM Employee 
FOR SYSTEM_TIME CONTAINED IN ('2014-01-01 00:00:00.0000000', '2015-01-01 00:00:00.0000000')   
WHERE EmployeeID = 1000 ORDER BY ValidFrom; 
GO--ALTER Existing Table
ALTER TABLE Employee   
ADD   
    ValidFrom datetime2 GENERATED ALWAYS AS ROW START HIDDEN    
        constraint DF_ValidFrom DEFAULT DATEADD(second, -1, SYSUTCDATETIME())  
    , ValidTo datetime2  GENERATED ALWAYS AS ROW END HIDDEN     
        constraint DF_ValidTo DEFAULT '9999.12.31 23:59:59.99'  
    , PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo);   

ALTER TABLE Employee    
    SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.EmployeeHistory));  
GO
SELECT * FROM Employee
GO
SELECT * FROM dbo.EmployeeHistory
GO
ALTER DATABASE Session16 ADD FILEGROUP MODataFG CONTAINS MEMORY_OPTIMIZED_DATA   
ALTER DATABASE Session16 ADD FILE (name='MOData01', filename='D:\DBBackups\MOData_1.ndf') TO FILEGROUP MODataFG   
ALTER DATABASE Session16 SET MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT=ON  
GO  
CREATE TABLE dbo.ShoppingCart (   
	ShoppingCartId INT IDENTITY PRIMARY KEY NONCLUSTERED,  
	UserId INT NOT NULL INDEX ix_UserId NONCLUSTERED,   
	CreatedDate DATETIME2 NOT NULL,   
	TotalPrice DECIMAL(10,2)  
) WITH (MEMORY_OPTIMIZED=ON)   
GO  
ALTER DATABASE Session16 ADD FILEGROUP FSDataFG CONTAINS FILESTREAM 
ALTER DATABASE Session16 ADD FILE (name='FSData01', filename='D:\DBBackups\FSData_1.ndf') TO FILEGROUP FSDataFG   
GO
CREATE TABLE Attachment
(
	Id INT IDENTITY PRIMARY KEY,
	Title NVARCHAR(50),
	FileData VARBINARY(MAX) FILESTREAM
)
GO
EXEC sp_configure filestream_access_level, 2
reconfigure with override
GO
SELECT @@Version