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
EXECUTE dbo.ConfirmAdmin @User, @IsAdmin output;
EXECUTE dbo.GetProjectManagerId @Project , @Manager output;
IF ( @IsAdmin = 1 OR @Manager = @User)
           UPDATE Project SET Project_Name =  @Name, Project_Description = @Description ,EndDate=CAST(@EndDate AS datetime2(0))   WHERE Project_Id = @Project AND CreatorId = @CreatorId;
       END