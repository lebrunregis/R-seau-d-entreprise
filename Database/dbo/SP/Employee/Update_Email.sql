CREATE PROCEDURE [dbo].[Update_Email]
	@Employee_Id int,
    @Email nvarchar(360),
    @Password nvarchar(50)

AS
UPDATE Employee SET Email=@Email WHERE Employee_Id=@Employee_Id AND Passwd=[dbo].FN_Hash(@Password) AND Active=1