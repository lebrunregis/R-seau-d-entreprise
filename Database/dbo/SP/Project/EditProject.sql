CREATE PROCEDURE [dbo].[EditProject]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@Project_manager int,
	@CreatorId int

AS
BEGIN
IF (EXISTS(SELECT * FROM [dbo].[Admin] WHERE Employee_Id = @CreatorId AND Actif = 1) AND
   EXISTS(SELECT * FROM [dbo].[Employee] WHERE Employee_Id = @Project_manager AND Active = 1))
           UPDATE Project SET Project_Name =  @Name, Project_Description = @Description WHERE Project_Id = @Id;
	       UPDATE ProjectManager SET Project_Id = @Id, Employee_Id= @Project_manager;
       END