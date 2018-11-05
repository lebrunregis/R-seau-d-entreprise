CREATE PROCEDURE [dbo].[EditProject]
	@User int,
	@Project int,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@Project_manager int,
	@CreatorId int,
	@StartDate datetime2,
	@EndDate datetime2
AS
BEGIN
DECLARE @IsAdmin int;
DECLARE @Manager int;
EXEC @IsAdmin = dbo.ConfirmAdmin @User;
EXEC @Manager = dbo.GetProjectManagerId @Project;
IF ( @IsAdmin = 1 OR @Manager = @User)
           UPDATE Project SET Project_Name =  @Name, Project_Description = @Description ,EndDate= @EndDate  WHERE Project_Id = @Project AND StartDate = @StartDate AND CreatorId = @CreatorId;
       END