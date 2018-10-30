CREATE PROCEDURE [dbo].[Register]
	@LastName nvarchar(50),
	@FirstName nvarchar(50),
	@Email nvarchar(360),
	@Password nvarchar(50),
	@RegNat nvarchar(50),
	@Address nvarchar(MAX),
	@Phone varchar(50)
AS
BEGIN
	DECLARE @hash varbinary(32)
	SET @Hash =  [dbo].FN_Hash( @Password) 
	INSERT INTO [dbo].Employee(LastName,FirstName,Email,Passwd,RegNat,Address,Phone) 
	VALUES ( @LastName , @FirstName,@Email,@Hash,@RegNat,@Address,@Phone)
	SELECT Scope_Identity()
END