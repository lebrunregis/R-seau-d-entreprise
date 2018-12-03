CREATE PROCEDURE [dbo].[GetTaskStatusList]
AS
	SELECT TaskStatus_Id,Status_Name FROM TaskStatus
RETURN 0
