CREATE PROCEDURE [dbo].[CreateProject]
	@name nvarchar(50),
	@description nvarchar(max),
	@creator int,
	@project_manager int
AS
BEGIN


DECLARE @project_id int

IF EXISTS(SELECT * FROM [dbo].[Admin] WHERE Employee_Id = @creator AND Actif = 1) AND
   EXISTS(SELECT * FROM [dbo].[Employee] WHERE Employee_Id = @project_manager AND Active = 1)
       BEGIN
           INSERT INTO [dbo].Project (Project_Name, Project_Description, [CreatorId]) VALUES (@name, @description, @creator);
	       SET @project_id = convert(int,SCOPE_IDENTITY() );
	       INSERT INTO [dbo].EmployeeProjectManager(Project_Id, Employee_Id) VALUES (@project_id, @project_manager);
	       SELECT @project_id
       END
END