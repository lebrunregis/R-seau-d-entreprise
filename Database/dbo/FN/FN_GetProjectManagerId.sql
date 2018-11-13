CREATE FUNCTION [dbo].[FN_GetProjectManagerId]
(
	@ProjectId int
)
RETURNS int
AS
BEGIN
	DECLARE @ProjectManager int;
	SELECT TOP 1 @ProjectManager = Employee_Id FROM ProjectManager WHERE Project_Id = @ProjectId ORDER BY Date DESC;
	RETURN @ProjectManager;
END