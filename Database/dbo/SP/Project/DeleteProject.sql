CREATE PROCEDURE [dbo].[DeleteProject]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@Creator int
AS
	DELETE FROM Project WHERE Project_Id = @Id AND Project_Name=@Name AND Project_Description=@Description AND CreatorId=@Creator;
