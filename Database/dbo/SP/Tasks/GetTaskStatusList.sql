CREATE PROCEDURE [dbo].[GetTaskStatusList]
AS
	SELECT TaskStatus_Id,Name FROM TaskStatus
	ORDER BY TaskStatus_Id
