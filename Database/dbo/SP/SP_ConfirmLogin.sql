CREATE procedure [dbo].[SP_ConfirmLogin] 
    @login varchar(50),
	@pwd varchar(50)
AS
BEGIN
	select count(*) from [Login] where [Login].Login = @login and [Login].Hash = dbo.FN_Hash(@pwd); 
END

