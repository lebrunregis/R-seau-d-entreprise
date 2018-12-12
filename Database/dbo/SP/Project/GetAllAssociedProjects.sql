CREATE PROCEDURE [dbo].[GetAllAssociedProjects]
	@EmployeeId int
AS
	SELECT DISTINCT Project.Project_Id,Project_Name, Project_Description,
	[CreatorId] ,LAST_VALUE(ProjectManager.Employee_Id) OVER (ORDER BY Date) AS ProjectManagerId, EmployeeTeam.Employee_Id
	FROM [dbo].Project 
	JOIN Employee 
	ON [CreatorId] = Employee_Id 
	JOIN ProjectManager 
	ON ProjectManager.Project_Id = Project.Project_Id
	LEFT JOIN Team ON Team.Project_Id = Project.Project_Id
	LEFT JOIN EmployeeTeam ON EmployeeTeam.Team_Id = Team.Team_Id
	GROUP BY  Project.Project_Id  ,Project_Name, Project_Description, [CreatorId] , ProjectManager.Employee_Id ,Date , EmployeeTeam.Employee_Id
	HAVING [CreatorId] = @EmployeeId OR
	ProjectManager.Employee_Id =  @EmployeeId OR
	EmployeeTeam.Employee_Id = @EmployeeId