CREATE PROCEDURE [dbo].[CreateTeam]
	@name nvarchar(50),
	@team_leader int,
	@Creator_Id int,
	@Project_Id int
AS
BEGIN


DECLARE @team_id int

IF EXISTS(SELECT * FROM [dbo].[Employee] WHERE Employee_Id = @team_leader AND Active = 1) AND 
    (dbo.FN_IsAdmin(@Creator_Id) = 1 OR dbo.FN_GetProjectManagerId(@Project_Id) = @Creator_Id)
       BEGIN
           INSERT INTO [dbo].Team (Team_Name, Creator_Id, Project_Id) VALUES (@name, @Creator_Id, @Project_Id);
	       SET @team_id = convert(int,IDENT_CURRENT ('dbo.Team'));
	       INSERT INTO [dbo].EmployeeTeamLeader(Team_Id, Employee_Id) VALUES (@team_id, @team_leader);
	       SELECT @team_id
       END
END