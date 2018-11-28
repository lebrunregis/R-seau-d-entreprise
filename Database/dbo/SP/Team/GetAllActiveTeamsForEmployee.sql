CREATE PROCEDURE [dbo].[GetAllActiveTeamsForEmployee]
	@Employee_Id int
AS
BEGIN
	SELECT t.Team_Id, t.Team_Name, t.Team_Created, t.Team_Disbanded, t.[Creator_Id], t.Project_Id
	FROM [dbo].Team t
	JOIN Project p
	ON t.Project_Id = p.Project_Id
	JOIN EmployeeTeam et
	ON t.Team_Id = et.Team_Id
	WHERE et.Employee_Id = @Employee_Id
	AND t.Team_Disbanded IS NULL and (p.EndDate IS NULL OR p.EndDate > GETDATE())
	AND et.EndDate IS NULL
END