CREATE PROCEDURE [dbo].[RemoveEmployeeFromTeam]
	@Employee_Id int,
	@Team_Id int,
	@User int
AS
BEGIN
    DECLARE @Project_Id int;
    SELECT @Project_Id = Project_Id FROM Team WHERE Team_Id = @Team_Id;

    IF dbo.FN_IsAdmin(@User) = 1 OR
	   dbo.FN_GetProjectManagerId(@Project_Id) = @User OR
	   dbo.FN_GetTeamLeaderId(@Team_Id) = @User
	    DELETE FROM EmployeeTeam WHERE Employee_Id = @Employee_Id AND Team_Id = @Team_Id AND EndDate IS NULL
END