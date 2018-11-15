CREATE FUNCTION [dbo].[FN_GetTeamLeaderId]
(
	@Team_Id int
)
RETURNS int
AS
BEGIN
	DECLARE @TeamLeader int;
	SELECT TOP 1 @TeamLeader = Employee_Id FROM EmployeeTeamLeader WHERE Team_Id = @Team_Id ORDER BY [date] DESC;
	RETURN @TeamLeader;
END