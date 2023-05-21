USE [HealthcareDB]

SELECT * FROM Users;

--CRUD OPERATION ON USERS

CREATE PROCEDURE [dbo].[GetUsersList]
AS
BEGIN
SELECT * FROM Users;
END 
GO

CREATE PROCEDURE [dbo].[GetUserById]
@UserId INT
AS 
BEGIN
SELECT * FROM dbo.Users
WHERE Id=@UserId
END
GO

EXEC [dbo].[GetUserById] 1

CREATE PROCEDURE [dbo].[AddUser]
@name varchar(200),
@username varchar(200),
@email varchar(200),
@phone varchar(200),
@role varchar(200),
@password varchar(20)
AS
BEGIN
INSERT INTO [dbo].[Users](name,username,email,phone,role,password)
VALUES(@name,@username,@email,@phone,@role,@password)
END
GO

CREATE PROCEDURE [dbo].[DeleteUser]
@UserId INT
AS
BEGIN
DELETE FROM dbo.Users
WHERE Id=@UserId
END
GO

CREATE PROCEDURE [dbo].[Login]
@Userusername VARCHAR(100),
@Userpassword VARCHAR(100)
AS
BEGIN
SELECT * FROM dbo.Users
WHERE username=@Userusername AND password=@Userpassword;
END
GO

--CRUD OPERATION ON MEDICINES

CREATE PROCEDURE [dbo].[GetMedicineList]
AS
BEGIN
SELECT * FROM Medicines;
END 
GO

CREATE PROCEDURE [dbo].[GetMedicineById]
@MedicineId INT
AS 
BEGIN
SELECT * FROM dbo.Medicines
WHERE Id=@MedicineId
END
GO

EXEC [dbo].[GetMedicineById] 1

CREATE PROCEDURE [dbo].[AddMedicine]
@medicine_name varchar(200),
@medicine_img varchar(200),
@medicine_seller varchar(200),
@medicine_price float,
@medicine_details varchar(200),
@CategoryId int
AS
BEGIN
INSERT INTO [dbo].[Medicines](medicine_name,medicine_img,medicine_seller,medicine_price,medicine_details,CategoryId)
VALUES(@medicine_name,@medicine_img,@medicine_seller,@medicine_price,@medicine_details,@CategoryId)
END
GO

CREATE PROCEDURE [dbo].[DeleteMedicine]
@MedicineId INT
AS
BEGIN
DELETE FROM dbo.Medicines
WHERE Id=@MedicineId
END
GO

CREATE PROCEDURE [dbo].[UpdateMedicine]
@MedicineId INT,
@medicine_name varchar(200),
@medicine_img varchar(200),
@medicine_seller varchar(200),
@medicine_price float,
@medicine_details varchar(200),
@CategoryId int
AS
BEGIN
UPDATE dbo.Medicines
SET medicine_name=@medicine_name,
medicine_img=@medicine_img,
medicine_seller=@medicine_seller,
medicine_price=@medicine_price,
medicine_details=@medicine_details,
CategoryId=@CategoryId
WHERE Id=@MedicineId
END 
GO

--CRUD OPERATION ON CATEGORIES

CREATE PROCEDURE [dbo].[GetCategoryList]
AS
BEGIN
SELECT * FROM Categories;
END 
GO

CREATE PROCEDURE [dbo].[GetCategoryById]
@CategoryId INT
AS 
BEGIN
SELECT * FROM dbo.Categories
WHERE CategoryId=@CategoryId
END
GO

CREATE PROCEDURE [dbo].[AddCategory]
@CategoryName varchar(200),
@CategoryDescription varchar(200)
AS
BEGIN
INSERT INTO [dbo].[Categories](CategoryName,Description)
VALUES(@CategoryName,@CategoryDescription)
END
GO

CREATE PROCEDURE [dbo].[UpdateCategory]
@CategoryId INT,
@CategoryName varchar(200),
@CategoryDescription varchar(200)
AS
BEGIN
UPDATE dbo.Categories
SET CategoryName=@CategoryName,
Description=@CategoryDescription
WHERE CategoryId=@CategoryId
END 
GO

CREATE PROCEDURE [dbo].[DeleteCategory]
@CategoryId INT
AS
BEGIN
DELETE FROM dbo.Categories
WHERE CategoryId=@CategoryId
END
GO

--CRUD OPERATION ON CART

CREATE PROCEDURE [dbo].[GetCartList]
AS
BEGIN
SELECT * FROM Carts;
END 
GO

CREATE PROCEDURE [dbo].[GetCartById]
@CartId INT
AS 
BEGIN
SELECT * FROM dbo.Carts
WHERE CartId=@CartId
END
GO


CREATE PROCEDURE [dbo].[AddCart]
@Name varchar(200),
@Price float,
@Seller varchar(200)
AS
BEGIN
INSERT INTO [dbo].[Carts](Name,Price,Seller)
VALUES(@Name,@Price,@Seller)
END
GO

CREATE PROCEDURE [dbo].[DeleteCart]
@CartId INT
AS
BEGIN
DELETE FROM dbo.Carts
WHERE CartId=@CartId
END
GO


