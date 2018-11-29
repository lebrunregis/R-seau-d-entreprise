CREATE PROCEDURE [dbo].[GetTask]
	@Id int
AS
	SELECT TOP 1 Task.Task_Id AS Task_Id, Name,Description,StartDate,EndDate,Deadline,SubtaskOf ,Status_Name ,date FROM Task 
	LEFT JOIN TaskStatusHistory ON Task.Task_Id = TaskStatusHistory.Task_Id 
	JOIN TaskStatus ON TaskStatus.TaskStatus_Id = TaskStatus.TaskStatus_Id
	WHERE Task.Task_Id = @Id 
	ORDER BY TaskStatusHistory.date
RETURN 0
