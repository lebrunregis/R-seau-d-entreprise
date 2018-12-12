CREATE PROCEDURE [dbo].[GetTaskStatusList]
AS
	SELECT TaskStatus_Id,Name FROM TaskStatus
RETURN 0
