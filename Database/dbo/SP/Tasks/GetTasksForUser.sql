CREATE PROCEDURE [dbo].[GetTasksForUser]
	@UserId int
AS
SELECT DISTINCT
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
	Task.Project_Id, 
	COALESCE(TaskStatus_Id,0)  AS TaskStatus_Id ,
	COALESCE(TaskStatusHistory.date,Task.StartDate) AS Status_Date,
	RANK() OVER (PARTITION BY Task.Task_Id ORDER BY COALESCE(TaskStatusHistory.date,Task.StartDate) DESC) Status_Rank
	FROM Task 
	LEFT JOIN TaskStatusHistory ON Task.Task_Id= TaskStatusHistory.Task_Id 
	LEFT JOIN EmployeeTeam et1 ON et1.Team_Id =  Task.Team_Id
	LEFT JOIN Team ON Task.Project_Id = Team.Project_Id
	LEFT JOIN EmployeeTeam et2 ON et2.Team_Id = Team.Team_Id
	WHERE et1.Employee_Id = @UserId
	OR (Task.Team_Id IS NULL AND et2.Employee_Id = @UserId)) x
JOIN TaskStatus ON TaskStatus.TaskStatus_Id = x.TaskStatus_Id
WHERE Status_Rank = 1