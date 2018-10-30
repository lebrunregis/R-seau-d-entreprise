CREATE PROCEDURE [dbo].[Update_Password]
	@Employee_Id int,
    @Old_Password nvarchar(50),
    @New_Password nvarchar(50)

AS
UPDATE Employee SET Passwd=FN_HASH(@New_Password) WHERE Employee_Id=@Employee_Id AND Passwd=FN_HASH(@Old_Password)