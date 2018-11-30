CREATE PROCEDURE [dbo].[GetAllDepartments]
AS
	SELECT Department_Id,Name,Description,Created,Creator_Id,Active FROM Department
RETURN 0
