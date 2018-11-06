CREATE PROCEDURE [dbo].[ConfirmAdmin]
	@Employee_Id int,
	@IsAdmin int OUTPUT
AS
	SELECT @IsAdmin = COUNT (*) from [dbo].[Admin] WHERE Employee_Id = @Employee_Id and Actif = 1
