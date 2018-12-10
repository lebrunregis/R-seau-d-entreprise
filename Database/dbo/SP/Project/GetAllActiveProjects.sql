CREATE PROCEDURE [dbo].[GetAllActiveProjects]
AS
	SELECT 
	Project.Project_Id AS Project_Id ,
	Project_Name,
	Project_Description,
	StartDate,
	EndDate,
	[CreatorId] ,
	LAST_VALUE(ProjectManager.Employee_Id) OVER (ORDER BY Date) AS ProjectManager
	FROM [dbo].Project 
	JOIN ProjectManager 
	ON ProjectManager.Project_Id = Project.Project_Id
	GROUP BY  Project.Project_Id  ,Project_Name, Project_Description, StartDate, EndDate, [CreatorId] , ProjectManager.Employee_Id ,Date
	HAVING EndDate IS NULL OR EndDate > CAST(GETDATE() AS datetime2(0))
ORDER BY Date