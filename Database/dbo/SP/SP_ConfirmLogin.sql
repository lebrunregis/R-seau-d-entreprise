CREATE procedure [dbo].[SP_ConfirmLogin] 
    @Email varchar(360),
	@pwd varchar(50)
AS
BEGIN
	select count(*) from [Employee] where [Employee].Email = @login and [Employee].Passwd = dbo.FN_Hash(@pwd); 
END

