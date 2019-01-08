CREATE PROCEDURE [dbo].[UpdateTask]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@StartDate DATETIME2(0),
	@EndDate DATETIME2(0),
	@DeadLine DATETIME2(0),
	@SubtaskOf int,
	@UserId int
AS
	UPDATE Task 
	SET Name = @Name,Description = @Description,StartDate = @StartDate,EndDate = @EndDate,Deadline = @DeadLine 
	WHERE @Id = Task_Id
