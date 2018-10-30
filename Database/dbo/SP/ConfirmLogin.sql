CREATE procedure [dbo].[ConfirmLogin] 
    @Email varchar(360),
	@Password varchar(50)
AS
BEGIN
	select Employee_Id from [dbo].[Employee] where [dbo].[Employee].Email = @Email and [dbo].[Employee].Passwd = [dbo].FN_Hash(@Password) and [dbo].[Employee].Active = 1; 
END

