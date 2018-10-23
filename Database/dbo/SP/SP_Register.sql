CREATE PROCEDURE [dbo].[SP_Register]
	@login varchar(50),
	@email varchar(50),
	@pwd varchar(50)
AS
BEGIN
	DECLARE @hash varbinary(32)
	SET @hash =  [dbo].FN_Hash( @pwd) 
	INSERT INTO Login (Login,Email,Hash) OUTPUT Inserted.ID VALUES ( @login ,@email,@hash )
END