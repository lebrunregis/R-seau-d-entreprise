CREATE PROCEDURE [dbo].[GetTasksForUser]
	@UserId int
AS
	SELECT Task.Task_Id AS Task_Id, Name,Description,StartDate,EndDate,Deadline,SubtaskOf ,
	ISNULL(TaskStatus.TaskStatus_Id,1) AS Status_Id,  ISNULL(TaskStatusHistory.date,StartDate) AS LastStatusDate ,
	LAST_VALUE(Status_Name) OVER (ORDER BY TaskStatusHistory.date)
	FROM Task 
	LEFT JOIN TaskStatusHistory ON Task.Task_Id = TaskStatusHistory.Task_Id 
	LEFT JOIN EmployeeTask ON EmployeeTask.Task_Id = Task.Task_Id
	JOIN TaskStatus ON TaskStatus.TaskStatus_Id = TaskStatus.TaskStatus_Id
	GROUP BY Task.Task_Id
	HAVING EmployeeTask.Employee_Id = @UserId 
	ORDER BY TaskStatusHistory.date
RETURN 0
