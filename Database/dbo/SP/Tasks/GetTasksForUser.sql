CREATE PROCEDURE [dbo].[GetTasksForUser]
	@UserId int
AS
	SELECT  DISTINCT
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
	CASE	
		WHEN TaskStatus.Name is NULL 
		THEN 'Not started' 
	ELSE 
		LAST_VALUE(TaskStatus.Name) OVER (ORDER BY COALESCE(TaskStatusHistory.date,Task.StartDate)) 
	END 
	AS Status_Name,
	LAST_VALUE(COALESCE(TaskStatusHistory.date,Task.StartDate)) OVER (ORDER BY COALESCE(TaskStatusHistory.date,Task.StartDate)) AS Status_Date,
	LAST_VALUE(COALESCE(TaskStatus.TaskStatus_Id,1)) OVER (ORDER BY COALESCE(TaskStatusHistory.date,Task.StartDate)) AS Status_Id  
	FROM Task 
	LEFT JOIN TaskStatusHistory ON Task.Task_Id = TaskStatusHistory.Task_Id 
	JOIN EmployeeTeam ON EmployeeTeam.Team_Id = Task.Task_Id
	LEFT JOIN TaskStatus ON TaskStatus.TaskStatus_Id = TaskStatusHistory.TaskStatus_Id

	GROUP BY Task.Task_Id,Task.[Name],Task.Team_Id,[Description],
	Task.StartDate,Task.EndDate,Deadline,SubtaskOf,CreatorId,TaskStatusHistory.date,
	TaskStatus.TaskStatus_Id,TaskStatus.Name,Project_Id,Employee_Id

	HAVING EmployeeTeam.Employee_Id = @UserId 
	ORDER BY Status_Date DESC