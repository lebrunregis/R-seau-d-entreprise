CREATE PROCEDURE [dbo].[GetActiveTeamsInCommon]
	@Emp_Id_1 int,
	@Emp_Id_2 int
AS
	SELECT t.Team_Id, t.Team_Name, t.Team_Created, t.Team_Disbanded, t.[Creator_Id], t.Project_Id
	FROM [dbo].Team t
	JOIN Project p
	ON t.Project_Id = p.Project_Id
	JOIN EmployeeTeam et1
	ON et1.Team_Id = t.Team_Id
	JOIN EmployeeTeam et2
	ON et2.Team_Id = t.Team_Id
	WHERE et1.Employee_Id = @Emp_Id_1
	AND et2.Employee_Id = @Emp_Id_2
	AND et1.EndDate IS NULL
	AND et2.EndDate IS NULL
	AND t.Team_Disbanded IS NULL and (p.EndDate IS NULL OR p.EndDate > GETDATE())
