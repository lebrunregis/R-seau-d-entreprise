CREATE FUNCTION [dbo].[FN_GetHeadOfDepartmentId]
(
	@Department_Id int
)
RETURNS int
AS
BEGIN
	DECLARE @HeadOfDepartment int;
	SELECT TOP 1 @HeadOfDepartment = Employee_Id FROM EmployeeHeadOfDepartment WHERE Department_Id = @Department_Id ORDER BY [Date] DESC;
	RETURN @HeadOfDepartment;
END
