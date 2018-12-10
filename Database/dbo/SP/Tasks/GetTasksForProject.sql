CREATE PROCEDURE [dbo].[GetTasksForProject]
	@ProjectId int,
	@UserId int
AS
	SELECT 
	Task.Task_Id AS Task_Id,Task.[Name],Task.Team_Id,[Description],
	StartDate,
	EndDate,
	Deadline,
	SubtaskOf,
	CreatorId, 
	CASE WHEN TaskStatus.TaskStatus_Id is NULL THEN 1 ELSE TaskStatus.TaskStatus_Id END AS Status_Id,
	ISNULL(TaskStatusHistory.date,StartDate) AS Status_Date,
	CASE	
		WHEN TaskStatus.Name is NULL 
		THEN 'Not started' 
	ELSE 
		LAST_VALUE(TaskStatus.Name) OVER (ORDER BY TaskStatusHistory.date) 
	END 
	AS Status_Name
	FROM Task 

	LEFT JOIN TaskStatusHistory ON Task.Task_Id = TaskStatusHistory.Task_Id 
	LEFT JOIN TaskStatus ON TaskStatus.TaskStatus_Id = TaskStatusHistory.TaskStatus_Id
	LEFT JOIN EmployeeTask ON EmployeeTask.Task_Id = Task.Task_Id
	
	WHERE Task.Project_Id = @ProjectId
	GROUP BY Task.Task_Id,Task.[Name],Task.Team_Id,[Description],
	StartDate,EndDate,Deadline,SubtaskOf,CreatorId,TaskStatusHistory.date,
	TaskStatus.TaskStatus_Id,TaskStatus.Name
	ORDER BY TaskStatusHistory.date