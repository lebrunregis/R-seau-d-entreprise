CREATE FUNCTION [dbo].[FN_IsInTeam]
(
	@Employee_Id int,
	@Team_Id int
)
RETURNS BIT
AS
BEGIN
	DECLARE @IsInTeam bit;
	SELECT @IsInTeam = CAST ( COUNT (*)AS bit) from EmployeeTeam WHERE Employee_Id = @Employee_Id AND Team_Id = @Team_Id AND EndDate IS NULL;
	RETURN @IsInTeam;
END