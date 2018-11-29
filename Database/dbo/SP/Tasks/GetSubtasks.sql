CREATE PROCEDURE [dbo].[GetSubtasks]
	@Id int
AS
	SELECT Task_Id, Name,Description,StartDate,EndDate,Deadline,SubtaskOf FROM Task WHERE SubtaskOf = @Id 
RETURN 0
