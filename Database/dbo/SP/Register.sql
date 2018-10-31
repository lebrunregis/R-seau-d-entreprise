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
	VALUES ( FN_StrClean(@LastName) , FN_StrClean(@FirstName),FN_StrClean(@Email),@Hash,FN_StrClean(@RegNat),FN_StrClean(@Address),NULLIF(FN_StrClean(@Phone),''))
	SELECT Scope_Identity()
END