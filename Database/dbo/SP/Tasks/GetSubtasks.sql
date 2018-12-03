CREATE PROCEDURE [dbo].[GetSubtasks]
	@TaskId int
AS
	SELECT Task_Id, Name,Description,StartDate,EndDate,Deadline,SubtaskOf 
	FROM Task 
	WHERE SubtaskOf = @TaskId 
RETURN 0
