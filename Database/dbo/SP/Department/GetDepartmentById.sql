CREATE PROCEDURE [dbo].[GetDepartmentById]
	@DepId int
AS
	SELECT Department_Id,Name,Description,Created,Creator_Id,Active From Department where Department_Id = @DepId
