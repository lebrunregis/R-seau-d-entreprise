CREATE PROCEDURE [dbo].[DeleteDepartment]
	@DepartmentId int, @User int
AS
    IF dbo.FN_IsAdmin(@User) = 1
	    DELETE FROM Department WHERE Department_Id = @DepartmentId
