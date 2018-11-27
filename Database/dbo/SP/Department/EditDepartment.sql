CREATE PROCEDURE [dbo].[EditDepartment]
	@DepId INT,
	@Name nvarchar(50),
	@Desc nvarchar(max),
	@Active bit,
	@UserId INT
AS
    IF dbo.FN_IsAdmin(@UserId) = 1
	    UPDATE Department SET Name = @Name,Description = @Desc , Active = @Active WHERE Department_Id = @DepId
