CREATE PROCEDURE [dbo].[GetActiveProjectsForManager]
	@Manager_Id int
AS
	SELECT Project_Id, Project_Name, Project_Description, StartDate, EndDate, [CreatorId]
	FROM Project
	WHERE dbo.FN_GetProjectManagerId(Project_Id) = @Manager_Id
	AND (EndDate IS NULL OR EndDate > SYSDATETIME())
