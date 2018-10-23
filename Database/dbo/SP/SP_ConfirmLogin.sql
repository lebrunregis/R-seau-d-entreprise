CREATE procedure [dbo].[SP_ConfirmLogin] 
    @Email varchar(360),
	@Password varchar(50)
AS
BEGIN
	select count(*) from [dbo].[Employee] where [dbo].[Employee].Email = @Email and [dbo].[Employee].Passwd = [dbo].FN_Hash(@Password); 
END

