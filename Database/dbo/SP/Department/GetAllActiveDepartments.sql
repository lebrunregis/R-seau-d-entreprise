CREATE PROCEDURE [dbo].[GetAllActiveDepartments]
AS
	SELECT Department_Id,Name,Description,Created,Creator_Id,Active FROM Department WHERE Active = 1
RETURN 0
