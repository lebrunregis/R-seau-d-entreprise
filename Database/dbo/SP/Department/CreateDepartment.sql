CREATE PROCEDURE [dbo].[CreateDepartment]
	@Name nvarchar (50),
	@Description nvarchar (max),
	@AdminId int
AS
	INSERT INTO Department(Title,Description,Admin_Id) VALUES (@Name,@Description,@AdminId)
SELECT Scope_Identity()