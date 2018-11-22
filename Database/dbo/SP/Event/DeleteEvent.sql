CREATE PROCEDURE [dbo].[DeleteEvent]
	@Id int ,
	@Name nvarchar(50) ,
	@Description nvarchar(max) ,
	@Address nvarchar(max),
	@StartDate date,
	@EndDate date,
	@CreatorId int,
	@DepartmentId int,
	@AdminId int
AS
IF SYSDATETIME()<@StartDate
	DELETE FROM Event 
	WHERE Event_Id = @Id AND 
	Name=@Name AND 
	Description = @Description AND 
	Address = @Address AND 
	StartDate = @StartDate AND 
	EndDate = @EndDate AND 
	DepartmentId = @DepartmentId ;
