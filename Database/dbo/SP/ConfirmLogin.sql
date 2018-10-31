CREATE procedure [dbo].[ConfirmLogin] 
    @Email nvarchar(360),
	@Password nvarchar(50)
AS
BEGIN
	return select Employee_Id from [dbo].[Employee] where [dbo].[Employee].Email = @Email and [dbo].[Employee].Passwd = [dbo].FN_Hash(@Password) and [dbo].[Employee].Active = 1; 
END

