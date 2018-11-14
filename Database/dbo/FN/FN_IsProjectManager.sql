CREATE FUNCTION [dbo].[FN_IsProjectManager]
(
	@Employee_Id int,
	@Project_Id int
)
RETURNS BIT
AS
BEGIN
	DECLARE @IsProjectManager bit = 0;
	IF FN_GetProjectManagerId(@Project_Id) = @Employee_Id
	    SET @IsProjectManager = 1
	RETURN @IsProjectManager;
END
