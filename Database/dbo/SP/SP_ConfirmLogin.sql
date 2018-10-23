CREATE procedure [SP_ConfirmLogin] 
    @Email varchar(360),
	@Password varchar(50)
AS
BEGIN
	select count(*) from [Employee] where [Employee].Email = @Email and [Employee].Passwd = FN_Hash(@Password); 
END

