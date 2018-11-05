CREATE PROCEDURE [dbo].[ConfirmAdmin]
	@Employee_Id int
AS
	SELECT COUNT (*) AS IsAdmin from [dbo].[Admin] WHERE Employee_Id = @Employee_Id and Actif = 1
