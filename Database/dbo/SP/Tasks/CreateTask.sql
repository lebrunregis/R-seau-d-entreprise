CREATE PROCEDURE [dbo].[CreateTask]
	@Name nvarchar(50),
	@Description nvarchar(max),
	@StartDate DATETIME2(0) ,
	@EndDate DATETIME2(0),
	@DeadLine DATETIME2(0) ,
	@SubtaskOf int,
	@UserId int,
	@ProjectId int
AS
	INSERT INTO Task 
	(Name,Description,StartDate,EndDate,Deadline,SubtaskOf,CreatorId,Project_Id) 
	VALUES (@Name, @Description,@StartDate,@EndDate,@DeadLine,@SubtaskOf,@UserId,@ProjectId)
RETURN 0
