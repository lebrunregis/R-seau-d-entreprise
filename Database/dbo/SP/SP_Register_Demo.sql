CREATE PROCEDURE [dbo].[SP_Register_Demo]
	@LastName varchar(50),
	@FirstName varchar(50)
AS
BEGIN
	DECLARE @hash varbinary(32)
	SET @Hash =  [dbo].FN_Hash( 'admin') 
	INSERT INTO [dbo].Employee(LastName,FirstName,Email,Passwd,RegNat,Address,Phone) 
	OUTPUT Inserted.Employee_Id 
	VALUES ( @LastName , @FirstName,CONCAT(@LastName,@FirstName,'@test.com'),@Hash,CONCAT(@LastName,'-',@FirstName),'','')
END