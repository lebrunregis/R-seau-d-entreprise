CREATE PROCEDURE [dbo].[DeleteEvent]
	@Id int ,
	@Name nvarchar(50) ,
	@Description nvarchar(max) ,
	@Address nvarchar(max),
	@StartDate datetime2(0),
	@EndDate datetime2(0),
	@CreatorId int,
	@AdminId int
AS
IF SYSDATETIME()<@EndDate
	DELETE FROM Event WHERE Event_Id = @Id AND Name=@Name AND Description = @Description AND Address = @Address AND StartDate = @StartDate AND EndDate = @EndDate 
ELSE 
