CREATE PROCEDURE [dbo].[Register_Demo]
	@LastName varchar(50),
	@FirstName varchar(50)
AS
BEGIN
  BEGIN TRANSACTION
	DECLARE @hash varbinary(32);
	SET @Hash =  [dbo].FN_Hash( 'admin') ;
	INSERT INTO [dbo].Employee(LastName,FirstName,Email,RegNat,Passwd,Address,Phone)
	VALUES ( @LastName , @FirstName,'','', @Hash,'Gosselies Belgique',Null);
	UPDATE [dbo].Employee SET Email=CONCAT(convert(varchar(10),SCOPE_IDENTITY()), '@test.be'), RegNat = convert(varchar(10),SCOPE_IDENTITY()) WHERE Employee_Id = convert(int,SCOPE_IDENTITY());
  COMMIT TRANSACTION
END