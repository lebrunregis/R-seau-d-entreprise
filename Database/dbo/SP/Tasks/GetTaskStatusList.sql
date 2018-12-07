CREATE PROCEDURE [dbo].[GetTaskStatusList]
AS
	SELECT TaskStatus_Id,TaskStatus.Name FROM TaskStatus
RETURN 0
