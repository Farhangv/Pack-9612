USE AdventureWorks
GO
CREATE PROC USP_GetProductsBySubCategory
(
	@SearchPhrase NVARCHAR(50)
)
AS
BEGIN
	SELECT ProductId, p.Name, Color, ListPrice, StandardCost, ps.Name 'SubCategoryName'
	FROM Production.Product p
	INNER JOIN Production.ProductSubcategory ps
	ON p.ProductSubcategoryID = ps.ProductSubcategoryID
	WHERE ps.Name LIKE '%' + @SearchPhrase + '%'
END
GO
EXEC USP_GetProductsBySubCategory 'Bike'
GO
ALTER PROC USP_GetProductsBySubCategory
(
	@SearchPhrase NVARCHAR(50)
)
AS
BEGIN
	SELECT ProductId, p.Name, Color, ListPrice, StandardCost, ps.Name 'SubCategoryName'
	FROM Production.Product p
	INNER JOIN Production.ProductSubcategory ps
	ON p.ProductSubcategoryID = ps.ProductSubcategoryID
	WHERE ps.Name LIKE '%' + @SearchPhrase + '%'
	
	SELECT * FROM Person.Person
END
GO
DECLARE @Result INT
EXEC @Result = USP_GetProductsBySubCategory 'Bike'
PRINT @Result
GO
CREATE DATABASE Session10
GO
USE Session10
GO
CREATE TABLE [User]
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(20) NOT NULL UNIQUE,
	[PasswordHash] VARBINARY(100),
	CellPhone NVARCHAR(11) UNIQUE NOT NULL,
	CONSTRAINT CHK_CellPhone CHECK(CellPhone LIKE '09_________' )
)
GO
CREATE PROC USP_UserInsert
(
	@Username NVARCHAR(20),
	@Password NVARCHAR(20),
	@CellPhone CHAR(11)
)
AS
BEGIN
	BEGIN TRY
		INSERT INTO [User] (Username, PasswordHash, CellPhone)
		VALUES(@Username, HASHBYTES('md5',@Password), @CellPhone)
		RETURN 0
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
		RETURN ERROR_NUMBER()
	END CATCH
END
GO
DECLARE @Result INT
EXEC @Result = USP_UserInsert 'johndoe', '123', '09121234569'
IF @Result = 2627
BEGIN
	PRINT N'لطفا نام کاربری دیگری انتخاب کنید'
END
--PRINT @Result
GO
ALTER PROC USP_UserInsert
(
	@Username NVARCHAR(20),
	@Password NVARCHAR(20),
	@CellPhone CHAR(11)
)
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRY
		INSERT INTO [User] (Username, PasswordHash, CellPhone)
		VALUES(@Username, HASHBYTES('md5',@Password), @CellPhone)
		RETURN 0
	END TRY
	BEGIN CATCH
		--PRINT ERROR_MESSAGE()
		RETURN ERROR_NUMBER()
	END CATCH
END
GO
ALTER PROC USP_UserInsert
(
	@Username NVARCHAR(20),
	@Password NVARCHAR(20),
	@CellPhone CHAR(11),
	@ErrorMessage NVARCHAR(200) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRY
		INSERT INTO [User] (Username, PasswordHash, CellPhone)
		VALUES(@Username, HASHBYTES('md5',@Password), @CellPhone)
		RETURN 0
	END TRY
	BEGIN CATCH
		--PRINT ERROR_MESSAGE()
		SET @ErrorMessage = ERROR_MESSAGE()
		RETURN ERROR_NUMBER()
	END CATCH
END
GO
DECLARE @Result INT
DECLARE @ErrorMessage NVARCHAR(200)
EXEC @Result = USP_UserInsert 'janedoe', '123', '09121234568', @ErrorMessage OUTPUT
IF @Result = 0
BEGIN
	PRINT N'رکورد با موفقیت ثبت شد'
END
ELSE
BEGIN
	PRINT @ErrorMessage
END
GO--روال ثبت کاربر
ALTER PROC USP_UserInsert
(
	@Username NVARCHAR(20),
	@Password NVARCHAR(20),
	@CellPhone CHAR(11),
	@ErrorMessage NVARCHAR(200) OUTPUT,
	@UserId INT OUTPUT --شناسه کاربر تازه درج شده
)
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRY
		INSERT INTO [User] (Username, PasswordHash, CellPhone)
		VALUES(@Username, HASHBYTES('md5',@Password), @CellPhone)
		SET @UserId = SCOPE_IDENTITY()
		RETURN 0
	END TRY
	BEGIN CATCH
		--PRINT ERROR_MESSAGE()
		SET @ErrorMessage = ERROR_MESSAGE()
		RETURN ERROR_NUMBER()
	END CATCH
END
GO
DECLARE @Result INT
DECLARE @ErrorMessage NVARCHAR(200)
DECLARE @UserId INT
EXEC @Result = USP_UserInsert 'daviddoe', '123', '09121234567', 
@ErrorMessage OUTPUT, @UserId OUTPUT
IF @Result = 0
BEGIN
	PRINT N'رکورد با موفقیت ثبت شد'
	PRINT N'شناسه کاربر : ' + CONVERT(NVARCHAR(10), @UserId)
END
ELSE
BEGIN
	PRINT @ErrorMessage
END
GO--روال تغییر اطلاعات کاربر
CREATE PROC USP_UserUpdate
(
	@UserId INT,
	@Username NVARCHAR(20),
	@Password NVARCHAR(20),
	@CellPhone CHAR(11)
)
AS
BEGIN
	UPDATE [User] SET Username = @Username,
					  PasswordHash = HASHBYTES('md5', @Password),
					  CellPhone = @CellPhone
	WHERE Id = @UserId
END
GO
EXEC USP_UserUpdate 8, 'abc', '123', '09121236547'
GO
CREATE PROC USP_UserDelete
(
	@UserId INT
)
AS
BEGIN
	DELETE FROM [User] WHERE Id = @UserId
END
GO
SELECT * FROM [User]
GO
EXEC USP_UserDelete 8
GO
CREATE PROC USP_UserSelect
(
	@UserId INT
)
AS
BEGIN
	SELECT * FROM [User] WHERE Id = @UserId
END
GO
EXEC USP_UserSelect 6
GO
CREATE TABLE Person
(
	Id INT PRIMARY KEY IDENTITY,
	FullName NVARCHAR(50)
)
GO
CREATE TABLE Student
(
	Id INT PRIMARY KEY FOREIGN KEY REFERENCES Person(Id),
	StudentCode CHAR(10)
)
GO
CREATE PROC USP_StudentInsert
(
	@FullName NVARCHAR(50),
	@StudentCode CHAR(10)
)
AS
BEGIN
	INSERT INTO Person(FullName)
	VALUES (@FullName)
	DECLARE @PersonId INT
	SET @PersonId = SCOPE_IDENTITY()
	INSERT INTO Student(Id, StudentCode)
	VALUES(@PersonId, @StudentCode)
END
GO
EXEC USP_StudentInsert 'John Doe', '5214789635'
GO
SELECT * FROM Person
Go
SELECT * FROM Student
GO
ALTER TABLE [User]
ADD Email NVARCHAR(60) 
GO
CREATE TRIGGER TG_BlockFakeEmail
ON [User]
FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @Email NVARCHAR(60)
	SELECT @Email = Email
	FROM inserted

	IF @Email LIKE '%@abc.xyz'
	BEGIN
		ROLLBACK TRAN
	END
END
GO
INSERT INTO [User](Username,PasswordHash,CellPhone,Email)
VALUES('abc',HASHBYTES('md5','123'), '09362145698', 'me@abc.com')
GO
SELECT * FROM [User]
GO
UPDATE [user] SET Email = 'me@abc.xyz'
GO
ALTER TABLE [User]
ADD IsActive BIT DEFAULT 1
GO
SELECT * FROM [User]
GO
CREATE TRIGGER TG_UserDelete
ON [User]
INSTEAD OF DELETE
AS
BEGIN
	UPDATE [User] SET IsActive = 0
	WHERE Id IN
	(
		SELECT Id
		FROM deleted
	)
END
GO
DELETE FROM [User] 
WHERE Id = 6
GO
SELECT * FROM [User]
GO
