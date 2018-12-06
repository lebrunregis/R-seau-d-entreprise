CREATE PROCEDURE [dbo].[GetTaskStatusHistory]
@TaskId INT
AS
	SELECT Task_Id,TaskStatusHistory.TaskStatus_Id AS TaskStatus_Id,
	TaskStatus.Name,date
	FROM TaskStatusHistory
	JOIN TaskStatus ON TaskStatusHistory.TaskStatus_Id = TaskStatus.TaskStatus_Id
	WHERE Task_Id = @TaskId
RETURN 0
