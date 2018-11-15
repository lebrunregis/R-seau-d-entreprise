CREATE PROCEDURE [dbo].[GetAllActiveDepartments]
AS
	SELECT * FROM Department WHERE Active = 1
RETURN 0
