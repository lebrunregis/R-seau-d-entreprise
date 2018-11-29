CREATE PROCEDURE [dbo].[CreateTask]
	@Name nvarchar(50),
	@Description nvarchar(max),
	@StartDate DATETIME2(0) ,
	@EndDate DATETIME2(0),
	@DeadLine DATETIME2(0) ,
	@SubtaskOf int
AS
	INSERT INTO Task (Name,Description,StartDate,EndDate,Deadline,SubtaskOf) VALUES (@Name, @Description,@StartDate,@EndDate,@DeadLine,@SubtaskOf)
RETURN 0
