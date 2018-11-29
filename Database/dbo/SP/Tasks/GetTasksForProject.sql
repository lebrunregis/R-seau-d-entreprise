CREATE PROCEDURE [dbo].[GetTasksForProject]
	@Id int
AS
	SELECT Task_Id, Name,Description,StartDate,EndDate,Deadline,SubtaskOf FROM Task WHERE Project_Id = @Id 
RETURN 0
