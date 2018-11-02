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
	DECLARE @Hash varbinary(32)
	SET @Hash =  [dbo].FN_Hash( @Password) 
	INSERT INTO [dbo].Employee(LastName,FirstName,Email,Passwd,RegNat,Address,Phone) 
	VALUES ( [dbo].FN_StrClean(@LastName) , [dbo].FN_StrClean(@FirstName),[dbo].FN_StrClean(@Email),@Hash,[dbo].FN_StrClean(@RegNat),[dbo].FN_StrClean(@Address),NULLIF([dbo].FN_StrClean(@Phone),''))
	SELECT Scope_Identity()
END