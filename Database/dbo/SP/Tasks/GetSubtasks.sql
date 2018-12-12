CREATE PROCEDURE [dbo].[GetSubtasks]
	@TaskId int
AS
	SELECT Task_Id, [Name],[Description],StartDate,EndDate,Deadline,SubtaskOf ,CreatorId
	FROM Task 
	WHERE SubtaskOf = @TaskId
