CREATE PROCEDURE [dbo].[GetProjectManagerId]
	@ProjectId int,
	@Manager int OUTPUT
AS
	SELECT TOP 1 @Manager = Employee_Id FROM ProjectManager WHERE Project_Id = @ProjectId ORDER BY Date DESC;

