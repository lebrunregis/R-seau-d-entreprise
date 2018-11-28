CREATE PROCEDURE [dbo].[AddEmployeeToTeam]
	@Employee_Id int,
	@Team_Id int,
	@User int
AS
BEGIN
    IF @Employee_Id IN (SELECT Employee_Id FROM Employee WHERE Active=1)
	AND EXISTS(SELECT * FROM Team WHERE Team_Id=@Team_Id AND Team_Disbanded IS NULL)
	BEGIN
        DECLARE @Project_Id int;
        SELECT @Project_Id = Project_Id FROM Team WHERE Team_Id = @Team_Id;

        IF (dbo.FN_IsAdmin(@User) = 1 OR
	       dbo.FN_GetProjectManagerId(@Project_Id) = @User OR
	       dbo.FN_GetTeamLeaderId(@Team_Id) = @User)
		   AND EXISTS(SELECT * FROM Project WHERE Project_Id=@Project_Id AND (EndDate IS NULL OR EndDate > SYSDATETIME()))
	        IF NOT EXISTS (SELECT * FROM EmployeeTeam WHERE Employee_Id = @Employee_Id AND Team_Id = @Team_Id AND EndDate IS NULL)
	            INSERT INTO EmployeeTeam (Employee_Id, Team_Id) VALUES (@Employee_Id, @Team_Id)
	END
END
