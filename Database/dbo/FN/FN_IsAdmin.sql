CREATE FUNCTION [dbo].[FN_IsAdmin]
(
	@EmployeeId int
)
RETURNS BIT
AS
BEGIN
	DECLARE @IsAdmin bit;
	SELECT @IsAdmin = CAST ( COUNT (*)AS bit) from [dbo].[Admin] WHERE Employee_Id = @EmployeeId and Actif = 1;
	RETURN @IsAdmin;
END
