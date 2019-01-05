CREATE PROCEDURE [dbo].[GetProject]
	@Id int
AS
	SELECT TOP 1 Project.Project_Id AS Project_Id ,Project_Name, Project_Description, StartDate, EndDate, [CreatorId] , ProjectManager.Employee_Id AS ProjectManagerId
	FROM [dbo].Project 
	JOIN Employee 
	ON [CreatorId] = Employee_Id
	JOIN ProjectManager 
	ON ProjectManager.Project_Id = Project.Project_Id
	WHERE Project.Project_Id = @Id
	ORDER BY ProjectManager.Date DESC