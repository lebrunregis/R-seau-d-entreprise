CREATE PROCEDURE [dbo].[EditDepartment]
	@DepId INT,
	@Name nvarchar(50),
	@Desc nvarchar(max)
AS
	UPDATE Department SET Title = @Name,Description = @Desc WHERE Department_Id = @DepId
RETURN 0
