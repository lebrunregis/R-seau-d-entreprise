CREATE PROCEDURE [dbo].[EditTeam]
	@User int,
	@Team_Id int,
	@Name nvarchar(50),
	@TeamLeader int,
	@CreatorId int
AS
BEGIN
DECLARE @Project_Id int;
SELECT @Project_Id = Project_Id FROM Team WHERE Team_Id = @Team_Id;

IF (dbo.FN_IsAdmin(@User) = 1 OR dbo.FN_GetProjectManagerId(@Project_Id) = @User)
    AND EXISTS(SELECT * FROM Team WHERE Team_Id=@Team_Id AND Team_Disbanded IS NULL)
	AND EXISTS(SELECT * FROM Project WHERE Project_Id=@Project_Id AND (EndDate IS NULL OR EndDate > SYSDATETIME()))
       BEGIN
           UPDATE Team SET Team_Name =  @Name WHERE Team_Id = @Team_Id AND Creator_Id = @CreatorId;
           IF (@TeamLeader != dbo.FN_GetTeamLeaderId(@Team_Id)
		       AND EXISTS(SELECT * FROM Employee WHERE Employee_Id = @TeamLeader AND Active = 1))
		       INSERT INTO EmployeeTeamLeader(Employee_Id, Team_Id) VALUES (@TeamLeader, @Team_Id)
	   END
END