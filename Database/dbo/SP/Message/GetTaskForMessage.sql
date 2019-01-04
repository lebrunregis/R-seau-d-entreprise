CREATE PROCEDURE [dbo].[GetTaskForMessage]
	@MessageId int
AS
	SELECT TOP 1
	Task.Task_Id AS Task_Id,
	Task.[Name],
	Task.Team_Id,
	[Description],
	StartDate,
	EndDate,
	Deadline,
	SubtaskOf,
	CreatorId,
	-1 AS Status_Id,  
	CONVERT (datetime,0) AS Status_Date,
	'' AS Status_Name
	FROM Task 
	JOIN MessageTask mt ON Task.Task_Id=mt.Task_Id
	WHERE mt.Message_Id = @MessageId