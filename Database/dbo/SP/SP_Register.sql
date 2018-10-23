DROP PROCEDURE [dbo].[SP_Register]
GO
CREATE PROCEDURE [dbo].[SP_Register]
	@LastName varchar(50),
	@FirstName varchar(50),
	@Email varchar(360),
	@Password varchar(50),
	@RegNat varchar(50),
	@Address varchar(MAX),
	@Phone varchar(50)
AS
BEGIN
	DECLARE @hash varbinary(32)
	SET @Hash =  [dbo].FN_Hash( @Password) 
	INSERT INTO [dbo].Employee(LastName,FirstName,Email,Passwd,RegNat,Address,Phone) 
	OUTPUT Inserted.ID 
	VALUES ( @LastName , @FirstName,@Email,@Hash,@RegNat,@Address,@Phone)
END