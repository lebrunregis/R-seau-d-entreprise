CREATE PROCEDURE [dbo].[GetAllProjects]
AS
	SELECT Project_Id,Project_Name, Project_Description, StartDate, EndDate, [CreatorId]
	FROM [dbo].Project