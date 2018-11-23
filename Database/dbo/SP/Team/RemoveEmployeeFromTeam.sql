CREATE PROCEDURE [dbo].[RemoveEmployeeFromTeam]
	@Employee_Id int,
	@Team_Id int,
	@User int
AS
BEGIN
IF EXISTS(SELECT * FROM Team WHERE Team_Id=@Team_Id AND Team_Disbanded IS NULL)
    BEGIN
		DECLARE @Project_Id int;
		SELECT @Project_Id = Project_Id FROM Team WHERE Team_Id = @Team_Id;

		IF (dbo.FN_IsAdmin(@User) = 1 OR
		dbo.FN_GetProjectManagerId(@Project_Id) = @User OR
		dbo.FN_GetTeamLeaderId(@Team_Id) = @User)
		AND EXISTS(SELECT * FROM Project WHERE Project_Id=@Project_Id AND (EndDate IS NULL OR EndDate > SYSDATETIME()))
			DELETE FROM EmployeeTeam WHERE Employee_Id = @Employee_Id AND Team_Id = @Team_Id AND EndDate IS NULL
	END
END