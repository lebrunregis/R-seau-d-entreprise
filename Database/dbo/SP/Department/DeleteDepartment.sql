CREATE PROCEDURE [dbo].[DeleteDepartment]
	@DepartmentId int
AS
	DELETE FROM Department WHERE Department_Id = @DepartmentId
RETURN 0
