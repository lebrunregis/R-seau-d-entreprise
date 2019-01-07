CREATE PROCEDURE [dbo].[Register_Demo]
	@LastName varchar(50),
	@FirstName varchar(50)
AS
BEGIN
  BEGIN TRANSACTION
	DECLARE @hash varbinary(32);
	SET @Hash =  [dbo].FN_Hash( 'admin') ;
	INSERT INTO [dbo].Employee(LastName,FirstName,Email,RegNat,Passwd,Address,Phone)
	VALUES ( @LastName , @FirstName,'','', @Hash,'Gosselies Belgique',convert(VARCHAR(50),convert(bigint,RAND()*10000000000,0)));
	UPDATE [dbo].Employee SET Email=CONCAT(convert(varchar(10),SCOPE_IDENTITY()), '@test.be'), RegNat = convert(varchar(10),convert(bigint,RAND(SCOPE_IDENTITY())*10000000000,0)) WHERE Employee_Id = CONVERT(int,SCOPE_IDENTITY());
  COMMIT TRANSACTION
END