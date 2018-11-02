CREATE PROCEDURE [dbo].[ConfirmAdmin]
	@Employee_Id int
AS
	SELECT Employee_Id from [dbo].[Admin] WHERE Employee_Id = @Employee_Id and Actif = 1
