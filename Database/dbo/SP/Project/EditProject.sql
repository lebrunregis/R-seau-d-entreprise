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
DECLARE @IsAdmin bit;
DECLARE @Manager int;
EXEC @IsAdmin = dbo.FN_IsAdmin @User;
EXECUTE dbo.GetProjectManagerId @Project;
IF ( @IsAdmin = 1  OR @Manager = @User)
           UPDATE Project SET Project_Name =  @Name, Project_Description = @Description ,EndDate=CAST(@EndDate AS datetime2(0))   WHERE Project_Id = @Project AND CreatorId = @CreatorId;
       END