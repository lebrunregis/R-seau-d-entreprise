CREATE PROCEDURE [dbo].[ConfirmAdmin]
	@Employee_Id int
AS
BEGIN
DECLARE @IsAdmin bit
	EXEC @IsAdmin =FN_IsAdmin @Employee_Id
	SELECT @IsAdmin
END