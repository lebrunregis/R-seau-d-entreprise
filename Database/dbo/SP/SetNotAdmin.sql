CREATE PROCEDURE [dbo].[SetNotAdmin]
	@Employee_Id int
AS
UPDATE [Admin] SET Actif=0 WHERE Employee_Id=@Employee_Id;
