CREATE PROCEDURE [dbo].[UpdateEvent]
	@Id int ,
	@Name nvarchar(50) ,
	@Description nvarchar(max) ,
	@Address nvarchar(max),
	@StartDate datetime2(0),
	@EndDate datetime2(0),
	@Open bit,
	@AdminId int
AS
	UPDATE Event SET  Name=@Name,Description = @Description,Address = @Address, StartDate = @StartDate , EndDate = @EndDate , [Open] = @Open
	WHERE Event_Id = @Id ;