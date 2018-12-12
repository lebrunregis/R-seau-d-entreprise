CREATE PROCEDURE [dbo].[DeleteTask]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@StartDate DATETIME2(0),
	@EndDate DATETIME2(0),
	@DeadLine DATETIME2(0),
	@SubtaskOf int,
	@CreatorId int
AS
	DELETE 
	FROM Task 
	WHERE Task_Id = @Id 
	AND Name = @Name 
	AND Description = @Description 
	AND SubtaskOf = @SubtaskOf
	AND CreatorId = @CreatorId
