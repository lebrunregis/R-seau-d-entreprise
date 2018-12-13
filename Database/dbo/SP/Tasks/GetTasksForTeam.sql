CREATE PROCEDURE [dbo].[GetTasksForTeam]
@TeamId int,
@UserId int
AS
	SELECT DISTINCT
	Task.Task_Id AS Task_Id,
	Task.[Name],
	Task.Team_Id,
	[Description],
	StartDate,
	EndDate,
	Deadline,
	SubtaskOf,
	CreatorId,
	CASE	
		WHEN TaskStatus.Name is NULL 
		THEN 'Not started' 
	ELSE 
		LAST_VALUE(TaskStatus.Name) OVER (ORDER BY TaskStatusHistory.date) 
	END 
	AS Status_Name,
	LAST_VALUE(ISNULL(TaskStatus.TaskStatus_Id,1)) OVER (ORDER BY TaskStatusHistory.date) AS Status_Id,  
	LAST_VALUE(ISNULL(TaskStatusHistory.date,StartDate)) OVER (ORDER BY TaskStatusHistory.date) AS Status_Date
	FROM Task 
	LEFT JOIN TaskStatusHistory ON Task.Task_Id = TaskStatusHistory.Task_Id 
	LEFT JOIN EmployeeTask ON EmployeeTask.Task_Id = Task.Task_Id
	LEFT JOIN TaskStatus ON TaskStatus.TaskStatus_Id = TaskStatusHistory.TaskStatus_Id
	
	GROUP BY Task.Task_Id,
	Task.[Name],
	Task.Team_Id,
	[Description],
	StartDate,
	EndDate,
	Deadline,
	SubtaskOf,
	CreatorId,
	TaskStatus.Name,
	TaskStatus.TaskStatus_Id,
	TaskStatusHistory.date
	
	HAVING Task.Team_Id = @TeamId
	ORDER BY Status_Date