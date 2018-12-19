CREATE PROCEDURE [dbo].[GetSubtasks]
	@TaskId int,
	@UserId int
AS
	SELECT
Task_Id,
x.Name AS Name,
Team_Id,
Description,
StartDate,
EndDate,
Deadline,
SubtaskOf,
CreatorId,
Project_Id,
Status_Date ,
x.TaskStatus_Id AS Status_Id,
TaskStatus.Name AS Status_Name
FROM (
	SELECT 
	Task.Task_Id AS Task_Id,
	Task.[Name],
	Task.Team_Id,
	[Description],
	Task.StartDate,
	Task.EndDate,
	Deadline,
	SubtaskOf,
	CreatorId,
	Project_Id, 
	COALESCE(TaskStatus_Id,0)  AS TaskStatus_Id ,
	COALESCE(TaskStatusHistory.date,Task.StartDate) AS Status_Date,
	RANK() OVER (PARTITION BY Task.Task_Id ORDER BY COALESCE(TaskStatusHistory.date,Task.StartDate) DESC) Status_Rank
	FROM Task 
	LEFT JOIN TaskStatusHistory ON Task.Task_Id= TaskStatusHistory.Task_Id 
	WHERE SubtaskOf = @TaskId) x
	JOIN TaskStatus ON TaskStatus.TaskStatus_Id = x.TaskStatus_Id
	WHERE Status_Rank = 1
