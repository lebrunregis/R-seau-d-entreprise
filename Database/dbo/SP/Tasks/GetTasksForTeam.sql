CREATE PROCEDURE [dbo].[GetTasksForTeam]
@TeamId int,
@UserId int
AS
	SELECT 
	Task.Task_Id AS Task_Id,
	Task.[Name],
	Task.Team_Id,
	[Description],
	StartDate,
	EndDate,
	Deadline,
	SubtaskOf,
	CreatorId,
	ISNULL(TaskStatus.TaskStatus_Id,1) AS Status_Id,  
	ISNULL(TaskStatusHistory.date,StartDate) AS Status_Date,
	LAST_VALUE(TaskStatus.Name) OVER (ORDER BY TaskStatusHistory.date) AS Status_Name
	FROM Task 
	LEFT JOIN TaskStatusHistory ON Task.Task_Id = TaskStatusHistory.Task_Id 
	LEFT JOIN EmployeeTask ON EmployeeTask.Task_Id = Task.Task_Id
	LEFT JOIN TaskStatus ON TaskStatus.TaskStatus_Id = TaskStatus.TaskStatus_Id
	WHERE Task.Team_Id = @TeamId
	ORDER BY TaskStatusHistory.date