CREATE PROCEDURE [dbo].[UpdateEvent]
	@Id int ,
	@Name nvarchar(50) ,
	@Address nvarchar(max),
	@Description nvarchar(max) ,
    @DepartmentId int ,
	@StartDate date,
	@EndDate date,
	@Open bit,
	@AdminId int
AS
	UPDATE Event SET  Name=@Name,Address = @Address,Description = @Description,DepartmentId= @DepartmentId, StartDate = @StartDate ,
	EndDate = @EndDate, [Open] = @Open
	WHERE Event_Id = @Id ;