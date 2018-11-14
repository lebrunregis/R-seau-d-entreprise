CREATE PROCEDURE [dbo].[DeleteEmployeeFromTeam]
	@Employee_Id int,
	@Team_Id int,
	@User int
AS
BEGIN
    DECLARE @Project_Id int;
    SELECT @Project_Id = Project_Id FROM Team WHERE Team_Id = @Team_Id;

    IF FN_IsAdmin(@User) = 1 OR
	   FN_IsProjectManager(@User, @Project_Id) = 1 OR
	   FN_IsTeamLeader(@User, @Team_Id) = 1
	    DELETE FROM EmployeeTeam WHERE Employee_Id = @Employee_Id AND Team_Id = @Team_Id AND EndDate IS NULL
END