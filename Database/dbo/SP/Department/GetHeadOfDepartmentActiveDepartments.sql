CREATE PROCEDURE [dbo].[GetHeadOfDepartmentActiveDepartments]
	@HeadOfDepartment_Id int
AS
	SELECT Department_Id,Name,Description,Created,Creator_Id,Active FROM Department 
	WHERE dbo.FN_GetHeadOfDepartmentId(Department_Id) = @HeadOfDepartment_Id AND Active=1
