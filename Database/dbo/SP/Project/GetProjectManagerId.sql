CREATE PROCEDURE [dbo].[GetCurrentManagerId]
	@ProjectId int
AS
	SELECT TOP 1 Employee_Id FROM ProjectManager WHERE Project_Id = @ProjectId ORDER BY Date DESC;

