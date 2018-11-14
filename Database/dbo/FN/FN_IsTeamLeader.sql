CREATE FUNCTION [dbo].[FN_IsTeamLeader]
(
	@Employee_Id int,
	@Team_Id int
)
RETURNS BIT
AS
BEGIN
	DECLARE @IsTeamLeader bit;
	IF FN_GetTeamLeaderId(@Team_Id) = @Employee_Id
	    SET @IsTeamLeader = 1
	RETURN @IsTeamLeader;
END
