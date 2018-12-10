CREATE PROCEDURE [dbo].[GetActiveProjectsForManager]
	@Manager_Id int
AS
	SELECT Project.Project_Id AS Project_Id, Project_Name, Project_Description, StartDate, EndDate, 
	[CreatorId],LAST_VALUE(ProjectManager.Employee_Id) OVER (ORDER BY Date) AS ProjectManagerId
	FROM Project
	JOIN ProjectManager 
	ON ProjectManager.Project_Id = Project.Project_Id
	GROUP BY  Project.Project_Id  ,Project_Name, Project_Description, StartDate, EndDate, [CreatorId] , ProjectManager.Employee_Id ,Date
	HAVING (EndDate IS NULL OR EndDate > SYSDATETIME())
	AND ProjectManager.Employee_Id = @Manager_Id 
