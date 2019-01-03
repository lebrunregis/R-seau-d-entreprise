CREATE PROCEDURE [dbo].[DeleteEvent]
	@Id int ,
	@Name nvarchar(50) ,
	@Description nvarchar(max) ,
	@Address nvarchar(max),
	@CreatorId int,
	@DepartmentId int,
	@AdminId int
AS
	DELETE FROM Event 
	WHERE Event_Id = @Id --AND Name = @Name AND Description = @Description AND @Address = Address AND @CreatorId = CreatorId AND DepartmentId = @DepartmentId ;
