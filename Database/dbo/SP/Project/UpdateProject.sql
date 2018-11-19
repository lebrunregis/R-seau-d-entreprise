CREATE PROCEDURE [dbo].[UpdateProject]
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
EXEC @Manager = dbo.FN_GetProjectManagerId @Project;
IF ( @IsAdmin = 1  OR @Manager = @User)
       BEGIN
           UPDATE Project SET Project_Name =  @Name, Project_Description = @Description ,StartDate=CAST(@StartDate AS datetime2(0)),EndDate=CAST(@EndDate AS datetime2(0))   WHERE Project_Id = @Project AND CreatorId = @CreatorId;
           IF (@Project_manager != @Manager)
		       INSERT INTO ProjectManager(Employee_Id, Project_Id) VALUES (@Project_manager, @Project)
	   END
END