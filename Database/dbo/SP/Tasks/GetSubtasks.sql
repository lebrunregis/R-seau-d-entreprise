CREATE PROCEDURE [dbo].[GetSubtasks]
	@TaskId int,
	@UserId int
AS
	SELECT Task_Id, [Name],[Description],StartDate,EndDate,Deadline,SubtaskOf ,CreatorId, Project_Id
	FROM Task 
	WHERE SubtaskOf = @TaskId
