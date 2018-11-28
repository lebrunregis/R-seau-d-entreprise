CREATE PROCEDURE [dbo].[GetHeadOfDepartmentId]
	@DepartmentId int
AS
	SELECT dbo.FN_GetHeadOfDepartmentId(@DepartmentId);
