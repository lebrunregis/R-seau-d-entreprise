CREATE PROCEDURE [dbo].[GetTask]
	@TaskId int,
	@UserId int
AS
	SELECT TOP 1 Task.Task_Id AS Task_Id, Name,Description,StartDate,EndDate,Deadline,SubtaskOf ,
	ISNULL(TaskStatus.TaskStatus_Id,1) AS Status_Id, Status_Name ,ISNULL(date,StartDate) AS StatusDate FROM Task 
	LEFT JOIN TaskStatusHistory ON Task.Task_Id = TaskStatusHistory.Task_Id 
	JOIN TaskStatus ON TaskStatus.TaskStatus_Id = TaskStatus.TaskStatus_Id
	WHERE Task.Task_Id = @TaskId 
	ORDER BY TaskStatusHistory.date
RETURN 0
