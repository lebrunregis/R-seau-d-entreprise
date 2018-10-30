CREATE PROCEDURE [dbo].[Update_Password]
	@Employee_Id int,
    @Old_Password nvarchar(50),
    @New_Password nvarchar(50)

AS
UPDATE Employee SET Passwd=[dbo].FN_Hash(@New_Password) WHERE Employee_Id=@Employee_Id AND Passwd=[dbo].FN_Hash(@Old_Password) AND Active=1