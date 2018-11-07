CREATE PROCEDURE [dbo].[GetDepartmentById]
	@DepId int
AS
	SELECT * From Department where Department_Id = @DepId
